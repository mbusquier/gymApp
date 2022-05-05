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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        public readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetAllUsers(cancellationToken);

            if(userEntity.Count == 0)
            {
                throw new NotFoundException($"There is no users in the database");
            }
            else
            {
                var users = userEntity
                .Select(usr => new UserDto
                (
                    usr.Id,
                    usr.Username,
                    usr.Age,
                    usr.Height,
                    usr.Weight,
                    usr.IMC
                ));
            
                return users;
            }
            
        }
    }
}