using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels;
using ToDoList.Service.Interfaces;

namespace ToDoList.Service.Implementations;

public class TaskService : ITaskService
{
    private readonly IBaseRepository<TaskEntity> _taskRepository;
    private readonly ILogger<TaskService> _logger;

    public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }
    
    public async Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
    {
        try
        {
            _logger.LogInformation("Запрос на создание задачи - {ModelName}", model.Title);
            var task = await _taskRepository.GetAll()
                .Where(x => x.CreatedDate.Date == DateTime.Today)
                .FirstOrDefaultAsync(x => x.Title == model.Title);

            if (task != null)
            {
                return new BaseResponse<TaskEntity>()
                {
                    Description = "Задача с таким названием уже существует",
                    StatusCode = StatusCode.TaskIsHasAlready,
                };
            }

            task = new TaskEntity()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                CreatedDate = DateTime.Now,
                IsDone = false,
            };

            await _taskRepository.Create(task);

            _logger.LogInformation("Задача создалась: {TaskTitle}, {TaskCreated}", task.Title, task.CreatedDate);
            return new BaseResponse<TaskEntity>()
            {
                StatusCode = StatusCode.OK,
                Description = "Задача создана",
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "[TaskService.Create]: {EMessage}", e.Message);
            return new BaseResponse<TaskEntity>()
            {
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}