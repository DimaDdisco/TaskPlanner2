using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner2.Models.DataBase
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public User User { get; set; }

        public List<SubTask> SubTasks { get; set; }

        public ToDoTask()
        {
            SubTasks = new List<SubTask>();
        }
    }
}
