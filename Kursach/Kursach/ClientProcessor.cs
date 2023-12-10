using Microsoft.Data.SqlClient;

// Класс для работы с записями в таблице Clients
class ClientProcessor
{
    // Строка подключения к БД
    private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для добавления записи клиента
    public static bool regClient(BankClient client)
    {
        bool result = false;

        string values;
        if (client.patronymic == null || client.patronymic == "null") values = $"('{client.name}', '{client.surname}', null, '{client.age}', '{client.passportSerial}', '{client.passportNumber}')";
        else values = $"('{client.name}', '{client.surname}', '{client.patronymic}', '{client.age}', '{client.passportSerial}', '{client.passportNumber}')";

        string expression = $"INSERT INTO Clients (Name, Surname, Patronymic, Age, PassportSerial, PassportNumber) VALUES " + values;

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для изменения данных записи клиента
    public static bool changeData(int id, BankClient client)
    {
        bool result = false;

        string values;
        if (client.patronymic == null) values = $"Name='{client.name}', Surname='{client.surname}', Patronymic=null, Age={client.age}, PassportSerial='{client.passportSerial}', PassportNumber='{client.passportNumber}'";
        else values = $"Name-'{client.name}', Surname='{client.surname}', Patronymic='{client.patronymic}', Age={client.age}, PassportSerial='{client.passportSerial}', PassportNumber='{client.passportNumber}'";

        string expression = "UPDATE Clients SET " + values + " WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи клиента
    public static bool delClient(int id)
    {
        bool result = false;

        string expression = "DELETE FROM Clients WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для получения количества записей клиентов в таблице
    public static int findCount()
    {
        int result = 0;

        string expression = "SELECT COUNT (*) FROM Clients";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int) command.ExecuteScalar();

        connection.Close();

        return result;
    }

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

    // Метод для проверки наличия клиента в таблице по уникальному номеру
    public static bool check(int id)
    {
        bool result = false;

        string expression = "SELECT COUNT (*) FROM Clients WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if ((int)command.ExecuteScalar() > 0) result = true;

        connection.Close();

        return result;
    }
}