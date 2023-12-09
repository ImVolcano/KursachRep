// Данный класс представляет собой вклад
class Deposit : Account
{
    private int Percentage; // Процент вклада

    // Свойства
    public int percentage
    {
        get { return Percentage; }
        set { Percentage = value; }
    }

    // Конструктор
    public Deposit(int depID, int clID, string curr, int sum, int perc) : base(depID, clID, curr, sum)
    {
        this.percentage = perc;
    }
}