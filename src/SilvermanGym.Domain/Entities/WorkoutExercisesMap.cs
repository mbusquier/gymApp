using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace SilvermanGym.Domain.Entities
{
    public class WorkoutExercisesMap
    {
        public Guid Id { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid WorkoutId { get; set; }
        public float Weight { get; set; }
        public int Reps { get; set; }

        //Navigational Properties

        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }

        public WorkoutExercisesMap(Guid Id, Guid WorkoutId, Guid ExerciseId, int Reps, float Weight)
        {
            this.Id = Guard.Against.NullOrEmpty(Id,nameof(Id));
            this.ExerciseId = Guard.Against.NullOrEmpty(ExerciseId,nameof(ExerciseId));
            this.WorkoutId = Guard.Against.NullOrEmpty(WorkoutId,nameof(WorkoutId));
            this.Reps = Guard.Against.NegativeOrZero(Reps,nameof(Reps));
            this.Weight = Guard.Against.NegativeOrZero(Weight,nameof(Weight));
        }
    }
}