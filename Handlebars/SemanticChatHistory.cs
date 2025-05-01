// using Microsoft.SemanticKernel.PromptTemplates.Handlebars;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Logging.Console;
// using Microsoft.SemanticKernel;
// using Microsoft.SemanticKernel.ChatCompletion;
// try
// {
//     // Load configuration
//     var config = new ConfigurationBuilder()
//         .AddJsonFile("/home/talha-naeem/Documents/LLM Work/handlebarstemplate/Handlebars/appsettings.json", optional: false, reloadOnChange: true)
//         .Build();

//     string modelId = config["modelId"] ?? throw new Exception("modelId is missing in appsettings.json");
//     string endpoint = config["endpoint"] ?? throw new Exception("endpoint is missing in appsettings.json");
//     string apiKey = config["apiKey"] ?? throw new Exception("apiKey is missing in appsettings.json");

//     // Validate endpoint format
//     if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri) || endpointUri.Scheme != "https")
//     {
//         throw new Exception("Invalid endpoint URL. It must be a valid HTTPS URL.");
//     }

//     // Create kernel builder
//     var builder = Kernel.CreateBuilder();
//     builder.AddAzureOpenAIChatCompletion(
//         deploymentName: modelId,
//         endpoint: endpoint,
//         apiKey: apiKey,
//         apiVersion: "2024-12-01-preview" // Updated to stable version
//     );

//     // Add logging
//     builder.Services.AddLogging(logging =>
//     {
//         logging.AddConsole();
//         logging.SetMinimumLevel(LogLevel.Debug);
//     });

//     // Build the kernel
//     var kernel = builder.Build();

// ChatHistory chatHistory = [];

// // Add role messages to the chat history
// chatHistory.AddSystemMessage("You are a helpful assistant.");
// chatHistory.AddUserMessage("What's available to order?");
// chatHistory.AddAssistantMessage("We have pizza, pasta, and salad available to order. What would you like to order?");
// chatHistory.AddUserMessage("I'd like to have the first option, please.");

// for (int i = 0; i < chatHistory.Count; i++)
// {
//     Console.WriteLine($"{chatHistory[i].Role}: {chatHistory[i]}");
// }
// chatHistory.Add(
//     new() {
//         Role = AuthorRole.User,
//         AuthorName = "Laimonis Dumins",
//         Items = [
//             new TextContent { Text = "What available on this menu" },
//             new ImageContent { Uri = new Uri("https://example.com/menu.jpg") }
//         ]
//     }
// );
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
//     if (ex.InnerException != null)
//     {
//         Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
//     }
// }
