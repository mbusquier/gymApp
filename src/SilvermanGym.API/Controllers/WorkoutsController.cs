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
    public class WorkoutsController : ApiController
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<WorkoutDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetAllUserWorkouts([FromQuery]Guid UserId, CancellationToken ct)
        {
            var userWorkouts = await this.Mediator.Send(new GetAllUserWorkoutsQuery(UserId), ct);

            if(userWorkouts is null)
                return NotFound();
            
            return Ok(userWorkouts);
        }

        [HttpGet("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WorkoutDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkoutDto>> GetWorkoutById(Guid id,CancellationToken ct)
        {
            var workout = await this.Mediator.Send(new GetWorkoutByIdQuery(id), ct);
            
             if(workout is null)
                return NotFound();

            return Ok(workout);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WorkoutDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkoutDto>> SaveUserWorkout(CreateWorkoutCommand request,CancellationToken ct)
        {
            var newWorkout = await this.Mediator.Send(request, ct);

            return CreatedAtAction(nameof(GetWorkoutById), new { id = newWorkout.id }, newWorkout);
        }
    }
}