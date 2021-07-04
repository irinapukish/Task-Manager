using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    
    public class TaskController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITaskRepository _taskRepository;
  
        public TaskController(ITaskRepository taskRepository, UserManager<ApplicationUser> userManager)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
        }

        [Authorize]
        // GET: Task
        public ActionResult TaskHome()
        {
            var userId = _userManager.GetUserId(User);
            return View(_taskRepository.GetAllActive(userId));
        }
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepository.Get(id));
        }

        [Authorize]
        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            var userId = _userManager.GetUserId(User);
            taskModel.UserId = userId;

            _taskRepository.Add(taskModel);
            
            return RedirectToAction(nameof(TaskHome));
        }
        [Authorize]
        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepository.Get(id));
        }
        [Authorize]
        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }
        [Authorize]
        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        //GET: Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task =_taskRepository.Get(id);
            task.Done = true;
            _taskRepository.Update(id, task);
            return RedirectToAction(nameof(Index));
        }
    }
}
