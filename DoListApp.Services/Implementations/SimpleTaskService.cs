using DoListApp.DAL.Interfaces;
using DoListApp.Domain.Entity;
using DoListApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Implementations
{
    public class SimpleTaskService : ISimpleTaskService
    {
        private readonly IBaseRepository<SimpleTask> taskRepository;

        public SimpleTaskService(IBaseRepository<SimpleTask> _taskRepository)
        {
            taskRepository = _taskRepository;
        }

        public Task CreateTask(SimpleTask task)
        {
            return taskRepository.Create(task);
        }

        public async Task DeleteTask(int id)
        {
            var item = taskRepository.GetAll().FirstOrDefault(e => e.Id == id);
            if (item != null)
                await taskRepository.Delete(item);

        }

        public async Task DeleteTask(SimpleTask task)
        {
            if (task != null)
                await taskRepository.Delete(task);
        }

        public async Task Edit(SimpleTask task)
        {
            await taskRepository.Update(task);
        }

        public SimpleTask? Get(int id)
        {
            return taskRepository.GetAll().FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<SimpleTask> GetAll(string id)
        {
            var query = taskRepository.GetAll().Where(e => e.User.Id == id);

            return query.ToList();
        }
    }
}
