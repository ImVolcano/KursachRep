using Microsoft.Data.SqlClient;

string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";
string sqlExpression = "SELECT * FROM Clients";

using(SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    SqlCommand cmd = new SqlCommand(sqlExpression, conn);
    SqlDataReader reader = cmd.ExecuteReader();

    if (reader.HasRows)
    {
        string column0 = reader.GetName(0);
        string column1 = reader.GetName(1);
        string column2 = reader.GetName(2);
        string column3 = reader.GetName(3);

        Console.WriteLine($"{column0}\t{column1}\t{column2}\t{column3}");

        while (reader.Read())
        {
            object id = reader.GetValue(0);
            object name = reader.GetValue(1);
            object surname = reader.GetValue(2);
            object age = reader.GetValue(3);

            Console.WriteLine($"{id}\t{name}\t{surname}\t{age}");
        }
    }
}