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
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext context;

        public WorkoutRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Workout>> GetAllUserWorkouts(Guid Id, CancellationToken ct)
        {
            return context.Workouts
                .AsNoTracking()
                .Where(wrk => wrk.UserId == Id)
                .ToListAsync(ct);
        }

        public Task<Workout> GetWorkoutById(Guid Id, CancellationToken ct)
        {
            return context.Workouts
                .AsNoTracking()
                .SingleOrDefaultAsync(wkt => wkt.Id == Id, ct);
        }

        public Task<bool> CheckIfWorkoutExists(Guid Id, CancellationToken ct)
        {
            return  context.Workouts
                .AsNoTracking()
                .AnyAsync(wrk => wrk.Id == Id, ct);
        }
    }
}