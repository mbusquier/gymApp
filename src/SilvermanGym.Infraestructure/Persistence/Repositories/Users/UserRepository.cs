using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilvermanGym.Application.Interfaces;
using SilvermanGym.Domain.Entities;
using SilvermanGym.Infraestructure.Persistence.DbContexts;

namespace SilvermanGym.Infraestructure.Persistence.Repositories;

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckIfUserExists(Guid Id, CancellationToken ct)
        {
            return  context.Users
                .AsNoTracking()
                .AnyAsync(usr => usr.Id == Id, ct);
        }
        public Task<List<User>> GetAllUsers(CancellationToken ct)
        {
            return context.Users
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public Task<User> GetUserById(Guid Id, CancellationToken ct)
        {
            return context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(usr => usr.Id == Id, ct);
        }
    }
