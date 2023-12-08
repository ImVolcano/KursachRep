using Azure.Identity;
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
        if (client.patronymic == null) values = $"('{client.name}', '{client.surname}', null, '{client.age}', '{client.passportSerial}', '{client.passportNumber}')";
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
    public static bool changeData(BankClient client)
    {
        bool result = false;



        return result;
    }

    // Метод для удаления записи клиента
    public static bool delClient(int clientID)
    {
        bool result = false;



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
}