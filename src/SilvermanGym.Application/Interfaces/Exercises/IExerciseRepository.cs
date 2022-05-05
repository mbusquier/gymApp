using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Interfaces;

    public interface IExerciseRepository
    {
        public Task<List<Exercise>> GetAllExercises(CancellationToken ct);
    }
