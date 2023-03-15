using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListApp.Domain.Enum
{
    public enum Priority
    {
        [Display(Name = "Простая")]
        Easy = 1,
        [Display(Name = "Важная")]
        Medium = 2,
        [Display(Name = "Критическая")]
        Hard = 3

    }
}
