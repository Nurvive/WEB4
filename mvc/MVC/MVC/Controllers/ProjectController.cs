using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Domain.Repository;
using MVC.Models;

namespace MVC.Controllers;

public class ProjectController : Controller
{
    private readonly DataManager dataManager;

    public ProjectController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public IActionResult Edit(Guid id)
    {
        var entity = id == default ? new Project() : dataManager.project.GetProjectById(id);
        ViewBag.workers = new SelectList(dataManager.worker.GetAllWorkers(), nameof(Worker.id), nameof(Worker.name));
        return View(entity);
    }

    private void UnbindProject(Guid id)
    {
        var allWorkers = dataManager.worker.GetAllWorkers();
        foreach (var currWorker in allWorkers)
        {
            currWorker.projects?.Remove(id);
            dataManager.worker.MakeWorkerModified(currWorker);
        }

        dataManager.worker.SaveChanges();
    }

    private void BindProjectToWorker(Project model)
    {
        if (model.workers.Contains(default) && model.workers.Count == 1)
        {
            UnbindProject(model.id);
            return;
        }
        var allWorkers = dataManager.worker.GetAllWorkers();
        foreach (var currentWorker in allWorkers)
        {
            currentWorker.projects ??= new List<Guid>();

            if (!model.workers.Contains(currentWorker.id))
            {
                currentWorker.projects.Remove(model.id);
                dataManager.worker.MakeWorkerModified(currentWorker);
                continue;
            }

            var uniqueProjects = new HashSet<Guid>(currentWorker.projects);
            uniqueProjects.Add(model.id);
            currentWorker.projects = new List<Guid>(uniqueProjects);
            dataManager.worker.MakeWorkerModified(currentWorker);
        }
        dataManager.worker.SaveChanges();
    }

    [HttpPost]
    public IActionResult Edit(Project model)
    {
        if (ModelState.IsValid)
        {
            BindProjectToWorker(model);
            dataManager.project.SaveProject(model);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }

        ViewBag.workers = new SelectList(dataManager.worker.GetAllWorkers(), nameof(Worker.id), nameof(Worker.name));
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        dataManager.project.DeleteProject(id);
        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
    }
}