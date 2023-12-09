// Данный класс представляет собой кредит
class Credit : Deposit
{
    private int PayedSum; // Сумма выплат клиента

    // Свойства
    public int payedSum
    {
        get { return PayedSum; }
        set { PayedSum = value; }
    }

    // Конструктор
    public Credit(int crID, int clID, string curr, int sum, int perc) : base(crID, clID, curr, sum, perc)
    {
        this.payedSum = 0;
    }
}