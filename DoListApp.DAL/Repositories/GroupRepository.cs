using DoListApp.DAL.Data;
using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoListApp.DAL.Repositories
{
    public class GroupRepository : IBaseRepository<UserGroup>
    {
        private readonly ApplicationDbContext context;

        public GroupRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task Create(UserGroup entity)
        {
            await context.Group.AddAsync(entity);
            context.SaveChanges();
        }

        public async Task Delete(UserGroup entity)
        {
            context.Group.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<UserGroup> GetAll()
        {
            return context.Group;
        }

        public async Task Update(UserGroup entity)
        {
            if(entity != null)
            {
                context.Group.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
