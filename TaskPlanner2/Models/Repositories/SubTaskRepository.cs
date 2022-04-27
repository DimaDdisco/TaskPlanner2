using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.Repositories
{
    public class SubTaskRepository : IRepository<SubTask>
    {
        // ctor
        private TaskPlannerContext dbContext { get; init; }
        public SubTaskRepository(TaskPlannerContext context)
        {
            dbContext = context;
        }

        // get one with id
        public async Task<SubTask> Get(int id)
        {
            return await dbContext.SubTasks.FirstOrDefaultAsync(item => item.Id == id);
        }

        // get all
        public async Task<IEnumerable<SubTask>> GetAll()
        {
            return await dbContext.SubTasks.ToListAsync();
        }

        // add new one
        public async void Create(SubTask item)
        {
            await dbContext.SubTasks.AddAsync(item);
        }

        // delete existing
        public async void Delete(int id)
        {
            SubTask toDelete = await dbContext.SubTasks.FirstOrDefaultAsync(item => item.Id == id);
            if (toDelete != null)
            {
                dbContext.SubTasks.Remove(toDelete);
            }
        }

        // update existing
        public void Update(SubTask item)
        {
            dbContext.SubTasks.Update(item);
        }
    }
}
