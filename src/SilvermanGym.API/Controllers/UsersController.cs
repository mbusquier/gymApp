using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SilvermanGym.Application.Contracts;
using SilvermanGym.Application.Contracts.Commands;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries;

namespace SilvermanGym.API.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(CancellationToken ct)
        {
            var users = await this.Mediator.Send(new GetAllUsersQuery(), ct);

            if(users is null)
                return NotFound();
            
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id,CancellationToken ct)
        {
            var user = await this.Mediator.Send(new GetUserByIdQuery(id), ct);
            
            if(user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserCommand request, CancellationToken ct)
        {
            var newUser = await this.Mediator.Send(request, ct);
        
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.id }, newUser);
        }
    }
}