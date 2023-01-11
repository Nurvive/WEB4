using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Domain.Repository;
using MVC.Models;

namespace MVC.Controllers;

public class WorkerController : Controller
{
    private readonly DataManager dataManager;

    public WorkerController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public IActionResult Edit(Guid id)
    {
        var entity = id == default ? new Worker() : dataManager.worker.GetWorkerById(id);
        return View(entity);
    }

    [HttpPost]
    public IActionResult Edit(Worker model)
    {
        if (ModelState.IsValid)
        {
            dataManager.worker.SaveWorker(model);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        dataManager.worker.DeleteWorker(id);
        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
    }
}