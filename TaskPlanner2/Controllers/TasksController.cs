using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace TaskPlanner2.Controllers
{
    public class TasksController : Controller
    {
        [HttpGet]
        public IActionResult TaskList()
        {
            return View();
        }
    }
}
