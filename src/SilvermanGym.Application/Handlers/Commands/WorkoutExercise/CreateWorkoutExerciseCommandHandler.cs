using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using SilvermanGym.Application.Contracts.Commands;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Interfaces;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Handlers.Commands
{
    public class CreateWorkoutExerciseCommandHandler : IRequestHandler<CreateWorkoutExerciseCommand, WorkoutExerciseDto>
    {
        public readonly IWorkoutRepository _workoutRepository;
        public readonly IExerciseRepository _exerciseRepository;
        public readonly IWorkoutExerciseRepository _workoutExRepository;

        public CreateWorkoutExerciseCommandHandler(IWorkoutRepository workoutRepository, 
            IExerciseRepository exerciseRepository,  IWorkoutExerciseRepository workoutExRepository)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _workoutExRepository = workoutExRepository;
        }
        public async Task<WorkoutExerciseDto> Handle(CreateWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.CheckIfExerciseExists(request.ExId,cancellationToken);
            var workout = await _workoutRepository.CheckIfWorkoutExists(request.WorkId, cancellationToken);

            if(exercise && workout)
            {
                var newWorkEx = new WorkoutExercisesMap
                    (
                        Guid.NewGuid(),
                        request.WorkId,
                        request.ExId,
                        request.Reps,
                        request.Weight
                    );

                await _workoutExRepository.CreateWorkoutEx(newWorkEx,cancellationToken);

                var exerciseFill = await _exerciseRepository.GetExerciseById(request.ExId,cancellationToken);

                return new WorkoutExerciseDto
                    (
                        newWorkEx.Id,
                        new ExerciseDto
                            (
                                exerciseFill.Id,
                                exerciseFill.Name,
                                exerciseFill.ExerciseEquipment,
                                exerciseFill.ExerciseType,
                                exerciseFill.Description
                            ),
                        newWorkEx.Reps,
                        newWorkEx.Weight
                    );
            }
            else
            {
                if(!exercise)
                {
                    var failure = new ValidationFailure
                        (
                            nameof(request.ExId),
                            $"The exercise with Id = {request.ExId} does not exits"
                        );
                        throw new FluentValidation.ValidationException(new[] { failure });
                }
                else
                {
                    var failure = new ValidationFailure
                        (
                            nameof(request.WorkId),
                            $"The workout with Id = {request.WorkId} does not exits"
                        );
                        throw new FluentValidation.ValidationException(new[] { failure });
                }
                
            }
        }
    }
}