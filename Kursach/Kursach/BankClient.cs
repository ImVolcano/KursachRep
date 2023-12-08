// Данный класс представляет собой клиента банка
class BankClient
{
    private int ClientID; // Уникальный номер клиента (равен -1, если создан экземпляр класса, записи которого нет в таблице)
    private string Name; // Имя клиента
    private string Surname; // Фамилия клиента
    private string? Patronymic; // Отчество клиента
    private int Age; // Возраст клиента
    private int PassportSerial; // Серия пасспорта клиента
    private int PassportNumber; // Номер пасспорта клиента

    // Свойства
    public int clientID
    {
        get { return ClientID; }
        set { ClientID = value; }
    }

    public string name
    {
        get { return Name; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент (BankClient.name)");
            else Name = value;
        }
    }

    public string surname
    {
        get { return Surname; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент (BankClient.surname)");
            else Surname = value;
        }
    }

    public string? patronymic
    {
        get { return Patronymic; }
        set { Patronymic = value; }
    }

    public int age
    {
        get { return Age; }
        set {  Age = value; }
    }

    public int passportSerial
    {
        get { return PassportSerial; }
        set { PassportSerial = value; }
    }

    public int passportNumber
    {
        get { return PassportNumber; }
        set { PassportNumber = value; }
    }

    // Конструктор
    public BankClient(int clID, string nm, string snm, string patr, int age, int passSer, int passNum)
    {
        this.clientID = clID;
        this.name = nm;
        this.surname = snm;
        this.age = age;
        this.patronymic = patr;
        this.passportSerial = passSer;
        this.passportNumber = passNum;
    }
}