
using Microsoft.Data.Sqlite;

using Agent;

namespace AgentCLI;

class CLI
{
    static void Main(string[] args)
    {
        AgentSQL agent = new AgentSQL();
        CreateDatabase();

        agent.Run();

        Console.WriteLine("Hello I'm an agent that can help to select the perfect wine for you ocassion. How can I help you today?");
        string? ask = Console.ReadLine();
        Console.WriteLine(ask);
    }

    static void CreateDatabase()
    {
        using var connection = new SqliteConnection("Data Source=wine.db");
        connection.Open();

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
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
