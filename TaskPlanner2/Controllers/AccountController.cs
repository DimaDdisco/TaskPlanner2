using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using TaskPlanner2.Services.Abstract;
using TaskPlanner2.Models.ViewModel;
using TaskPlanner2.Models.DataBase;

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
        [Authorize]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Logout(bool? exit)
        {
            Authenticator.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userView)
        {
            if(ModelState.IsValid)
            {
                User checkIfExist = await DataBase.Users.GetWithEmail(userView.Email);
                if(checkIfExist != null && checkIfExist.Password == userView.Password)
                {
                    Authenticator.Authenticate(checkIfExist);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong password or email");
            }

            return View(userView);
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
                
                if (checkIfExist.Login == userView.Login) ModelState.AddModelError("", "Login already existed");
                else if (checkIfExist.Mail == userView.Email) ModelState.AddModelError("", "Email already registered");
            }

            return View(userView);
        }
    }
}
