// Класс для работы с записями в таблице Accounts
using Microsoft.Data.SqlClient;

class AccountProcessor
{
    private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для добавления записи счёта в таблицу
    public static bool reg(Account acc)
    {
        bool result = false;

        string expression = $"INSERT INTO Accounts (ClientID, Currency, Sum, CardID) VALUES ('{acc.clientID}', '{acc.currency}', '{acc.sum}', '{acc.cardID}')";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для изменения данных записи счёта по его уникальному номеру в таблице
    public static bool changeData(int id, Account acc)
    {
        bool result = false;

        string values = $"ClientID='{acc.clientID}', Currency='{acc.currency}', Sum='{acc.sum}', CardID='{acc.cardID}'";
        string expression = "UPDATE Accounts SET " + values + " WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи счёта из таблицы по его уникальному номеру
    public static bool del(int id)
    {
        bool result = false;

        string expression = "DELETE FROM Accounts WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для подсчёта количества счётов клиента в таблице
    public static int findCount(int id)
    {
        int result = 0;

        string expression = "SELECT COUNT (*) FROM Accounts";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для нахождения суммы всех счётов клиента в таблице по его уникальному номеру
    public static int findTotalSum(int id)
    {
        int result = 0;

        string expression = "SELECT SUM(Sum) FROM Accounts WHERE ClientID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }
}