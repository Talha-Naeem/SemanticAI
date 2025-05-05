using System.ComponentModel;
using Microsoft.SemanticKernel;
using HandlebarsDotNet.Helpers.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;


public partial class TaskInvoke
{
    // Mock data for the tasks
    private readonly List<TaskModel> tasks = new()
    {
        new TaskModel { Id = 1, Title = "Design homepage", Description = "Create a modern homepage layout", Status = "In Progress", Priority = "High" },
        new TaskModel { Id = 2, Title = "Fix login bug", Description = "Resolve the issue with login sessions timing out", Status = "To Do", Priority = "Critical" },
        new TaskModel { Id = 3, Title = "Update documentation", Description = "Improve API reference for developers", Status = "Completed", Priority = "Medium" }
    };

    [KernelFunction("get_critical_tasks")]
    [Description("Gets a list of all tasks marked as 'Critical' priority")]
    [return: Description("A list of critical tasks")]
    public List<TaskModel> GetCriticalTasks()
    {
        // Filter tasks with "Critical" priority
        return tasks.Where(task => task.Priority.Equals("Critical", StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

public partial class InvokeFunction
{
    public static async Task Main(string[] args)
    {
        

        // Initialize the builder
        var builder = Kernel.CreateBuilder();
        builder.AddAzureOpenAIChatCompletion(
        deploymentName: "gpt-4.1-nano",
        endpoint:"",
        apiKey: ""
    );

        // Build the kernel
        Kernel kernel = builder.Build();
      
        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        // Add the plugin
        kernel.Plugins.AddFromType<TaskInvoke>("TaskManagement");

        // Enable planning
        OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };

        // Create a history store the conversation
        var history = new ChatHistory();
        history.AddUserMessage("What are all of the critical tasks?");

        // Get the response from the AI
        var result = await chatCompletionService.GetChatMessageContentAsync(
            history,
            executionSettings: openAIPromptExecutionSettings,
            kernel: kernel);

        // Print the results
        Console.WriteLine("Assistant: " + result);
    }
}