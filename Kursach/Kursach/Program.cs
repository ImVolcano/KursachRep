using Microsoft.Data.SqlClient;

/*string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";
string sqlExpression = "INSERT INTO Clients (Name, Surname, Patronymic, Age, PassportSerial, PassportNumber) VALUES ('Anton', 'Antonov', null, 25, 2222, 123457)";

using(SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    SqlCommand cmd = new SqlCommand(sqlExpression, conn);
    cmd.ExecuteNonQuery();

    conn.Close();
}*/

/*BankClient client = new BankClient(-1, "Anton", "Antonovich", null, 25, 2222, 647892);

if(ClientProcessor.regClient(client)) Console.WriteLine("+");*/

Console.WriteLine(ClientProcessor.findCount());