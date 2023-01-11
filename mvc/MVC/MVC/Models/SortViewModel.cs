namespace MVC.Models;

public class SortViewModel
{
    public Project.SortState NameSort { get; private set; }    // значение для сортировки по возрасту
    public Project.SortState PrioritySort { get; private set; }   // значение для сортировки по компании
    public Project.SortState Current { get; private set; }     // текущее значение сортировки
    
    public SortViewModel(Project.SortState sortOrder)
    {
        NameSort = sortOrder == Project.SortState.NameAsc ? Project.SortState.NameDesc : Project.SortState.NameAsc;
        PrioritySort = sortOrder == Project.SortState.PriorityAsc ? Project.SortState.PriorityDesc : Project.SortState.PriorityAsc;
        Current = sortOrder;
    }
}