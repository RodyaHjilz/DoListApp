using DoListApp.DAL.Data;
using DoListApp.DAL.Repositories;
using DoListApp.Domain.Entity;
using DoListApp.Models;
using DoListApp.Services.Implementations;
using DoListApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DoListApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISimpleTaskService _taskService;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, ISimpleTaskService taskService,
                              IUserService userService)
        {
            _logger = logger;
            _taskService = taskService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var curUser = _userService.GetUser(User);
            var tasks = _taskService.GetAll(curUser.Id);
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View("Create", _taskService.Get(id));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}