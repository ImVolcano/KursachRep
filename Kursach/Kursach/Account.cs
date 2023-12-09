// Данный класс представляет собой счёт клиента
class Account
{
    private int ID; // Уникальный номер счёта
    private int ClientID; // Уникальный номер клиента
    private string Currency; // Валюта счёта
    private int Sum; // Баланс счёта
    private int? CardID; // Уникальный номер банковской карты, к которой привязан счёт

    // Свойства
    public int id
    {
        get { return ID; }
        set { ID = value; }
    }

    public int clientID
    {
        get { return ClientID; }
        set { ClientID = value; }
    }

    public string currency
    {
        get { return Currency; }
        set
        {
            if(value == null) throw new ArgumentNullException("Неправильный аргумент (Account.currency)");
            else Currency = value;
        }
    }

    public int sum
    {
        get { return Sum; }
        set { Sum = value; }
    }

    public int? cardID
    {
        get { return CardID; }
        set { CardID = value; }
    }

    // Конструктор и его перегрузки
    public Account(int accID, int clID, string curr, int sm)
    {
        this.id = accID;
        this.clientID = clID;
        this.currency = curr;
        this.sum = sm;
    }

    public Account(int accID, int clID, string curr, int sm, int cardID)
    {
        this.id = accID;
        this.clientID = clID;
        this.currency = curr;
        this.sum = sm;
        this.cardID = cardID;
    }
}