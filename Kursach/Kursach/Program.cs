using Microsoft.Data.SqlClient;

/*string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bank;Trusted_Connection=True;";
string sqlExpression = "UPDATE Clients SET Age=35, PassportSerial=3333 WHERE ID=10";

using(SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    SqlCommand cmd = new SqlCommand(sqlExpression, conn);
    cmd.ExecuteNonQuery();

    conn.Close();
}*/

/*BankClient client0 = new BankClient(-1, "Max", "Kasimov", "Vakilevich", 19, 2222, 123456);
BankClient client1 = new BankClient(-1, "Anton", "Antonovich", "Antonov", 26, 1232, 151242);
BankClient client2 = new BankClient(-1, "Biba", "Boba", null, 14, 5233, 733423);

ClientProcessor.regClient(client1);
ClientProcessor.regClient(client2);*/

Account acc0 = new Account(-1, 5, "Ruble", 534);
Account acc1 = new Account(-1, 512, "Euro", 12, 293);
Account acc2 = new Account(-1, 5, "Ruble", 1123, 293);

/*AccountProcessor.reg(acc0);
AccountProcessor.reg(acc1);
AccountProcessor.reg(acc2);*/

//Console.WriteLine(AccountProcessor.findTotalSum(5));