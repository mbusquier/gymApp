using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilvermanGym.Application.Interfaces;
using SilvermanGym.Domain.Entities;
using SilvermanGym.Infraestructure.Persistence.DbContexts;

namespace SilvermanGym.Infraestructure.Persistence.Repositories;

    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext context;

        public ExerciseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Exercise>> GetAllExercises(CancellationToken ct)
        {
            return context.Exercises
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public Task<bool> CheckIfExerciseExists(Guid Id, CancellationToken ct)
        {
            return  context.Exercises
                .AsNoTracking()
                .AnyAsync(ex => ex.Id == Id, ct);
        }

        public Task<Exercise> GetExerciseById(Guid id, CancellationToken ct)
        {
            return context.Exercises
                    .AsNoTracking()
                    .SingleOrDefaultAsync(wkt => wkt.Id == id, ct);
        }

        public async Task CreateExercise(Exercise newExercise, CancellationToken ct)
        {
            await context.Exercises.AddAsync(newExercise, ct);
            await context.SaveChangesAsync(ct);
        }

        public Task<bool> CheckExerciseName(string Name, CancellationToken ct)
        {
            return  context.Exercises
                .AsNoTracking()
                .AnyAsync(exc => exc.Name == Name, ct);
        }
}
