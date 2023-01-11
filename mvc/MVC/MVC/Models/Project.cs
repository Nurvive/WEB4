using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MVC.Models;

public class Project
{
    [Required] [Key] public Guid id { set; get; }

    [Required] public string name { set; get; }
    
    public enum SortState
    {
        NameAsc,
        NameDesc,
        PriorityAsc,
        PriorityDesc
    }

    public string customer { set; get; }

    public string executor { set; get; }

    public Guid directorId { set; get; }

    [NotMapped] public virtual Worker? director { set; get; }

    public DateTime start { set; get; }

    public DateTime end { set; get; }

    public uint priority { set; get; }
    public List<Guid>? workers { set; get; }
}