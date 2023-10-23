using ToDoList.Domain.Enum;

namespace ToDoList.Domain.ViewModels;

public class CreateTaskViewModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }

    public void Validate()
    {
        if (string.IsNullOrEmpty(Title))
        {
            throw new ArgumentNullException(Title, "Укажите название задачи");
        }
    }
}