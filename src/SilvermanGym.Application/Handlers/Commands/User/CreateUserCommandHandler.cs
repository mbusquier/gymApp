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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        public readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExits = await _userRepository.ChecUsername(request.Username,cancellationToken);

            if(userExits)
            {
                var failure = new ValidationFailure
                (
                    nameof(request.Username),
                    $"The user with username = {request.Username} already exits"
                );
                throw new FluentValidation.ValidationException(new[] { failure });
            }
            else
            {
                var newUser = new User
                (
                    Guid.NewGuid(),
                    request.Username,
                    request.Age,
                    request.Height,
                    request.Weight
                );

                await _userRepository.CreateUser(newUser,cancellationToken);

                return new UserDto
                    (
                        newUser.Id,
                        newUser.Username,
                        newUser.Age,
                        newUser.Height,
                        newUser.Weight,
                        newUser.IMC
                    );
            }
        }
    }
}