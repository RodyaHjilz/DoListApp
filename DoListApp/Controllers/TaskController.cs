using DoListApp.Domain.Entity;
using DoListApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoListApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ISimpleTaskService _taskService;
        private readonly IUserService _userService;
        public TaskController(ISimpleTaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateOrUpdate(string name, string description, int id)
        {
            // Если id == 0, значит мы создаем новый таск, а иначе - изменяем существующий.
            var task = new SimpleTask()
            {   
                Id = id == 0? null : id,
                Description = description,
                Name = name,
                Date = DateTime.Now,
                User = _userService.GetUser(User)
            };
            if (id == 0)
                _taskService.CreateTask(task);
            else
                _taskService.Edit(task);
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update()
        {


            return View();
        }

    }
}
