using DoListApp.Domain.Entity;
using DoListApp.Domain.ViewModels;
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
        private readonly ISimpleTaskService _taskService;
        public GroupController(IGroupService groupService, 
                               IUserService userService,
                               ISimpleTaskService taskService)
        {
            _groupService = groupService;
            _userService = userService;
            _taskService = taskService;
        }

        public IActionResult LeftGroup()
        {
            var curUser = _userService.GetUser(User);
            _userService.LeftGroup(curUser);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var curUser = _userService.GetUser(User);
            IEnumerable<SimpleTask> tasks = null;
            if (curUser.UserGroup != null)
            {
                tasks = _taskService.GetGroupTask(curUser.UserGroup.Id);
            }
            var model = new GroupTasksViewModel { task = tasks, group = curUser.UserGroup };
            return View(model);

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
            _userService.JoinGroup(group, _userService.GetUser(User), true);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Join()
        {

            return View("JoinGroup");
        }
        [HttpPost]
        public IActionResult Join(UserGroup groupModel)
        {
            var group = _groupService.GetGroup(groupModel.Id);
            if(group != null)
                _userService.JoinGroup(group, _userService.GetUser(User), false);



            return RedirectToAction("Index");
        }

    }
}