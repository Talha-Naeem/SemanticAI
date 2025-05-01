using System.ComponentModel;
using Microsoft.SemanticKernel;
using HandlebarsDotNet.Helpers.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel.ChatCompletion;


public class TaskManagementPlugin
{
    // Mock data for the tasks
    private readonly List<TaskModel> tasks = new()
    {
        new TaskModel { Id = 1, Title = "Design homepage", Description = "Create a modern homepage layout", Status = "In Progress", Priority = "High" },
        new TaskModel { Id = 2, Title = "Fix login bug", Description = "Resolve the issue with login sessions timing out", Status = "To Do", Priority = "Critical" },
        new TaskModel { Id = 3, Title = "Update documentation", Description = "Improve API reference for developers", Status = "Completed", Priority = "Medium" }
    };

[KernelFunction("complete_task")]
[Description("Updates the status of the specified task to Completed")]
[return: Description("The updated task; will return null if the task does not exist")]
    public TaskModel? CompleteTask(int id)
    {
        var task = tasks.FirstOrDefault(task => task.Id == id);

        if (task == null)
        {
            return null;
        }

        task.Status = "Completed";

        return task;
    }
}
public partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Kernel.CreateBuilder();
        Kernel kernel = builder.Build();

        kernel.Plugins.AddFromType<TaskManagementPlugin>("TaskManagement");

        var arguments = new KernelArguments { ["id"] = 1 };
        var updatedTask = await kernel.InvokeAsync("TaskManagement", "complete_task", arguments);

        var task = updatedTask.GetValue<TaskModel>();
        if (task != null)
        {
            Console.WriteLine($"Task ID: {task.Id}, Description: {task.Description}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Status: {task.Status}, Priority: {task.Priority}");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
            }
}
    