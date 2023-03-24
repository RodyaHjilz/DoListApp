using DoListApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Services.Interfaces
{

    public interface ISimpleTaskService
    {
        IEnumerable <SimpleTask> GetAll(string id);
        IEnumerable <SimpleTask> GetGroupTask(Guid id);
        SimpleTask? Get(int id);
        Task DeleteTask(int id);
        Task DeleteTask(SimpleTask Task);
        Task CreateTask(SimpleTask Task);
        Task Edit(SimpleTask Task);


    }
}
