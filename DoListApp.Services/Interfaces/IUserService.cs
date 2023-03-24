using DoListApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Interfaces
{
    public interface IUserService
    {
        // Получить ApplicationUser по ID
        ApplicationUser? GetUser(ClaimsPrincipal User);
        Task JoinGroup(UserGroup group, ApplicationUser user, bool own);
        Task LeftGroup (ApplicationUser User);

    }
}
