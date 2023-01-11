namespace MVC.Models;

public class FilterViewModel
{
    public FilterViewModel(string name, uint? priority = null)
    {
        SelectedPriority = priority;
        SelectedName = name;
    }
    
    public string SelectedName { get; private set; }
    public uint? SelectedPriority { get; private set; }
}