using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Infraestructure.Persistence.EntityConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");

            builder.HasKey(usr => usr.Id);

            builder.Property(usr => usr.Username)
                .HasColumnType("varchar(70)")
                .IsRequired();

            builder.Property(usr => usr.Age)
                .IsRequired();

            builder.Property(usr => usr.Height)
                .IsRequired();

            builder.Property(usr => usr.Weight)
                .IsRequired();
        }
    }
}