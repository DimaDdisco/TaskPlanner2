using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Services;
using TaskPlanner2.Models.ViewModel;

namespace TaskPlanner2.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork DataBase { get; set; }
        public AccountController(UnitOfWork dataBase)
        {
            DataBase = dataBase;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel user)
        {
            return View();
        }
    }
}
