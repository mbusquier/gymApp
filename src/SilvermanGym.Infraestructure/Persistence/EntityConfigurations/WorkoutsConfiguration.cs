using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Infraestructure.Persistence.EntityConfigurations
{
    public class WorkoutsConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("WORKOUTS");

            builder.HasKey(work => work.Id);

            builder.Property(work => work.Name)
                .HasColumnType("varchar(70)")
                .IsRequired();

            builder.Property(work => work.WorkoutDate)
                .IsRequired();
        }
    }
}