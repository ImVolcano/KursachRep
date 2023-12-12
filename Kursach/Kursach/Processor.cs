using Microsoft.Data.SqlClient;

// Класс для работы с записями в таблицах в БД
class Processor
{
    // Строка подключения к БД
    protected const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для добавления записи данных в соответствующие таблицы в БД
    public static bool reg(object obj)
    {
        bool result = false;

        string values = null;
        string expression = null;

        if(obj is BankClient client)
        {
            if (client.patronymic == null || client.patronymic == "null") values = $"('{client.name}', '{client.surname}', null, '{client.age}', '{client.passportSerial}', '{client.passportNumber}')";
            else values = $"('{client.name}', '{client.surname}', '{client.patronymic}', '{client.age}', '{client.passportSerial}', '{client.passportNumber}')";
            expression = $"INSERT INTO Clients (Name, Surname, Patronymic, Age, PassportSerial, PassportNumber) VALUES " + values;
        } 
        else if(obj is Credit credit)
        {
            expression = $"INSERT INTO Credits (ClientID, Sum, PayedSum, Percentage) VALUES ('{credit.clientID}', '{credit.sum}', '{credit.payedSum}', '{credit.percentage}')";
        } 
        else if(obj is Deposit deposit)
        {
            expression = $"INSERT INTO Deposits (ClientID, Currency, Sum, Percentage) VALUES ('{deposit.clientID}', '{deposit.currency}', '{deposit.sum}', '{deposit.percentage}')";
        } 
        else if(obj is Account acc)
        {
            expression = $"INSERT INTO Accounts (ClientID, Currency, Sum, CardID) VALUES ('{acc.clientID}', '{acc.currency}', '{acc.sum}', '{acc.cardID}')";
        } 
        else if(obj is BankCard card)
        {
            expression = $"INSERT INTO Cards (AccountID, Number, Name, Surname, ExpiryDate, CVV, PIN) VALUES ('{card.accountID}', '{card.cardNumber}', '{card.name}', '{card.surname}', '{card.expiryDate}', '{card.codeCVV}', '{card.codePIN}')";
        }

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для изменения данных записи
    public static bool changeData(int id, object obj)
    {
        bool result = false;

        string values = null;
        string expression = null;

        if (obj is BankClient client)
        {
            if (client.patronymic == null) values = $"Name='{client.name}', Surname='{client.surname}', Patronymic=null, Age={client.age}, PassportSerial='{client.passportSerial}', PassportNumber='{client.passportNumber}'";
            else values = $"Name='{client.name}', Surname='{client.surname}', Patronymic='{client.patronymic}', Age={client.age}, PassportSerial='{client.passportSerial}', PassportNumber='{client.passportNumber}'";

            expression = "UPDATE Clients SET " + values + " WHERE ID=" + id.ToString();
        }
        else if (obj is Credit credit)
        {
            values = $"ClientID='{credit.clientID}', Sum='{credit.sum}', PayedSum='{credit.payedSum}', Percentage='{credit.percentage}'";
            expression = "UPDATE Credits SET " + values + " WHERE ID=" + id.ToString();
        }
        else if (obj is Deposit deposit)
        {
            values = $"ClientID='{deposit.clientID}', Currency='{deposit.currency}', Sum='{deposit.sum}', Percentage='{deposit.percentage}'";
            expression = "UPDATE Deposits SET " + values + " WHERE ID=" + id.ToString();
        }
        else if (obj is Account acc)
        {
            values = $"ClientID='{acc.clientID}', Currency='{acc.currency}', Sum='{acc.sum}', CardID='{acc.cardID}'";
            expression = "UPDATE Accounts SET " + values + " WHERE ID=" + id.ToString();
        }
        else if (obj is BankCard card)
        {
            values = $"AccountID='{card.accountID}', Number='{card.cardNumber}', Name='{card.name}', Surname='{card.surname}', ExpiryDate='{card.expiryDate}', CVV='{card.codeCVV}', PIN='{card.codePIN}'";
            expression = "UPDATE Cards SET " + values + " WHERE ID=" + id.ToString();
        }

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи
    public static bool del(int id, string type)
    {
        bool result = false;

        string expression = null;

        if(type == "client") expression = "DELETE FROM Clients WHERE ID=" + id.ToString();
        else if(type == "credit") expression = "DELETE FROM Credits WHERE ID=" + id.ToString();
        else if(type == "deposit") expression = "DELETE FROM Deposits WHERE ID=" + id.ToString();
        else if(type == "account") expression = "DELETE FROM Accounts WHERE ID=" + id.ToString();
        else if(type == "card") expression = "DELETE FROM Cards WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);
        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для получения количества записей в таблице
    public static int findCount(string type)
    {
        int result = 0;

        string expression = null;

        if(type == "client") expression = "SELECT COUNT (*) FROM Clients";
        else if(type == "credit") expression = "SELECT COUNT (*) FROM Credits";
        else if(type == "deposit") expression = "SELECT COUNT (*) FROM Deposits";
        else if(type == "account") expression = "SELECT COUNT (*) FROM Accounts";
        else if(type == "card") expression = "SELECT COUNT (*) FROM Cards";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        result = (int)command.ExecuteScalar();

        connection.Close();

        return result;
    }

    // Метод для проверки наличия записи в таблице по уникальному номеру
    public static bool check(int id, string type)
    {
        bool result = false;

        string expression = null;

        if(type == "client") expression = "SELECT COUNT (*) FROM Clients WHERE ID=" + id.ToString();
        else if(type == "credit") expression = "SELECT COUNT (*) FROM Credits WHERE ID=" + id.ToString();
        else if(type == "deposit") expression = "SELECT COUNT (*) FROM Deposits WHERE ID=" + id.ToString();
        else if(type == "account") expression = "SELECT COUNT (*) FROM Accounts WHERE ID=" + id.ToString();
        else if(type == "card") expression = "SELECT COUNT (*) FROM Cards WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if ((int)command.ExecuteScalar() > 0) result = true;

        connection.Close();

        return result;
    }
}