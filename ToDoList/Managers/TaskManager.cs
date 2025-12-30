using System.Xml.Linq;
using ToDoList.Models;

namespace ToDoList.Managers;

public class TaskManager
{
    public List<TaskItem> TaskItems = new List<TaskItem>();
    public void AddTask(TaskItem item)
    {
        item.Id = TaskItems.Count + 1;
        TaskItems.Add(item);
        TaskItems.Count();
    }
    public List<TaskItem> GetAll()
    {
       return TaskItems;
    }
    public TaskItem? GetById(int id) => TaskItems.Where(x => x.Id == id).FirstOrDefault();
    public void Update(int id, TaskItem taskItem)
    {
        var task = GetById(id);
        if (task is null) return;

        if (!string.IsNullOrEmpty(taskItem.Name)) task.Name = taskItem.Name;
        if (!string.IsNullOrEmpty(taskItem.Description)) task.Description = taskItem.Description;

    }
    public void Delete(int id)
    {
        var task = GetById(id);
        if (task is null) return;

        TaskItems.Remove(task);
    }
}
