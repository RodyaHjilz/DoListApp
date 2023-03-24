using DoListApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Domain.ViewModels
{
    public class GroupTasksViewModel
    {
        public IEnumerable<SimpleTask> task { get; set; }
        public UserGroup group { get; set; }
    }
}
