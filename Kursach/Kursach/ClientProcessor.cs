using Microsoft.Data.SqlClient;

// Класс для работы с записями в таблице Clients
class ClientProcessor : Processor
{
    // Метод для получения списка всех клиентов в таблице
    public static List<BankClient> getAllClients()
    {
        List<BankClient> result = new List<BankClient>();

        string expression = "SELECT * FROM Clients";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object name = reader.GetValue(1);
                object surname = reader.GetValue(2);
                object patronymic = (reader.GetValue(3) is DBNull ? null : reader.GetValue(3));
                object age = reader.GetValue(4);
                object passportSerial = reader.GetValue(5);
                object passportNumber = reader.GetValue(6);

                BankClient client = new BankClient((int) id, (string) name, (string) surname, (string) patronymic, (int) age, (int) passportSerial, (int) passportNumber);
                result.Add(client);
            }
        }

        return result;
    }
}