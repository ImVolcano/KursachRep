using Microsoft.Data.SqlClient;

// Класс для работы с записями кредитов в таблице Credits
class CreditProcessor
{
    // Строка подключения к БД
    private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для создания записи кредита в таблице
    public static bool reg(Credit credit)
    {
        bool result = false;

        string expression = $"INSERT INTO Credits (ClientID, Sum, PayedSum, Percentage) VALUES ('{credit.clientID}', '{credit.sum}', '{credit.payedSum}', '{credit.percentage}')";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для изменения данных записи кредита по его уникальному номеру в таблице
    public static bool changeData(int id, Credit credit)
    {
        bool result = false;

        string values = $"ClientID='{credit.clientID}', Sum='{credit.sum}', PayedSum='{credit.payedSum}', Percentage='{credit.percentage}'";
        string expression = "UPDATE Credits SET " + values + " WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи кредита из таблицы по его уникальному номеру
    public static bool del(int id)
    {
        bool result = false;

        string expression = "DELETE FROM Credits WHERE ID=" + id.ToString();

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

        string expression = "SELECT COUNT (*) FROM Credits";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для нахождения в таблице общей суммы взятых кредитов у одного клиента
    public static int findDebt(int id)
    {
        int result = 0;

        string expression = "SELECT SUM(Sum) FROM Credits WHERE ClientID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для нахождения в таблицей общей оплаченной суммы по всем кредитам у одного клиента
    public static int findTotalPayed(int id)
    {
        int result = 0;

        string expression = "SELECT SUM(PayedSum) FROM Credits WHERE ClientID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }
}