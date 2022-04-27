using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Models.DataBase;
using TaskPlanner2.Models.Repositories;

namespace TaskPlanner2.Services
{
    public class UnitOfWork
    {
        private TaskPlannerContext dbContext { get; init; }
        public UnitOfWork(TaskPlannerContext context)
        {
            dbContext = context;
        }

        public void SaveChanges() => dbContext.SaveChanges();

        // Users 
        private UserRepository _userRepository;
        public UserRepository Users
        {
            get {
                if (_userRepository == null)
                    _userRepository = new UserRepository(dbContext);
                return _userRepository;
            }
        }

        // Roles 
        private RoleRepository _roleRepository;
        public RoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(dbContext);
                return _roleRepository;
            }
        }

        // Tasks 
        private TaskRepository _taskRepository;
        public TaskRepository Tasks
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(dbContext);
                return _taskRepository;
            }
        }

        // SubTasks 
        private SubTaskRepository _subTaskRepository;
        public SubTaskRepository subTasks
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
