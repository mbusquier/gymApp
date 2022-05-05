using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace SilvermanGym.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public DateTime WorkoutDate { get; set; }

        //Navigational Properties
        public User User { get; set; }
        
        public Workout(Guid Id, string Name, DateTime WorkoutDate)
        {
            this.Id = Id;
            this.Name = Guard.Against.NullOrEmpty(Name,nameof(Name));
            this.WorkoutDate = WorkoutDate.ToUniversalTime();
        }
    }
}