
using Agent;



namespace AgentCLI;

class CLI
{
    static void Main(string[] args)
    {
        AgentSQL agent = new AgentSQL();

        agent.Run();

        Console.WriteLine("Hello I'm an agent that can help to select the perfect wine for you ocassion. How can I help you today?");
        string? ask = Console.ReadLine();
        Console.WriteLine(ask);
    }
}
