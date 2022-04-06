using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SilvermanGym.Domain.Enum;
using MediatR;

namespace SilvermanGym.Application.Contracts.Commands
{
    public record CreateExerciseCommand(Guid Id, string Name, ExerciseEquipment ExerciseEquipment, 
    ExerciseType ExerciseType, string Description);

    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotNull()
                .WithMessage("Name is required.")
                .NotEmpty();

            RuleFor(command => command.ExerciseEquipment)
                .NotNull()
                .WithMessage("Exercise equipment required");

            RuleFor(command => command.ExerciseType)
                .NotNull()
                .WithMessage("Exercise type required");

            RuleFor(command => command.Description)
                .NotNull()
                .WithMessage("Description is required.")
                .NotEmpty();
        }
    }
}