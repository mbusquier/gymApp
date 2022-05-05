using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace SilvermanGym.Domain.Entities
{
    public class ExerciseWorkoutMap
    {
        public Guid ExerciseId { get; set; }
        public Guid WorkoutId { get; set; }

        //Navigational Properties

        public Workout Workout {get; set; }
        public Exercise Exercise { get; set; }

        private ExerciseWorkoutMap(Guid ExerciseId, Guid WorkoutId)
        {
            this.ExerciseId = Guard.Against.NullOrEmpty(ExerciseId,nameof(ExerciseId));
            this.WorkoutId = Guard.Against.NullOrEmpty(WorkoutId,nameof(WorkoutId));
        }
    }
}