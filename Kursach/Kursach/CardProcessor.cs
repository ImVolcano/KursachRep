// Класс для работы с записями в таблице Cards
using Microsoft.Data.SqlClient;

class CardProcessor : Processor
{
    // Метод для получения карты из таблицы по уникальному номеру
    public static BankCard getCard(string num)
    {
        BankCard result = null;

        string expression = "SELECT * FROM Cards WHERE Number=" + num;

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object accId = reader.GetValue(1);
                object number = reader.GetValue(2);
                object name = reader.GetValue(3);
                object surname = reader.GetValue(4);
                object expDate = reader.GetValue(5);
                object CVV = reader.GetValue(6);
                object PIN = reader.GetValue(7);

                result = new BankCard((int) id, (int) accId, (string) number, (string) name, (string) surname, (string) expDate, (string) CVV, (string) PIN);
            }
        }

        return result;
    }

    // Метод для получения списка всех банковских карт в таблице
    public static List<BankCard> getAll()
    {
        List<BankCard> result = new List<BankCard>();

        string expression = "SELECT * FROM Cards";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object accId = reader.GetValue(1);
                object number = reader.GetValue(2);
                object name = reader.GetValue(3);
                object surname = reader.GetValue(4);
                object expDate = reader.GetValue(5);
                object CVV = reader.GetValue(6);
                object PIN = reader.GetValue(7);

                BankCard card = new BankCard((int)id, (int)accId, (string)number, (string)name, (string)surname, (string)expDate, (string)CVV, (string)PIN);
                result.Add(card);
            }
        }

        return result;
    }
}