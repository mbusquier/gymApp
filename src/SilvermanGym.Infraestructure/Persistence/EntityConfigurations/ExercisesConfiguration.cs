using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Infraestructure.Persistence.EntityConfigurations
{
    public class ExercisesConfiguration :  IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("EXERCISES");

            builder.HasKey(exc => exc.Id);
            builder.Property(exc => exc.Id).ValueGeneratedNever();

            builder.Property(exc => exc.Name)
                .HasColumnType("varchar(70)")
                .IsRequired();

            builder.Property(exc => exc.ExerciseType)
                .IsRequired();

            builder.Property(exc => exc.ExerciseEquipment)
                .IsRequired();

            builder.Property(exc => exc.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}