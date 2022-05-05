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
    public class GetWorkoutByIdQueryHandler : IRequestHandler<GetWorkoutByIdQuery, WorkoutDto>
    {
        
        public readonly IWorkoutRepository _workoutRepository;

        public GetWorkoutByIdQueryHandler(IWorkoutRepository workoutRepository)
        {
            this._workoutRepository = workoutRepository;
        }

        public async Task<WorkoutDto> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
        {
            var workEntity = await _workoutRepository.GetWorkoutById(request.Id, cancellationToken);

            if (workEntity is null)
            {
                throw new NotFoundException($"The workout with the Id = {request.Id} could not be found.");
            }
            
            var workout = new WorkoutDto(
                workEntity.Id,
                workEntity.Name,
                workEntity.WorkoutDate
            );

            return workout;
        }
    }
}