using Microsoft.Data.Sqlite;
using System.Data;
using System.Reflection;

namespace CarbonTracker.Data
{
    public class CarbonTrackerDb
    {
        private string _connectionString;

        public CarbonTrackerDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetUserNames()
        {
            var names = new List<string>();
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "Select * from main.users";
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var name = dataReader.GetString(1);
                    names.Add(name);
                }
            }
            return names;
        }

        public void AddUserName(string userName)
        {
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "insert into main.users (name) VALUES (@Name)";
                var nameParameter = command.Parameters.Add("@Name", SqliteType.Text);
                nameParameter.Value= userName;
                command.ExecuteNonQuery();
            }
        }

    }
}