using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.Repositories
{
    public class TaskRepository : IRepository<ToDoTask>
    {
        // ctor
        private TaskPlannerContext dbContext { get; init; }
        public TaskRepository(TaskPlannerContext context)
        {
            dbContext = context;
        }

        // get one with id
        public async Task<ToDoTask> Get(int id)
        {
            return await dbContext.Tasks.FirstOrDefaultAsync(item => item.Id == id);
        }

        // get all
        public async Task<IEnumerable<ToDoTask>> GetAll()
        {
            return await dbContext.Tasks.ToListAsync();
        }

        // add new one
        public async void Create(ToDoTask item)
        {
            await dbContext.Tasks.AddAsync(item);
        }

        // delete existing
        public async void Delete(int id)
        {
            ToDoTask toDelete = await dbContext.Tasks.FirstOrDefaultAsync(item => item.Id == id);
            if (toDelete != null)
            {
                dbContext.Tasks.Remove(toDelete);
            }
        }

        // update existing
        public void Update(ToDoTask item)
        {
            dbContext.Tasks.Update(item);
        }
    }
}
