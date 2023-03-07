using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Domain.ViewModels
{
    public class SimpleTaskViewModel
    {

        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }
        [Display(Name = "Описание задачи")]
        public string? Description { get; set; }


    }
}
