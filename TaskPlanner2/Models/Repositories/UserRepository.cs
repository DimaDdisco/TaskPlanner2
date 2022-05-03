using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        // ctor
        private TaskPlannerContext dbContext { get; init; }
        public UserRepository(TaskPlannerContext context)
        {
            dbContext = context;
        }

        // get one with id
        public async Task<User> Get(int id)
        {
            return await dbContext.Users
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        // get user with email or login
        public async Task<User> Get(string Login, string Email)
        {
            return await dbContext.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Login == Login || user.Mail == Email);
        }

        // get user with email
        public async Task<User> GetWithEmail(string Email)
        {
            return await dbContext.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user =>  user.Mail == Email);
        }

        // get user with login
        public async Task<User> GetWithLogin(string Login)
        {
            return await dbContext.Users
                .Include(user => user.Role)
                .Include(user => user.Tasks)
                .FirstOrDefaultAsync(user => user.Login == Login);
        }

        // get all
        public async Task<IEnumerable<User>> GetAll()
        {
            return await dbContext.Users.ToListAsync();
        }

        // add new one
        public async void Create(User item)
        {
            await dbContext.Users.AddAsync(item);
        }

        // delete existing
        public async void Delete(int id)
        {
            User toDelete = await dbContext.Users.FirstOrDefaultAsync(item => item.Id == id);
            if(toDelete != null)
            {
                dbContext.Users.Remove(toDelete);
            }
        }

        // update existing
        public void Update(User item)
        {
            dbContext.Users.Update(item);
        }
    }
}
