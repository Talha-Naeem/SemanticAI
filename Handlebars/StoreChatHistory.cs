// using Microsoft.SemanticKernel.PromptTemplates.Handlebars;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Logging.Console;
// using Microsoft.SemanticKernel;
// using Microsoft.SemanticKernel.ChatCompletion;
// partial class Program
// {
//     static async Task Main(string[] args)
//     {
//         try
//         {
//             // Load configuration
//             var config = new ConfigurationBuilder()
//                 .AddJsonFile("/home/talha-naeem/Documents/LLM Work/handlebarstemplate/Handlebars/appsettings.json", optional: false, reloadOnChange: true)
//                 .Build();

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
//         apiKey: apiKey
//        // apiVersion: "2024-12-01-preview" // Updated to stable version
//     );

//     // Add logging
//     builder.Services.AddLogging(logging =>
//     {
//         logging.AddConsole();
//         logging.SetMinimumLevel(LogLevel.Debug);
//     });

//     // Build the kernel
// Kernel kernel = builder.Build();

// // Get chat completion service.
// var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
   

// ChatHistory chatHistory = [];

// // Add role messages to the chat history
// void AddMessage(string msg) {
//     Console.WriteLine(msg);
//     chatHistory.AddAssistantMessage(msg);
// }

// void GetInput() {
//     string input = Console.ReadLine()!;
//     chatHistory.AddUserMessage(input);
// }

// async Task GetReply() {
//     ChatMessageContent reply = await chatCompletionService.GetChatMessageContentAsync(
//         chatHistory,
//         kernel: kernel
//     );
//     Console.WriteLine(reply.ToString());
//     chatHistory.AddAssistantMessage(reply.ToString());
// }
// // Prompt the LLM
// chatHistory.AddSystemMessage("You are a helpful travel assistant.");
// chatHistory.AddSystemMessage("Recommend a destination to the traveler based on their background and preferences.");

// // Get information about the user's plans
// AddMessage("Tell me about your travel plans.");
// GetInput();
// await GetReply();
// // Offer recommendations
// AddMessage("Would you like some activity recommendations?");
// GetInput();
// await GetReply();

// // Offer language tips
// AddMessage("Would you like some helpful phrases in the local language?");
// GetInput();
// await GetReply();
// Console.WriteLine("Chat Ended.\n");
// Console.WriteLine("Chat History:");

// for (int i = 0; i < chatHistory.Count; i++)
// {
//     Console.WriteLine($"{chatHistory[i].Role}: {chatHistory[i]}");
// }
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
//     if (ex.InnerException != null)
//     {
//         Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
//     }
// }

//     }}