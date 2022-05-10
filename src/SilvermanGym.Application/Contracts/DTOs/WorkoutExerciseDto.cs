using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Contracts.DTOs
{
    public record WorkoutExerciseDto(Guid Id, ExerciseDto Exercise, int Reps, float Weight);
}