// Данный класс представляет собой банковскую карту, привязанную к счёту
class BankCard
{
    private int CardID; // Уникальный номер карты
    private int AccountID; // Уникальный номер счёта, к которому привязана карта
    private string CardNumber; // Номер на карте
    private string Name; // Имя на карте
    private string Surname; // Фамилия на карте
    private string ExpiryDate; // Дата окончания работы карты
    private string CodeCVV; // CVV-код карты
    private string CodePIN; // PIN-код карты

    // Свойства
    public int cardID
    {
        get { return CardID; }
        set { CardID = value; }
    }

    public int accountID
    {
        get { return AccountID; }
        set { AccountID = value; }
    }

    public string cardNumber
    {
        get { return CardNumber; }
        set
        {
            if(value == null) throw new ArgumentNullException("Неправильный аргумент (BankCard.cardNumber)");
            else CardNumber = value;
        }
    }

    public string name
    {
        get { return Name; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент (BankCard.name)");
            else Name = value;
        }
    }

    public string surname
    {
        get { return Surname; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент (BankCard.surname)");
            else Surname = value;
        }
    }

    public string expiryDate
    {
        get { return ExpiryDate; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент (BankCard.expiryDate)");
            else ExpiryDate = value;
        }
    }

    public string codeCVV
    {
        get { return CodeCVV; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент");
            else CodeCVV = value;
        }
    }

    public string codePIN
    {
        get { return CodePIN; }
        set
        {
            if (value == null) throw new ArgumentNullException("Неправильный аргумент");
            else CodePIN = value;
        }
    }

    // Конструктор
    public BankCard(int cardID, int accID, string cardNum, string cardName, string cardSurname, string expDate, string CVV, string PIN)
    {
        this.cardID = cardID;
        this.accountID = accID;
        this.cardNumber = cardNum;
        this.name = cardName;
        this.surname = cardSurname;
        this.expiryDate = expDate;
        this.codeCVV = CVV;
        this.codePIN = PIN;
    }
}