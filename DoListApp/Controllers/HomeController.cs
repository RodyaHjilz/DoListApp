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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        //DEBUG
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ISimpleTaskService taskService,
                              UserManager<ApplicationUser> userManager, IUserService userService, ApplicationDbContext context)
        {
            _logger = logger;
            _taskService = taskService;
            _userManager = userManager;
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var id = _userManager.GetUserId(User);
            var curUser = _userService.GetUser(id);
            var tasks = _taskService.GetAll(id);

            var list = _context.SimpleTask.FirstOrDefault(e => e.Id == 3);
            int b = 5;

            return View(tasks);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return Redirect("Index");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}