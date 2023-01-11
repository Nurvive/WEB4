using Microsoft.EntityFrameworkCore;
using MVC.Domain.Repository.Abstract;
using MVC.Models;

namespace MVC.Domain.Repository.EF;

public class EFWorkersRepository : IWorkerRepository
{
    private readonly AppDbContext context;

    public EFWorkersRepository(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Worker> GetAllWorkers()
    {
        return context.workers;
    }

    public Worker GetWorkerById(Guid id)
    {
        return context.workers.FirstOrDefault(item => item.id == id);
    }

    public void SaveWorker(Worker entity)
    {
        context.Entry(entity).State = entity.id == default ? EntityState.Added : EntityState.Modified;
        context.SaveChanges();
    }

    public void MakeWorkerModified(Worker entity)
    {
        context.Entry(entity).State = entity.id == default ? EntityState.Added : EntityState.Modified;
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public void DeleteWorker(Guid id)
    {
        context.workers.Remove(new Worker() { id = id });
        context.SaveChanges();
    }
}