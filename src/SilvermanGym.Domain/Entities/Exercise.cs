using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Enum;
using Ardalis.GuardClauses;


namespace SilvermanGym.Domain.Entities
{
    public class Exercise
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public ExerciseEquipment ExerciseEquipment { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public string Description { get; set; }

        //Navigational Properties
        public ICollection<Workout> Workouts { get; set; }
        
        public Exercise(Guid Id, string Name, ExerciseEquipment exerciseEquipment, 
                        ExerciseType exerciseType, string Description)
        {
            this.Id = Id;
            this.ExerciseEquipment = Guard.Against.Null(exerciseEquipment, nameof(exerciseEquipment));
            this.Name = Guard.Against.NullOrEmpty(Name, nameof(Name));
            this.ExerciseType = Guard.Against.Null(exerciseType, nameof(exerciseType));
            this.Description = Guard.Against.NullOrEmpty(Description, nameof(Description));;
        }
    }
}