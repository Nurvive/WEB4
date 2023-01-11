using MVC.Models;

namespace MVC.Domain.Repository.Abstract;

public interface IWorkerRepository
{
    Worker GetWorkerById(Guid id);
    IQueryable<Worker> GetAllWorkers();
    void SaveWorker(Worker entity);
    public void MakeWorkerModified(Worker entity);
    void SaveChanges();
    void DeleteWorker(Guid id);
}