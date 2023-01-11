using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Domain.Repository;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataManager _dataManager;

    public HomeController(ILogger<HomeController> logger, DataManager dataManager)
    {
        _logger = logger;
        _dataManager = dataManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ShowWorkers()
    {
        return View(_dataManager.worker.GetAllWorkers());
    }

    public IActionResult ShowProjects(string name, uint? priority = null, Project.SortState sortOrder = Project.SortState.NameAsc)
    {
        Console.WriteLine(name);
        Console.WriteLine(priority);
        Console.WriteLine(sortOrder);
        var projects = _dataManager.project.GetAllProjects();
        //фильтрация
        if (!String.IsNullOrEmpty(name))
        {
            projects = projects.Where(p => p.name.Contains(name));
        }
        if (priority != null && priority != 0)
        {
            projects = projects.Where(p => p.priority == priority);
        }
        // ViewBag.NameSort = sortOrder==Project.SortState.NameAsc ? Project.SortState.NameDesc : Project.SortState.NameAsc;
        // ViewBag.PrioritySort = sortOrder == Project.SortState.PriorityAsc ? Project.SortState.PriorityDesc : Project.SortState.PriorityAsc;
        // сортировка
        projects = sortOrder switch
        {
            Project.SortState.NameDesc => projects.OrderByDescending(s => s.name),
            Project.SortState.PriorityAsc => projects.OrderBy(s => s.priority),
            Project.SortState.PriorityDesc => projects.OrderByDescending(s => s.priority),
            _ => projects.OrderBy(s => s.name),
        };
        
        var viewModel = new IndexViewModel
        {
            FilterViewModel = new FilterViewModel(name, priority),
            SortViewModel = new SortViewModel(sortOrder),
            Projects = projects
        };

        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}