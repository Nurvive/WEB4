using Microsoft.EntityFrameworkCore;
using MVC.Domain;
using MVC.Domain.Repository;
using MVC.Domain.Repository.Abstract;
using MVC.Domain.Repository.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IProjectRepository, EFProjectRepository>();
builder.Services.AddTransient<IWorkerRepository, EFWorkersRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>(item =>
    item.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();