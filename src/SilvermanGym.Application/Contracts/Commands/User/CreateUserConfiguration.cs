using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SilvermanGym.Application.Contracts.Commands;

    public record CreateUserCommand(Guid id, string Username, int Age, float Height, float Weight);
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.Username)
                .NotNull()
                .WithMessage("Username is required.")
                .NotEmpty()
                .WithMessage("Username cant be empty");

            RuleFor(command => command.Age)
                .GreaterThan(15)
                .WithMessage("Age must be at least 16");
            
            RuleFor(command => command.Weight)
                .GreaterThan(0)
                .WithMessage("Weight cant be 0 or less");

            RuleFor(command => command.Height)
                .GreaterThan(0)
                .WithMessage("Height cant be 0 or less");
        }
    }