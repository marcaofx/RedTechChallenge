using RedTechnologies.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTechnologies.Repository.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(User user);
        Task<bool> CreateAsync(User user);

    }
}
