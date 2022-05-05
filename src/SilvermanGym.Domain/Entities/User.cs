using System;
using Ardalis.GuardClauses;

namespace SilvermanGym.Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public string Username { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float IMC { get; set; }

        //Navigational Properties
        public ICollection<Workout> Workouts { get; set; }

        public User(Guid Id, string Username, int Age, float Height, float Weight)
        {
            this.Id = Id;
            this.Username = Guard.Against.NullOrEmpty(Username, nameof(Username));
            this.Age = Guard.Against.NegativeOrZero(Age, nameof(Age));
            this.Height = Guard.Against.NegativeOrZero(Height, nameof(Height)) ;
            this.Weight = Guard.Against.NegativeOrZero(Weight, nameof(Weight));
            var IMCValue = Weight / Math.Pow(Height,2);
            this.IMC = (float)IMCValue;
        }
        
    }
}