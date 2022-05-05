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
}
