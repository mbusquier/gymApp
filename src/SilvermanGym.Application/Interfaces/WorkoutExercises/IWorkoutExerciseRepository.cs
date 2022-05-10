using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Interfaces
{
    public interface IWorkoutExerciseRepository
    { 
        public Task<List<WorkoutExercisesMap>> GetAllWorkoutExercises(Guid WorkId, CancellationToken ct);
    }
}