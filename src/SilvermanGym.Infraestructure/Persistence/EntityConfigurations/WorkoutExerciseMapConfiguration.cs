using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Infraestructure.Persistence.EntityConfigurations;

    public class WorkoutExerciseMapConfiguration : IEntityTypeConfiguration<WorkoutExercisesMap>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercisesMap> builder)
        {
            builder.ToTable("WORKOUT_EXERCISES");

            builder.HasKey(workexc => workexc.Id);

            builder.HasOne(workexc => workexc.Exercise)
                .WithMany(exc => exc.Workouts)
                .HasForeignKey(workexc => workexc.ExerciseId)
                .IsRequired();

             builder.HasOne(workexc => workexc.Workout)
                .WithMany(wrk => wrk.Exercises)
                .HasForeignKey(workexc => workexc.WorkoutId)
                .IsRequired();

            builder.Property(wrkexc => wrkexc.Reps)
                .IsRequired();

            builder.Property(wrkexc => wrkexc.Weight)
                .IsRequired();
        }
    }
