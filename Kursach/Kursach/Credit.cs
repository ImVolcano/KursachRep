// Данный класс представляет собой кредит
class Credit
{
    private int CreditID; // Уникальный номер кредита
    private int CreditSum; // Сумма долга за кредит
    private int PayedSum; // Сумма выплат клиента
    private int Percentage; // Процент кредита

    // Свойства
    public int creditID
    {
        get { return CreditID; }
        set { CreditID = value; }
    }

    public int creditSum
    {
        get { return CreditSum; }
        set { CreditSum = value; }
    }

    public int payedSum
    {
        get { return PayedSum; }
        set { PayedSum = value; }
    }

    public int percentage
    {
        get { return Percentage; }
        set { Percentage = value; }
    }

    // Конструктор
    public Credit(int crID, int crSum, int paySum, int perc)
    {
        this.creditID = crID;
        this.creditSum = crSum;
        this.payedSum = paySum;
        this.percentage = perc;
    }
}