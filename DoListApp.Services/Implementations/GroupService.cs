using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using DoListApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IBaseRepository<UserGroup> _repository;
        private readonly IUserService _userService;
        private readonly ISimpleTaskService _taskService;
        public GroupService(IBaseRepository<UserGroup> repository,
                            IUserService userService,
                            ISimpleTaskService taskService)
        {
            _repository = repository;
            _userService = userService;
            _taskService = taskService;
        }

        public async Task CreateGroup(UserGroup group)
        {
            await _repository.Create(group);
        }

        public Task DeleteGroup(UserGroup group)
        {
            throw new NotImplementedException();
        }

        public UserGroup? GetGroup(Guid id)
        {
            var item = _repository.GetAll().FirstOrDefault(e => e.Id == id);

            return item;
        }

        public Task UpdateGroup(UserGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
