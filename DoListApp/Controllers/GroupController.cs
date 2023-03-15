using DoListApp.Domain.Entity;
using DoListApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoListApp.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        public GroupController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateGroup");
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            var group = new UserGroup()
            {
                Name = name
            };
            _groupService.CreateGroup(group);
            _userService.JoinGroup(group, _userService.GetUser(User));

            return RedirectToAction("Index");
        }

        

        public IActionResult Join()
        {
            //var group = _groupService.GetUserGroup(User);
            //Console.WriteLine(group.Id);
            return View("Index");
        }


    }
}