using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Domain.Entity
{
    public class SimpleTask
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public ApplicationUser? User { get; set; } 
        
    }
}
