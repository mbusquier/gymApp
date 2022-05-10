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
    public class ExercisesController : ApiController
    {
        [HttpGet("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExerciseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExerciseDto>> GetExerciseById(Guid id,CancellationToken ct)
        {
            var exer = await this.Mediator.Send(new GetExerciseByIdQuery(id), ct);
            
             if(exer is null)
                return NotFound();

            return Ok(exer);
        }

        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<WorkoutExerciseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WorkoutExerciseDto>>> GetExercises([FromQuery] Guid WrkId,CancellationToken ct)
        {
            if(WrkId == Guid.Empty)
            {
                var exercises = await this.Mediator.Send(new GetAllExercisesQuery(), ct);
            
                if(exercises is null)
                    return NotFound();
                
                return Ok(exercises);
            }
            else
            {
                var workoutExercises = await this.Mediator.Send(new GetExercisesByWorkoutIdQuery(WrkId), ct);
                
                if(workoutExercises is null)
                    return NotFound();

                return Ok(workoutExercises);
            }
            
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExerciseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ExerciseDto>> CreateUser(CreateExerciseCommand request, CancellationToken ct)
        {
            var newExercise = await this.Mediator.Send(request, ct);
        
            return CreatedAtAction(nameof(GetExerciseById), new { id = newExercise.Id }, newExercise);
        }
    }
}