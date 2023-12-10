// Класс для работы с записями в таблице Cards
using Microsoft.Data.SqlClient;

class CardProcessor
{
    // Строка подключения к БД
    private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для добавления записи карты в таблицу
    public static bool reg(BankCard card)
    {
        bool result = false;

        string expression = $"INSERT INTO Cards (AccountID, Number, Name, Surname, ExpiryDate, CVV, PIN) VALUES ('{card.accountID}', '{card.cardNumber}', '{card.name}', '{card.surname}', '{card.expiryDate}', '{card.codeCVV}', '{card.codePIN}')";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для изменения данных записи в таблице
    public static bool changeData(int id, BankCard card)
    {
        bool result = false;

        string values = $"AccountID='{card.accountID}', Number='{card.cardNumber}', Name='{card.name}', Surname='{card.surname}', ExpiryDate='{card.expiryDate}', CVV='{card.codeCVV}', PIN='{card.codePIN}'";
        string expression = "UPDATE Cards SET " + values + " WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи из таблицы по уникальному номеру
    public static bool del(int id)
    {
        bool result = false;

        string expression = "DELETE FROM Cards WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для подсчёта количества записей в таблице
    public static int findCount()
    {
        int result = 0;

        string expression = "SELECT COUNT (*) FROM Cards";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }
}