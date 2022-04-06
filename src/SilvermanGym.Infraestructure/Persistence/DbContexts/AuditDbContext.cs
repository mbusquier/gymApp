using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SilvermanGym.Infraestructure.Persistence.DbContexts
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions options) : base(options) { }

        // Add more entities here

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("audit");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}