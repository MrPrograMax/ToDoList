using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repositories;

public class TaskRepository : IBaseRepository<TaskEntity>
{
    private readonly AppDbContext _db;

    public TaskRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task Create(TaskEntity entity)
    {
        await _db.TaskEntities.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<TaskEntity> GetAll()
    {
        return _db.TaskEntities;
    }

    public async Task Delete(TaskEntity entity)
    {
        _db.TaskEntities.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<TaskEntity> Update(TaskEntity entity)
    {
        _db.TaskEntities.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}