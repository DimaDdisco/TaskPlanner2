using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Services.Abstract;

namespace TaskPlanner2.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork DataBase { get; set; }
        public HomeController(IUnitOfWork dataBase)
        {
            DataBase = dataBase;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
