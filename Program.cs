// See https://aka.ms/new-console-template for more information
using Microsoft.SemanticKernel;

// Populate values from your OpenAI deployment
var modelId = "gpt-35-turbo-16k";
var endpoint = "";
var apiKey = "";

// Create a kernel with Azure OpenAI chat completion
var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

// Build the kernel
Kernel kernel = builder.Build();

var result = await kernel.InvokePromptAsync("Give me a list of breakfast foods with eggs and cheese");
Console.WriteLine(result);