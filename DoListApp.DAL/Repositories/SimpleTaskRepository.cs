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
            await context.SaveChangesAsync();
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
            var item = context.SimpleTask.FirstOrDefault(task => task.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                item.Date = entity.Date;
                item.Description = entity.Description;
                context.SimpleTask.Update(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
