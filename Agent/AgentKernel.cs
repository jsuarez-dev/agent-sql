using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Agent;

public class AgentSQL
{
    private IConfigurationRoot config;

    public AgentSQL()
    {
        config = new ConfigurationBuilder().AddUserSecrets<AgentSQL>().Build();

        var apiKey = config["OpenAI:SecretKey"];

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("OpenAI API key is missing. Please add it to the user secrets.");
            return;
        }

    }

    public void Run()
    {
        var builder = Kernel.CreateBuilder();
        Console.WriteLine("Hello World!");
    }
}
