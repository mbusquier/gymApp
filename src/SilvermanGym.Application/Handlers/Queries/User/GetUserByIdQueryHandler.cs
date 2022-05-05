using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries;
using SilvermanGym.Application.Exceptions;
using SilvermanGym.Application.Interfaces;

namespace SilvermanGym.Application.Handlers.Queries.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {

        public readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUserById(request.Id,cancellationToken);

            if(userEntity is null)
            {
                throw new NotFoundException($"The user with the Id = {request.Id} could not be found.");
            }
            else
            {
                var user = new UserDto(
                    userEntity.Id,
                    userEntity.Username,
                    userEntity.Age,
                    userEntity.Height,
                    userEntity.Weight,
                    userEntity.IMC
                );
            
                return user;
            }
        }
    }
}