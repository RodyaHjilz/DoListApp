using DoListApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Interfaces
{

    // TODO Реализовать сервис групп
    public interface IGroupService
    {
        //UserGroup GetUserGroup(ClaimsPrincipal User);
        Task CreateGroup(UserGroup group);
        Task UpdateGroup(UserGroup group);
        Task DeleteGroup(UserGroup group);
        UserGroup? GetGroup(Guid id);
    }
}
