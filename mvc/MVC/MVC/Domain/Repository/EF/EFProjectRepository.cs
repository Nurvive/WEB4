using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MVC.Domain.Repository.Abstract;
using MVC.Models;

namespace MVC.Domain.Repository.EF;

public class EFProjectRepository: IProjectRepository
{
    private readonly AppDbContext context;

    public EFProjectRepository(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Project> GetAllProjects()
    {
        return context.projects;
    }

    public Project GetProjectById(Guid id)
    {
        return context.projects.FirstOrDefault(item => item.id == id);
    }

    public void SaveProject(Project entity)
    {
        if (entity.id == default) {
            context.Entry(entity).State = EntityState.Added;
        } else {
            context.Entry(entity).State = EntityState.Modified;
        }
        context.SaveChanges();
    }

    public void DeleteProject(Guid id)
    {
        context.projects.Remove(new Project() { id = id });
        context.SaveChanges();
    }
}