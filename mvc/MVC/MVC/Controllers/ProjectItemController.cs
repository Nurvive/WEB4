using Microsoft.AspNetCore.Mvc;
using MVC.Domain.Repository;
using MVC.Models;

namespace MVC.Controllers;

public class ProjectItemController : Controller
{
    private readonly DataManager dataManager;

    public ProjectItemController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public IActionResult Index(Guid id)
    {
        if (id != default)
        {
            var project = dataManager.project.GetProjectById(id);
            var workers = new List<Worker>();
            if (project.workers != null)
            {
                workers.AddRange(from worker in project.workers where worker != default select dataManager.worker.GetWorkerById(worker));
            }

            project.director = dataManager.worker.GetWorkerById(project.directorId);
            ViewBag.workers = workers;
            return View("Show", project);
        }

        return View(dataManager.project.GetAllProjects());
    }
}