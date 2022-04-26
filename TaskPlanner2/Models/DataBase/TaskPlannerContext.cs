using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner2.Models.DataBase
{
    public class TaskPlannerContext : DbContext
    {

        public TaskPlannerContext(DbContextOptions<TaskPlannerContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
