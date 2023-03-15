using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DoListApp.DAL;
using DoListApp.DAL.Data;
using DoListApp.Domain.Entity;
using DoListApp.DAL.Interfaces;
using DoListApp.DAL.Repositories;
using DoListApp.Services.Interfaces;
using DoListApp.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBaseRepository<SimpleTask>, SimpleTaskRepository>();
builder.Services.AddScoped<ISimpleTaskService, SimpleTaskService>();
builder.Services.AddScoped<IBaseRepository<ApplicationUser>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBaseRepository<UserGroup>, GroupRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
