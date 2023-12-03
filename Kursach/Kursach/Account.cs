// Данный класс представляет собой счёт клиента
class Account
{
    private int AccountID; // Уникальный номер счёта
    private string Currency; // Валюта счёта
    private int Balance; // Баланс счёта
    private int CardID; // Уникальный номер банковской карты, к которой привязан счёт

    // Свойства
    public int accountID
    {
        get { return AccountID; }
        set { AccountID = value; }
    }

    public string currency
    {
        get { return Currency; }
        set
        {
            if(value == null) throw new ArgumentNullException("Неправильный аргумент (Account.currency)");
        }
    }

    public int balance
    {
        get { return Balance; }
        set { Balance = value; }
    }

    public int cardID
    {
        get { return CardID; }
        set { CardID = value; }
    }

    // Конструктор
    public Account(int accID, string curr, int bal, int cardID)
    {
        this.accountID = accID;
        this.currency = curr;
        this.balance = bal;
        this.cardID = cardID;
    }
}