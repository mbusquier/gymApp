using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Interfaces
{
    public interface IWorkoutRepository
    {
        public Task<Workout> GetWorkoutById(Guid Id, CancellationToken ct);
        public Task<List<Workout>> GetAllUserWorkouts(Guid Id, CancellationToken ct);

        public Task<bool> CheckIfWorkoutExists(Guid Id, CancellationToken ct);

        public Task CreateWorkout(Workout newWorkout, CancellationToken ct);
        
    }
}