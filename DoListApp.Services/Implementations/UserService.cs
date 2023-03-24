using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using DoListApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<ApplicationUser> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IBaseRepository<ApplicationUser> repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public ApplicationUser? GetUser(ClaimsPrincipal User)
        {
            var id = _userManager.GetUserId(User);
            return _repository.GetAll().FirstOrDefault(e => e.Id == id);
        }

        public Task JoinGroup(UserGroup group, ApplicationUser user, bool own)
        {
            user.UserGroup = group;
            user.IsOwner = own;
            _repository.Update(user);
            return Task.CompletedTask;
        }

        public Task LeftGroup(ApplicationUser User)
        {
            User.UserGroup = null;
            User.IsOwner = null;
            _repository.Update(User);
            return Task.CompletedTask;
        }
    }
}
