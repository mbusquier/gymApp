using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SilvermanGym.Application.Contracts.Commands
{
    public record CreateWorkoutExerciseCommand(Guid WorkId, Guid ExId, int Reps, float Weight);
    public class CreateWorkoutExerciseCommandValidator : AbstractValidator<CreateWorkoutExerciseCommand>
    {
        public CreateWorkoutExerciseCommandValidator()
        {
            RuleFor(command => command.WorkId)
                .NotEmpty()
                .WithMessage("Workout id cant be null");

            RuleFor(command => command.ExId)
                .NotEmpty()
                .WithMessage("Exercise id cant be null");

            RuleFor(command => command.Reps)
                .GreaterThan(0)
                .WithMessage("Reps cant be 0 or less")
                .NotNull()
                .WithMessage("Reps is required");

            RuleFor(command => command.Weight)
                .GreaterThan(0)
                .WithMessage("Weight cant be 0 or less")
                .NotNull()
                .WithMessage("Weight is required");  
        }
    }
    
}