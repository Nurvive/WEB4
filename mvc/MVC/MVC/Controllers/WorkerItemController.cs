using Microsoft.AspNetCore.Mvc;
using MVC.Domain.Repository;
using MVC.Models;

namespace MVC.Controllers;

public class WorkerItemController : Controller
{
    private readonly DataManager dataManager;

    public WorkerItemController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public IActionResult Index(Guid id)
    {
        if (id != default)
        {
            var worker = dataManager.worker.GetWorkerById(id);
            var projects = new List<Project>();
            if (worker.projects != null)
            {
                projects.AddRange(worker.projects.Select(project => dataManager.project.GetProjectById(project)));
            }

            ViewBag.projects = projects;
            return View("Show", worker);
        }

        return View(dataManager.worker.GetAllWorkers());
    }
}