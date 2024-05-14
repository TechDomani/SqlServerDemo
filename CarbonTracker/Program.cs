using CarbonTracker.Data;
using Microsoft.Extensions.Configuration;

namespace CarbonTracker
{
    internal class Program
    {
        static void Main()
        {
            const string ConnectionString = "Data Source=DESKTOP-8BNVI95;Initial Catalog=carbon;Integrated Security=True;TrustServerCertificate=True";

			Console.WriteLine(ConnectionString);            
            CarbonTrackerDb db = new(ConnectionString);

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