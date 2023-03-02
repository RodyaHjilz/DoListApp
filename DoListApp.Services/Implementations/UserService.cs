using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using DoListApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<ApplicationUser> _repository;
        public UserService(IBaseRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }
        public ApplicationUser? GetUser(string id)
        {

            return _repository.GetAll().FirstOrDefault(e => e.Id == id);
        }
    }
}
