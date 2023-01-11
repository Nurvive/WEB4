using MVC.Domain.Repository.Abstract;

namespace MVC.Domain.Repository;

public class DataManager
{
    public IWorkerRepository worker { get; set; }
    public IProjectRepository project { get; set; }

    public DataManager(IWorkerRepository workerRepository, IProjectRepository projectRepository)
    {
        worker = workerRepository;
        project = projectRepository;
    }
}