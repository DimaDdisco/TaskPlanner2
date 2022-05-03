using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using TaskPlanner2.Services.Abstract;
using TaskPlanner2.Models.DataBase;
using TaskPlanner2.Models.ViewModel;

namespace TaskPlanner2.Controllers
{
    public class TasksController : Controller
    {
        private IUnitOfWork DataBase { get; set; }
        private IAuthentication Authenticator { get; set; }
        public TasksController(IUnitOfWork dataBase, IAuthentication authenticator)
        {
            DataBase = dataBase;
            Authenticator = authenticator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> TaskList()
        {
            string Login = Authenticator.GetLogin();
            User CurrentUser = await DataBase.Users.GetWithLogin(Login);
            return View(CurrentUser);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(ToDoTaskViewModel taskView)
        {
            if (ModelState.IsValid)
            {
                User CurrentUser = await DataBase.Users.Get(taskView.UserId);
                if(CurrentUser != null)
                {
                    ToDoTask toAdd = taskView.ToTask();
                    toAdd.User = CurrentUser;

                    DataBase.Tasks.Create(toAdd);
                    DataBase.SaveChanges();
                }
            }

            return RedirectToAction("TaskList");
        }
    }
}
