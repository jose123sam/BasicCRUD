using Microsoft.Data.SqlClient;
using System.Data;

namespace BasicCRUD.DataBaseFolder;

public class PhoneRepository
{
    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\codec\\source\\repos\\BasicCRUD\\BasicCRUD\\Data\\localDB.mdf;Integrated Security=True";

    public void CreatePhone(string manufacturer, int ramSize)
    {
        using (SqlConnection connection = new(connectionString))
        {
            string query = "INSERT INTO PhoneDB (Manufacturer, RamSize) VALUES (@Manufacturer, @RamSize)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Manufacturer", manufacturer);
            command.Parameters.AddWithValue("@RamSize", ramSize);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public DataTable GetAllData()
    {
        DataTable dataTable = new();

        using (SqlConnection connection = new(connectionString))
        {
            string query = "SELECT * FROM PhoneDB";

            using (SqlCommand command = new(query, connection))
            {
                using (SqlDataAdapter adapter = new(command))
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    connection.Close();
                }
            }
        }

        return dataTable;
    }

    internal void DeleteEntry(string manufacturer, int ramSize)
    {
        using (SqlConnection connection = new(connectionString))
        {
            string query = "DELETE FROM PhoneDB WHERE Manufacturer = @Manufacturer AND RamSize = @RamSize";

            using (SqlCommand command = new(query, connection))
            {
                command.Parameters.AddWithValue("@Manufacturer", manufacturer);
                command.Parameters.AddWithValue("@RamSize", ramSize);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
