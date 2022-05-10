using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Interfaces;

    public interface IExerciseRepository
    {
        public Task<List<Exercise>> GetAllExercises(CancellationToken ct);

        public Task<Exercise> GetExerciseById(Guid id, CancellationToken ct);

        public Task<bool> CheckIfExerciseExists(Guid Id, CancellationToken ct);
    }
