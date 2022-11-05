using Microsoft.EntityFrameworkCore;
using RedTechnologies.Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RedTechnologies.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
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
    }
}

