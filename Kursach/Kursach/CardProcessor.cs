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