using ToDoList.Models;

namespace ToDoList.Managers;

public class TaskManager
{
    public List<TaskItem> TaskItems = new List<TaskItem>
{
    new TaskItem { Id = 1, Name = "Prepare project report", Description = "Compile the monthly progress report and submit to manager" },
    new TaskItem { Id = 2, Name = "Team meeting", Description = "Discuss sprint goals and tasks for the next week" },
    new TaskItem { Id = 3, Name = "Code review", Description = "Review pull requests from team members and provide feedback" },
    new TaskItem { Id = 4, Name = "Design database schema", Description = "Create tables, relationships and indexes for new project" },
    new TaskItem { Id = 5, Name = "Fix login bug", Description = "Resolve authentication issue reported by QA" },
    new TaskItem { Id = 6, Name = "Update documentation", Description = "Revise API documentation and deployment instructions" },
    new TaskItem { Id = 7, Name = "Client call", Description = "Call the client to discuss requirements changes" },
    new TaskItem { Id = 8, Name = "Implement new feature", Description = "Add notification system to the web application" },
    new TaskItem { Id = 9, Name = "Performance optimization", Description = "Improve database query efficiency and reduce load times" },
    new TaskItem { Id = 10, Name = "Deploy to production", Description = "Deploy the latest stable build to production environment" }
}; public void AddTask(TaskItem item)
    {
        item.Id = TaskItems.Max(x => x.Id) + 1;
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
