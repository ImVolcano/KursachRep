// Данный класс представляет собой клиента банка
class BankClient
{
    private int ClientID; // Уникальный номер клиента
    private string Name; // Имя клиента
    private string Surname; // Фамилия клиента
    private string? Patronymic; // Отчество клиента
    private int PassportSerial; // Серия пасспорта клиента
    private int PassportNumber; // Номер пасспорта клиента
    private string PhoneNumber; // Номер телефона клиента

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

    public string phoneNumber
    {
        get { return PhoneNumber; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент (BankClient.surname)");
            else PhoneNumber = value;
        }
    }

    // Конструктор
    public BankClient(int clID, string nm, string snm, string patr, int passSer, int passNum, string phNum)
    {
        this.clientID = clID;
        this.name = nm;
        this.surname = snm;
        this.patronymic = patr;
        this.passportSerial = passSer;
        this.passportNumber = passNum;
        this.phoneNumber = phNum;
    }
}