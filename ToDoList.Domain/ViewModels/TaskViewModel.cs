using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.ViewModels;

public class TaskViewModel
{
    public Guid Id { get; set; }
    [Display(Name = "Заголовок")]
    public string Title { get; set; }
    [Display(Name = "Описание")]
    public string Description { get; set; }
    [Display(Name = "Приоритет")]
    public string Priority { get; set; }
    [Display(Name = "Готовность")]
    public string IsDone { get; set; }
    [Display(Name = "Даза создания")]
    public string CreatedDate { get; set; }
    
}