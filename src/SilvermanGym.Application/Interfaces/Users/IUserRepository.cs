using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Entities;

namespace SilvermanGym.Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers(CancellationToken ct);
        public Task<User> GetUserById(Guid Id, CancellationToken ct); 
        public Task<bool> CheckIfUserExists(Guid Id, CancellationToken ct);
        public Task<bool> ChecUsername(string Username, CancellationToken ct);
        public Task CreateUser(User newUser, CancellationToken ct);
    }
}