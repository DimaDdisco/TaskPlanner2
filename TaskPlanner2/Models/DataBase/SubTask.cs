using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner2.Models.DataBase
{
    public class SubTask
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ToDoTask Task { get; set; }
    }
}
