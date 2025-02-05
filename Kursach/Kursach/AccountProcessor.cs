﻿// Класс для работы с записями в таблице Accounts
using Microsoft.Data.SqlClient;

class AccountProcessor : Processor
{
    // Метод для нахождения суммы всех счётов клиента в таблице по его уникальному номеру
    public static int findTotalSum(int id)
    {
        int result = 0;

        string expression = "SELECT SUM(Sum) FROM Accounts WHERE ClientID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteScalar() != DBNull.Value) result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для получения счёта из таблицы по уникальному номеру
    public static Account getAcc(int id)
    {
        Account result = null;

        string expression = "SELECT * FROM Accounts WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while(reader.Read())
            {
                object clId = reader.GetValue(1);
                object curr = reader.GetValue(2);
                object sum = reader.GetValue(3);
                object cardId = reader.GetValue(4);

                result = new Account(id, (int)clId, (string)curr, (int)sum, (int)cardId);
            }
        }

        return result;
    }

    // Метод для получения списка всех счётов в таблице
    public static List<Account> getAll()
    {
        List<Account> result = new List<Account>();

        string expression = "SELECT * FROM Accounts";

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
                object crID = reader.GetValue(4);

                Account acc = new Account((int)id, (int)clID, (string)curr, (int)sum, (int)crID);
                result.Add(acc);
            }
        }

        return result;
    }
}