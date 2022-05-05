using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SilvermanGym.Infraestructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilvermanGym.Infraestructure.Persistence.Repositories;
using SilvermanGym.Application.Interfaces;

namespace SilvermanGym.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                config.GetConnectionString("PG_CONN_STR"),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
            ));

            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();

            return services;
        }
    }
}