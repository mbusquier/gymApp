using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilvermanGym.Application.Interfaces;
using SilvermanGym.Domain.Entities;
using SilvermanGym.Infraestructure.Persistence.DbContexts;

namespace SilvermanGym.Infraestructure.Persistence.Repositories
{
    public class WorkoutExerciseRepository : IWorkoutExerciseRepository
    {
        private readonly AppDbContext context;

        public WorkoutExerciseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<WorkoutExercisesMap>> GetAllWorkoutExercises(Guid WorkId, CancellationToken ct)
        {
            return context.WorkoutExercises
                .AsNoTracking()
                .Where(wrk => wrk.WorkoutId == WorkId)
                .Include(wrk => wrk.Exercise)
                .ToListAsync(ct);
        }
    }
}