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
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, WorkoutDto>
    {

        public readonly IWorkoutRepository _workoutRepository;
        public readonly IUserRepository _userRepository;

        public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IUserRepository userRepository)
        {
            _workoutRepository = workoutRepository;
            _userRepository = userRepository;
        }
        public async Task<WorkoutDto> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CheckIfUserExists(request.UserId,cancellationToken);

            if(user)
            {
                var newWorkout = new Workout
                (
                    Guid.NewGuid(),
                    request.Name,
                    request.WorkoutDate,
                    request.UserId
                );

                await _workoutRepository.CreateWorkout(newWorkout,cancellationToken);

                return new WorkoutDto
                    (
                        newWorkout.Id,
                        newWorkout.Name,
                        newWorkout.WorkoutDate,
                        newWorkout.UserId
                    );
            }
            else
            {
                 var failure = new ValidationFailure
                (
                    nameof(request.UserId),
                    $"The user with userId = {request.UserId} does not exits"
                );
                throw new FluentValidation.ValidationException(new[] { failure });
            }
        }
    }
}