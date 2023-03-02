
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


//namespace DoListApp.Areas.Identity.Data;
namespace DoListApp.Domain.Entity;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Key]
    public int ApplicantId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }

    // TODO принадлежность к группе
}

