using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Models.DataBase;
using TaskPlanner2.Models.Repositories;
using TaskPlanner2.Services.Abstract;

namespace TaskPlanner2.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskPlannerContext dbContext { get; init; }
        public UnitOfWork(TaskPlannerContext context)
        {
            dbContext = context;
        }

        public void SaveChanges() => dbContext.SaveChanges();

        // Users 
        protected UserRepository _userRepository;
        public virtual UserRepository Users
        {
            get {
                if (_userRepository == null)
                    _userRepository = new UserRepository(dbContext);
                return _userRepository;
            }
        }

        // Roles 
        protected RoleRepository _roleRepository;
        public virtual RoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(dbContext);
                return _roleRepository;
            }
        }

        // Tasks 
        protected TaskRepository _taskRepository;
        public virtual TaskRepository Tasks
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(dbContext);
                return _taskRepository;
            }
        }

        // SubTasks 
        protected SubTaskRepository _subTaskRepository;
        public virtual SubTaskRepository SubTasks
        {
            get
            {
                if (_subTaskRepository == null)
                    _subTaskRepository = new SubTaskRepository(dbContext);
                return _subTaskRepository;
            }
        }
    }
}
