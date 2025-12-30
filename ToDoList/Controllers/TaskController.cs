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

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var taskItem = taskManager.GetById(id);
        return View(taskItem);
    }


    [HttpPost("{id}")]
    public IActionResult Edit(int id,TaskItem task)
    {
        taskManager.Update(id, task);
        return RedirectToAction("GetAll");
    }


    [HttpGet("{id}/delete")]
    public IActionResult DeleteView(int id)
    {
        var item = taskManager.GetById(id);
        return View(item);
    }

    [HttpPost("{id}/delete")]
    public IActionResult Delete(int id)
    {
        taskManager.Delete(id);
        return RedirectToAction("GetAll");
    }

}
