using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Infraestructure.Persistence.EntityConfigurations
{
    public class WorkoutExerciseMapConfiguration : IEntityTypeConfiguration<WorkoutExercisesMap>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercisesMap> builder)
        {
            builder.ToTable("WORKOUT_EXERCISES");

            builder.HasKey(exc => new { exc.ExerciseId , exc.WorkoutId});

            builder.Property(exc => exc.WorkoutId).ValueGeneratedNever();
            builder.Property(exc => exc.ExerciseId).ValueGeneratedNever();
        }
    }
}