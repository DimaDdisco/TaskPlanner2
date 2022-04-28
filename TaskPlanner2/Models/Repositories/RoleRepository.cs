using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        // ctor
        private TaskPlannerContext dbContext { get; init; }
        public RoleRepository(TaskPlannerContext context)
        {
            dbContext = context;
        }

        // get one with id
        public async Task<Role> Get(int id)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(item => item.Id == id);
        }

        // get actual role
        public async Task<Role> Get(Roles role)
        {
            string roleString = role.ToString();
            return await dbContext.Roles.FirstOrDefaultAsync(item => item.Name == roleString);
        }

        // get all
        public async Task<IEnumerable<Role>> GetAll()
        {
            return await dbContext.Roles.ToListAsync();
        }

        // add new one
        public async void Create(Role item)
        {
            await dbContext.Roles.AddAsync(item);
        }

        // delete existing
        public async void Delete(int id)
        {
            Role toDelete = await dbContext.Roles.FirstOrDefaultAsync(item => item.Id == id);
            if (toDelete != null)
            {
                dbContext.Roles.Remove(toDelete);
            }
        }

        // update existing
        public void Update(Role item)
        {
            dbContext.Roles.Update(item);
        }
    }
}
