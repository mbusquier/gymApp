using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilvermanGym.Application.Contracts.DTOs;

namespace SilvermanGym.Application.Contracts.Queries.Exercises
{
    public record GetAllExercisesQuery() : IRequest<IEnumerable<ExerciseDto>>;
}