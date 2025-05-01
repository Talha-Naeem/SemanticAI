// using Microsoft.SemanticKernel.PromptTemplates.Handlebars;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Logging.Console;
// using Microsoft.SemanticKernel;

// // Create a kernel with Azure OpenAI chat completion
// // var builder = Kernel.CreateBuilder();
// // builder.AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

// // // Build the kernel
// // Kernel kernel = builder.Build();

// try
// {
//     // Load configuration
//     var config = new ConfigurationBuilder()
//         .AddJsonFile("/home/talha-naeem/Documents/LLM Work/handlebarstemplate/appsettings.json", optional: false, reloadOnChange: true)
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

// string prompt = """
//     <message role="system">Instructions: Identify the from and to destinations 
//     and dates from the user's request</message>

//     <message role="user">Can you give me a list of flights from Seattle to Tokyo? 
//     I want to travel from March 11 to March 18.</message>

//     <message role="assistant">
//     Origin: Seattle
//     Destination: Tokyo
//     Depart: 03/11/2025 
//     Return: 03/18/2025
//     </message>

//     <message role="user">{{input}}</message>
//     """;

// string input = "I want to travel from June 1 to July 22. I want to go to Greece. I live in Chicago.";

// // Create the kernel arguments
// var arguments = new KernelArguments { ["input"] = input };

// // Create the prompt template config using handlebars format
// var templateFactory = new HandlebarsPromptTemplateFactory();
// var promptTemplateConfig = new PromptTemplateConfig()
// {
//     Template = prompt,
//     TemplateFormat = "handlebars",
//     Name = "FlightPrompt",
// };
// // Invoke the prompt function
// var function = kernel.CreateFunctionFromPrompt(promptTemplateConfig, templateFactory);
// var response = await kernel.InvokeAsync(function, arguments);
// Console.WriteLine(response);
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
//     if (ex.InnerException != null)
//     {
//         Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
//     }
// }