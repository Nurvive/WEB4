namespace MVC.Models;

public class IndexViewModel
{
    public IEnumerable<Project> Projects { get; set; }
    public FilterViewModel FilterViewModel { get; set; }
    public SortViewModel SortViewModel { get; set; }
}