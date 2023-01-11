using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVC.Models;

public class Worker
{
    [Required] public Guid id { set; get; }

    [Required] public string name { set; get; }
    
    public string lastName { set; get; }

    public string email { set; get; }

    public string patronymic { set; get; }

    public List<Guid>? projects { set; get; }
}