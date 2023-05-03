using CarbonTracker.Data;
using Microsoft.Extensions.Configuration;

namespace CarbonTracker
{
    internal class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            string connectionString = config["ConnectionStrings:carbonDb"] ?? string.Empty;
            Console.WriteLine(connectionString);            
            CarbonTrackerDb db = new(connectionString);

            var names = db.GetUserNames();
            Console.WriteLine("User Names:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("Please enter a name to add:");
            string newName = Console.ReadLine() ?? string.Empty;
            db.AddUserName(newName);
        }
    }
}