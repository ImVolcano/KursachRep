// Класс для работы с записями в таблице Deposits
using Microsoft.Data.SqlClient;

class DepositProcessor : Processor
{
    // Метод для нахождения суммы всех вкладов клиента в таблице
    public static int findTotalSum(int id)
    {
        int result = 0;

        string expression = "SELECT SUM(Sum) FROM Deposits WHERE ClientID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if(command.ExecuteScalar() != DBNull.Value) result = (int) command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для получения вклада из таблицы по уникальному номеру
    public static Deposit getDep(int id)
    {
        Deposit result = null;

        string expression = "SELECT * FROM Deposits WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                object clId = reader.GetValue(1);
                object curr = reader.GetValue(2);
                object sum = reader.GetValue(3);
                object perc = reader.GetValue(4);

                result = new Deposit(id, (int)clId, (string)curr, (int)sum, (int)perc);
            }
        }

        return result;
    }

    // Метод для получения списка всех вкладов в таблице
    public static List<Deposit> getAll()
    {
        List<Deposit> result = new List<Deposit>();

        string expression = "SELECT * FROM Deposits";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object clID = reader.GetValue(1);
                object curr = reader.GetValue(2);
                object sum = reader.GetValue(3);
                object perc = reader.GetValue(4);

                Deposit dep = new Deposit((int)id, (int)clID, (string)curr, (int)sum, (int)perc);
                result.Add(dep);
            }
        }

        return result;
    }
}