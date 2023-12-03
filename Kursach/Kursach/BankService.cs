// Данный класс представляет собой банковскую услугу
class BankService
{
    private int BankServiceID; // Уникальный номер услуги
    private int BankClientID; // Уникальный номер клиета, пользующегося услугой
    private int? CreditID; // Уникальный номер кредита
    private int? AccountID; // Уникальный номер счёта
    private int? DepositID; // Уникальный номер вклада

    // Свойства
    public int bankServiceID
    {
        get { return BankServiceID; }
        set { BankServiceID = value; }
    }
    public int bankClientID
    {
        get { return BankClientID; }
        set { BankClientID = value; }
    }
    public int? creditID
    {
        get { return CreditID; }
        set { CreditID = value; }
    }
    public int? accountID
    {
        get { return AccountID; }
        set { AccountID = value; }
    }
    public int? depositID
    {
        get { return DepositID; }
        set { DepositID = value; }
    }

    // Конструктор
    public BankService(int bServID, int bClientID, int? credID, int? accID, int? depID)
    {
        this.bankServiceID = bServID;
        this.bankClientID = bClientID;
        this.creditID = credID;
        this.accountID = accID;
        this.depositID = depID;
    }
}