using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Services;

namespace TaskPlanner2.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork DataBase { get; set; }
        public HomeController(UnitOfWork dataBase)
        {
            DataBase = dataBase;
        }

        public IActionResult Index()
        {
            DataBase.Roles.Create(new Models.DataBase.Role { Name = "Guest" });
            DataBase.SaveChanges();
            return View();
        }
    }
}
