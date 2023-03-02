
using DoListApp.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoListApp.DAL.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<SimpleTask> SimpleTask { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

        Database.EnsureCreated();

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
