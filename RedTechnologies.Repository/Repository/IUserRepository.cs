using RedTechnologies.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTechnologies.Repository.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserAsync(User user);
        Task<bool> CreateAsync(User user);
        Task<bool> DeleteAsync(Guid id);

    }
}
