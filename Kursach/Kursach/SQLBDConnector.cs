using Microsoft.Data.SqlClient;

class SQLDBConnector
{
    private string ConnectionString; // Строка для подключения БД
    private SqlConnection Connection; // Соединение с БД

    // Свойства
    public string connectionString
    {
        get { return ConnectionString; }
        set
        {
            if(value == null) throw new ArgumentNullException("Неправильный аргумент (SQLBDConnector.connectionString");
            else ConnectionString = value;
        }
    }

    // Конструктор
    public SQLDBConnector(string connectionString)
    {
        this.connectionString = connectionString;
        this.Connection = new SqlConnection(connectionString);
    }

    // Метод для подключения к БД
    public bool connectToDB()
    {
        this.Connection.Open();

        if(this.Connection.State.ToString() == "Open") return true;
        else return false;
    }

    // Метод для отключения от БД
    public bool disconnectFromDB()
    {
        this.Connection.Close();

        if (this.Connection.State.ToString() == "Closed") return true;
        else return false;
    }
}