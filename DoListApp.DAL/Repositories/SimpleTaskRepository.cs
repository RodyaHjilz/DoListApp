using DoListApp.DAL.Data;
using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.DAL.Repositories
{
    public class SimpleTaskRepository : IBaseRepository<SimpleTask>
    {
        private readonly ApplicationDbContext context;

        public SimpleTaskRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task Create(SimpleTask entity)
        {
            await context.SimpleTask.AddAsync(entity);
            context.SaveChanges();
        }

        public async Task Delete(SimpleTask entity)
        {
            context.SimpleTask.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<SimpleTask> GetAll()
        {
            return context.SimpleTask.Include(x => x.User);
        }

        public async Task Update(SimpleTask entity)
        {
            if(entity != null)
            {
                context.SimpleTask.Update(entity);
                context.SaveChanges();
            }

        }
    }
}
