// Данный класс представляет собой банковскую карту, привязанную к счёту
class BankCard
{
    private int CardID; // Уникальный номер карты
    private string CardNumber; // Номер на карте
    private string Name; // Имя на карте
    private string Surname; // Фамилия на карте
    private string ExpiryDate; // Дата окончания работы карты
    private int CodeCVV; // CVV-код карты
    private int CodePIN; // PIN-код карты

    // Свойства
    public int cardID
    {
        get { return CardID; }
        set { CardID = value; }
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

    public int codeCVV
    {
        get { return CodeCVV; }
        set { CodeCVV = value; }
    }

    public int codePIN
    {
        get { return CodePIN; }
        set { CodePIN = value; }
    }

    // Конструктор
    public BankCard(int cardID, string cardNum, string cardName, string cardSurname, string expDate, int CVV, int PIN)
    {
        this.cardID = cardID;
        this.cardNumber = cardNum;
        this.name = cardName;
        this.surname = cardSurname;
        this.expiryDate = expDate;
        this.codeCVV = CVV;
        this.codePIN = PIN;
    }
}