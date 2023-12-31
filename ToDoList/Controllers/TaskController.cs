﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.ViewModels;
using ToDoList.Service.Interfaces;

namespace ToDoList.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel model)
    {
        var response = await _taskService.Create(model);

        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Ok(new { description = response.Description });
        }

        return BadRequest(new { description = response.Description });
    }

    public async Task<IActionResult> TaskHendler()
    {
        var response = await _taskService.GetTaskEntities();
        return Json(new { data = response.Data });
    }
}