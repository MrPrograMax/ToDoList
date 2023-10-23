using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Entity;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedDate { get; set; }
}