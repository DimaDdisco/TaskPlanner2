using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Models.Repositories;

namespace TaskPlanner2.Services.Abstract
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        public UserRepository Users { get; }
        public RoleRepository Roles { get; }
        public TaskRepository Tasks { get; }
        public SubTaskRepository SubTasks { get; }
    }
}
