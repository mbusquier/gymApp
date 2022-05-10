using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SilvermanGym.Application.Contracts.Commands;

    public record CreateWorkoutCommand(string Name, DateTime WorkoutDate);
    public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
    {
        public CreateWorkoutCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotNull()
                .WithMessage("Name is required.")
                .NotEmpty()
                .WithMessage("Name cant be empty");

            RuleFor(command => command.WorkoutDate.Year)
                .GreaterThan(2000)
                .WithMessage("Start date cannot be lower that 2020-01-01.");
        }
    }
