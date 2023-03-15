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
        public GroupService(IBaseRepository<UserGroup> repository,
                            IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task CreateGroup(UserGroup group)
        {
            await _repository.Create(group);
        }

        public Task DeleteGroup(UserGroup group)
        {
            throw new NotImplementedException();
        }

        //public UserGroup GetUserGroup(ClaimsPrincipal User)
        //{

        //}

        public Task UpdateGroup(UserGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
