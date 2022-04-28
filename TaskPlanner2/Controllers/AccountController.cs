using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Services.Abstract;
using TaskPlanner2.Models.ViewModel;
using TaskPlanner2.Models.DataBase;
using System.Security.Principal;

namespace TaskPlanner2.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork DataBase { get; set; }
        private IAuthentication Authenticator { get; set; }
        public AccountController(IUnitOfWork dataBase, IAuthentication authentication)
        {
            DataBase = dataBase;
            Authenticator = authentication;
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
        public async Task<IActionResult> Signup(SignupViewModel userView)
        {
            if (ModelState.IsValid)
            {
                User checkIfExist = await DataBase.Users.Get(userView.Login, userView.Email);
                if(checkIfExist == null)
                {
                    Role userRole = await DataBase.Roles.Get(Models.Roles.CommonUser);
                    if (userRole == null)
                        throw new Exception("Role not found");

                    User toAdd = userView.ToUser();
                    toAdd.Role = userRole;

                    DataBase.Users.Create(toAdd);
                    DataBase.SaveChanges();

                    Authenticator.Authenticate(toAdd);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (checkIfExist.Mail == userView.Email) ModelState.AddModelError("Email", "Email already registered");
                    else if (checkIfExist.Login == userView.Login) ModelState.AddModelError("Login", "Login already existed");
                }

            }

            return View(userView);
        }
    }
}
