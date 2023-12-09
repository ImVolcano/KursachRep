using Microsoft.Data.SqlClient;

// Класс для работы с записями услуг в таблице Services
class ServiceProcessor
{
    // Строка подключения к БД
    private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";

    // Метод для добавления записи услуги
    public static bool regService(BankService service)
    {
        bool result = false;

        string expression = "INSERT INTO Services (ClientID, CreditID, AccountID, DepositID) VALUES (@clientID, @creditID, @accountID, @depositID)";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlParameter clientParam = new SqlParameter("@clientID", service.bankClientID);
        SqlParameter creditParam = new SqlParameter("@creditID", service.creditID is null ? DBNull.Value : service.creditID);
        SqlParameter accountParam = new SqlParameter("@accountID", service.accountID is null ? DBNull.Value : service.accountID);
        SqlParameter depositParam = new SqlParameter("@depositID", service.depositID is null ? DBNull.Value : service.depositID);

        SqlCommand command = new SqlCommand(expression, connection);

        command.Parameters.Add(clientParam);
        command.Parameters.Add(creditParam);
        command.Parameters.Add(accountParam);
        command.Parameters.Add(depositParam);

        if (command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }

    // Метод для удаления записи услуги из таблицы
    public static bool delService(int id)
    {
        bool result = false;



        string expression = "DELETE FROM Services WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        if(command.ExecuteNonQuery() > 0) result = true;

        connection.Close();

        return result;
    }
}