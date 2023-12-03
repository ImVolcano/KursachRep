// Данный класс представляет собой вклад
class Deposit
{
    private int DepositID; // Уникальный номер вклада
    private string Currency; // Валюта вклада
    private int Sum; // Сумма вклада
    private int Percentage; // Процент вклада

    // Свойства
    public int depositID
    {
        get { return DepositID; }
        set { DepositID = value; }
    }

    public string currency
    {
        get { return Currency; }
        set
        {
            if(value == null) throw new ArgumentNullException("Неправильный аргумент (Deposit.currency)");
            else Currency = value;
        }
    }

    public int sum
    {
        get { return Sum; }
        set { Sum = value; }
    }

    public int percentage
    {
        get { return Percentage; }
        set { Percentage = value; }
    }

    // Конструктор
    public Deposit(int depID, string curr, int sum, int perc)
    {
        this.depositID = depID;
        this.currency = curr;
        this.sum = sum;
        this.percentage = perc;
    }
}