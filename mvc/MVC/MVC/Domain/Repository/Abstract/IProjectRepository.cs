using MVC.Models;

namespace MVC.Domain.Repository.Abstract;

public interface IProjectRepository
{
    Project GetProjectById(Guid id);
    IQueryable<Project> GetAllProjects();
    void SaveProject(Project entity);
    void DeleteProject(Guid id);
}