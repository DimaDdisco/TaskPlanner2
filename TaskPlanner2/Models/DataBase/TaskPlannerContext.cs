using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner2.Models.DataBase
{
    public class TaskPlannerContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ToDoTask> Tasks { get; set; }
        public virtual DbSet<SubTask> SubTasks { get; set; }

        public TaskPlannerContext(DbContextOptions<TaskPlannerContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role {Id = 1, Name = "Admin"},
                new Role {Id = 2, Name = "BasicUser"}
            });
        }
    }
}
