using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries;

namespace SilvermanGym.API.Controllers
{
    public class ExercisesController : ApiController
    { 
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetAllExercises(CancellationToken ct)
        {
            var exercises = await this.Mediator.Send(new GetAllExercisesQuery(), ct);
            
            if(exercises is null)
                return NotFound();
            
            return Ok(exercises);
        }
    }
}