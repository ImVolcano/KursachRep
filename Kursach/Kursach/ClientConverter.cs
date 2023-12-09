// Класс для преобразования данных клиента из одного типа в другой
class ClientConverter
{
    // Метод для преобразования данных экземпляра BankClient в строку
    public static string makeString(BankClient client)
    {
        string result = "";

        result += client.clientID.ToString() + " ";
        result += client.name + " ";
        result += client.surname + " ";
        result += (client.patronymic is null ? "нет_данных" : client.patronymic) + " ";
        result += client.age.ToString() + " ";
        result += client.passportSerial.ToString() + " ";
        result += client.passportNumber.ToString() + " ";

        return result;
    }

    // Метод для преобразования строки с данными клиента в экземпляр BankClient
    public static BankClient makeClient(string client)
    {
        BankClient result;

        string[] data = client.Split(" ");

        result = new BankClient(Convert.ToInt32(data[0]), data[1], data[2], (data[3].Equals("нет_данных") ? null : data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6]));

        return result;
    }
}