namespace MVC.Models;

public class ProjectWorker
{
    public Guid WorkerId { get; set; }
    public Worker Worker { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}