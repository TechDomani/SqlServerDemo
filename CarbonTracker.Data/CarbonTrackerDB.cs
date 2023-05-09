using Microsoft.Data.SqlClient;
using System.Data;

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
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * from dbo.users";
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
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into dbo.users (name) VALUES (@Name)";
                var nameParameter = command.Parameters.Add("@Name", SqlDbType.Text);
                nameParameter.Value= userName;
                command.ExecuteNonQuery();
            }
        }

    }
}