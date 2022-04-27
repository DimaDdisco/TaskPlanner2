using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner2.Models.DataBase
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }

        public List<ToDoTask> Tasks { get; set; }

        public User()
        {
            Tasks = new List<ToDoTask>();
        }
    }
}
