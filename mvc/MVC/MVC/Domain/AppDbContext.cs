using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Domain;

public class AppDbContext : DbContext
{
    public DbSet<Worker> workers { get; set; }
    public DbSet<Project> projects { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseMySql("server=localhost;user=root;password=root;database=mvc;",
                new MySqlServerVersion(new Version(8, 0, 31)));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(x =>
        {
            x.HasKey(y => y.id);
            x.Property(y => y.workers).HasConversion(to => to == null ? null : JsonConvert.SerializeObject(to),
                from => from == null ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(from));
        });
        modelBuilder.Entity<Worker>(x =>
        {
            x.HasKey(y => y.id);
            x.Property(y => y.projects).HasConversion(to => to == null ? null : JsonConvert.SerializeObject(to),
                from => from == null ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(from));
        });
    }
}