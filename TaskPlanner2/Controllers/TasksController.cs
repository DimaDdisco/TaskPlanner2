﻿using System;
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
        public async Task<IActionResult> AddTask(ToDoTaskViewModel taskView)
        {
            if (ModelState.IsValid)
            {
                User CurrentUser = await DataBase.Users.Get(taskView.UserId);
                if(CurrentUser is not null)
                {
                    ToDoTask toAdd = taskView.ToTask();
                    toAdd.User = CurrentUser;

                    DataBase.Tasks.Create(toAdd);
                    DataBase.SaveChanges();
                }
            }

            return RedirectToAction("TaskList");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddSubTask(SubTaskViewModel subTaskView)
        {
            if (ModelState.IsValid)
            {
                ToDoTask CurrentToDoTask = await DataBase.Tasks.Get(subTaskView.TaskId);
                if (CurrentToDoTask is not null)
                {
                    SubTask toAdd = subTaskView.ToSubTask();
                    toAdd.Task = CurrentToDoTask;

                    DataBase.SubTasks.Create(toAdd);
                    DataBase.SaveChanges();
                }
            }

            return RedirectToAction("TaskList");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeTask(ToDoTaskViewModel taskView)
        {
            if (ModelState.IsValid)
            {
                ToDoTask task = await DataBase.Tasks.Get(taskView.TaskId);
                if(task is not null)
                {
                    if(task.Title != taskView.Title || task.Description != taskView.Description)
                    {
                        task.Title = taskView.Title;
                        task.Description = taskView.Description;
                        DataBase.Tasks.Update(task);
                        DataBase.SaveChanges();
                    }
                }
            }

            return RedirectToAction("TaskList");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteTask(ToDoTaskViewModel taskView)
        {
            if (ModelState.IsValid)
            {
                ToDoTask task = await DataBase.Tasks.Get(taskView.TaskId);
                if (task is not null)
                {
                    DataBase.Tasks.Delete(task);
                    DataBase.SaveChanges();
                }
            }

            return RedirectToAction("TaskList");
        }
    }
}
