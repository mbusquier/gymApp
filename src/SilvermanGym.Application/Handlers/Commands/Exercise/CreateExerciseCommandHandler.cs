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
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ExerciseDto>
    {
         public readonly IExerciseRepository _exerciseRepository;

        public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository)
        {
            this._exerciseRepository = exerciseRepository;
        }
        public async Task<ExerciseDto> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var excExits = await _exerciseRepository.CheckExerciseName(request.Name, cancellationToken);

            if(excExits)
            {
                var failure = new ValidationFailure
                (
                    nameof(request.Name),
                    $"The exercise with name = {request.Name} already exits"
                );
                throw new FluentValidation.ValidationException(new[] { failure });
            }
            else
            {
                var newExercise = new Exercise
                (
                    Guid.NewGuid(),
                    request.Name,
                    request.ExerciseEquipment,
                    request.ExerciseType,
                    request.Description
                );

                await _exerciseRepository.CreateExercise(newExercise,cancellationToken);

                return new ExerciseDto
                    (
                        newExercise.Id,
                        newExercise.Name,
                        newExercise.ExerciseEquipment,
                        newExercise.ExerciseType,
                        newExercise.Description
                    );

            }
        }
    }
}