using Microsoft.AspNetCore.Mvc;
using ToDoList.Managers;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class TaskController(TaskManager taskManager) : Controller
{
    public IActionResult GetAll()
    {
        var res = taskManager.GetAll();
        return View(res);
    }
    [HttpPost]
    public IActionResult Create(TaskItem newOne)
    {
        taskManager.AddTask(newOne);
        return RedirectToAction("GetAll");
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }
}
