using DoListApp.DAL.Data;
using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.DAL.Repositories
{
    public class UserRepository : IBaseRepository<ApplicationUser>
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task Create(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return context.ApplicationUser;
        }

        public Task Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
