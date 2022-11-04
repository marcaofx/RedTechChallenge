using Microsoft.EntityFrameworkCore;
using RedTechnologies.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedTechnologies.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var dbContext = new dbContext())
                return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(User user)
        {
            using (var dbContext = new dbContext())
            {
                var userObj = await dbContext.Users.Where(c => c.UserName == user.UserName && c.Password == user.Password).FirstOrDefaultAsync();

                if (userObj == null)
                    throw new InvalidOperationException("You don't have access!");

                return userObj;

            }
        }

        public async Task<bool> CreateAsync(User user)
        {
            using (var dbContext = new dbContext())
            {
                user.Id = Guid.NewGuid();
                user.CreatedDate = DateTime.UtcNow;
                await dbContext.Users.AddAsync(user);
                return await dbContext.SaveChangesAsync() > 0;
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var dbContext = new dbContext())
            {
                var user = await dbContext.Users.FindAsync(id);
                if (user == null)
                    throw new InvalidOperationException($"The User was not found by Id= {id}.");

                dbContext.Users.Remove(user);
                return await dbContext.SaveChangesAsync() > 0;
            }

        }

    }
}

