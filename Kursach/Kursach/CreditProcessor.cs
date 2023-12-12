using Microsoft.Data.SqlClient;

// Класс для работы с записями кредитов в таблице Credits
class CreditProcessor : Processor
{
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

    // Метод для получения кредита из таблицы по уникальному номеру
    public static Credit getCred(int id)
    {
        Credit result = null;

        string expression = "SELECT * FROM Credits WHERE ID=" + id.ToString();

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(expression, connection);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                object clId = reader.GetValue(1);
                object sum = reader.GetValue(2);
                object psum = reader.GetValue(3);
                object perc = reader.GetValue(4);

                result = new Credit(id, (int)clId, "Ruble", (int)sum, (int)perc);
                result.payedSum = (int)psum;
            }
        }

        return result;
    }

    // Метод для получения списка всех кредитов в таблице
    public static List<Credit> getAll()
    {
        List<Credit> result = new List<Credit>();

        string expression = "SELECT * FROM Credits";

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
                object sum = reader.GetValue(2);
                object psum = reader.GetValue(3);
                object perc = reader.GetValue(4);

                Credit cred = new Credit((int)id, (int)clID, "Ruble", (int)sum, (int)perc);
                cred.payedSum = (int)psum;
                result.Add(cred);
            }
        }

        return result;
    }
}