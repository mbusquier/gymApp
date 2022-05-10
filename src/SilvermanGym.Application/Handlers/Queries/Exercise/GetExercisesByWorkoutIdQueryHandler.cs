using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries;
using SilvermanGym.Application.Exceptions;
using SilvermanGym.Application.Interfaces;

namespace SilvermanGym.Application.Handlers.Queries
{
    public class GetExercisesByWorkoutIdQueryHandler : IRequestHandler<GetExercisesByWorkoutIdQuery,  IEnumerable<WorkoutExerciseDto>>
    {
        public readonly IWorkoutExerciseRepository _wrkexerciseRepository;
        public readonly IWorkoutRepository _workoutRepository;

        public  GetExercisesByWorkoutIdQueryHandler(IWorkoutExerciseRepository wrkexerciseRepository, IWorkoutRepository workoutRepository)
        {
            this._wrkexerciseRepository = wrkexerciseRepository;
            this._workoutRepository = workoutRepository;
        }

        public async Task<IEnumerable<WorkoutExerciseDto>> Handle(GetExercisesByWorkoutIdQuery request, CancellationToken cancellationToken)
        {
            var wrkEntity = await _workoutRepository.CheckIfWorkoutExists(request.WrkId, cancellationToken);

            if(wrkEntity)
            {
                var wrkexcEnity = await _wrkexerciseRepository.GetAllWorkoutExercises(request.WrkId, cancellationToken);

                if(wrkexcEnity.Count == 0)
                {
                    throw new NotFoundException($"There is no exercises in this workout");
                }
                else
                {
                    var workoutexercises = wrkexcEnity
                        .Select(wrkexc => new WorkoutExerciseDto
                        (
                            wrkexc.Id,
                            new ExerciseDto
                            (
                                wrkexc.Exercise.Id,
                                wrkexc.Exercise.Name,
                                wrkexc.Exercise.ExerciseEquipment,
                                wrkexc.Exercise.ExerciseType,
                                wrkexc.Exercise.Description
                            ),
                            wrkexc.Reps,
                            wrkexc.Weight
                        ));
                    return workoutexercises;
                }
            }
            else
            {
                throw new NotFoundException($"The workout with the Id = {request.WrkId} could not be found.");
            }
        }
    }
}