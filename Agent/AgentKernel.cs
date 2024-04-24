using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.Data.Sqlite;

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

public sealed class MathPlugin
{
    [KernelFunction, Description("Take the square root of a number")]
    public static double Sqrt(
        [Description("The number to take a square root of")] double number1
    )
    {
        return Math.Sqrt(number1);
    }
}


public sealed class SQLPlugin
{
    [KernelFunction, Description("Create a new database")]
    public static string CreateDatabase([Description("SQL context connection")] SqliteConnection connection)
    {

        var createTable = connection.CreateCommand();
        createTable.CommandText = @"
            CREATE TABLE IF NOT EXISTS wine (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                type TEXT NOT NULL,
                year INTEGER NOT NULL,
                price REAL NOT NULL,
                rating REAL NOT NULL
            );
        ";
        try
        {
            createTable.ExecuteNonQuery();
            return "done";
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e.Message);
            return e.Message;
        }
    }

}


