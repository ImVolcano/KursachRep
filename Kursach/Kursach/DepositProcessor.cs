﻿// Класс для работы с записями в таблице Deposits
using Microsoft.Data.SqlClient;

class DepositProcessor
{
    // Строка подключения к БД
    private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для создания записи вклада в таблице
    public static bool reg(Deposit deposit)
    {
        bool result = false;

        string expression = $"INSERT INTO Deposits (ClientID, Currency, Sum, Percentage) VALUES ('{deposit.clientID}', '{deposit.currency}', '{deposit.sum}', '{deposit.percentage}')";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для изменения данных записи вклада по его уникальному номеру в таблице
    public static bool changeData(int id, Deposit deposit)
    {
        bool result = false;

        string values = $"ClientID='{deposit.clientID}', Currency='{deposit.currency}', Sum='{deposit.sum}', Percentage='{deposit.percentage}'";
        string expression = "UPDATE Deposits SET " + values + " WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи вклада из таблицы по его уникальному номеру
    public static bool del(int id)
    {
        bool result = false;

        string expression = "DELETE FROM Deposits WHERE ID=" + id.ToString();

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

        string expression = "SELECT COUNT (*) FROM Deposits";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int) command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для нахождения суммы всех вкладов клиента в таблице
    public static int findTotalSum(int id)
    {
        int result = 0;

        string expression = "SELECT SUM(Sum) FROM Deposits WHERE ClientID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int) command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для проверки наличия вклада в таблице по уникальному номеру
    public static bool check(int id)
    {
        bool result = false;

        string expression = "SELECT COUNT (*) FROM Deposits WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if ((int)command.ExecuteScalar() > 0) result = true;

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
}