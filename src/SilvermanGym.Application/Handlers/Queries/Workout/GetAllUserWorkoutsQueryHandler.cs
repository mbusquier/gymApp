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
    public class GetAllWorkoutsQueryHandler : IRequestHandler<GetAllUserWorkoutsQuery, IEnumerable<WorkoutDto>>
    {
        public readonly IWorkoutRepository _workoutRepository;
        public readonly IUserRepository _userRepository;

        public GetAllWorkoutsQueryHandler(IWorkoutRepository workoutRepository, IUserRepository userRepository)
        {
            this._workoutRepository = workoutRepository;
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<WorkoutDto>> Handle(GetAllUserWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CheckIfUserExists(request.Id, cancellationToken);

            if(user)
            {
                var workEntities = await _workoutRepository.GetAllUserWorkouts(request.Id, cancellationToken);
                if(workEntities.Count == 0)
                {
                    throw new NotFoundException($"The user with the Id = {request.Id} doesnt has workouts");
                }
                else
                {
                    var workouts = workEntities
                    .Select(wkr => new WorkoutDto
                    (
                        wkr.Id,
                        wkr.Name,
                        wkr.WorkoutDate
                    ));
                    return workouts;
                }      
            }
            else
            {
                throw new NotFoundException($"The user with the Id = {request.Id} could not be found.");
            }
        }
    }
}