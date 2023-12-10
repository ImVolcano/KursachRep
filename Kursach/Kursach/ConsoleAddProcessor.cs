// Класс для добавления данных в БД через консоль
class ConsoleAddProcessor
{
    // Метод для вызова меню добавления новых данных
    public static void showAddMenu()
    {
        Console.Clear();

        Console.WriteLine("Выберите данные, которые хотите добавить.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Клиент банка");
        Console.WriteLine("2) Банковская услуга");
        Console.WriteLine("3) Вернуться назад");
        Console.WriteLine();

        string? ans = Console.ReadLine();

        switch (ans)
        {
            case null:
                showAddMenu();
                break;

            case "":
                goto case null;

            case "1":
                addClientMenu();
                break;

            case "2":
                addServiceMenu();
                break;

            case "3":
                ConsoleProcessor.showMainMenu();
                break;
        }
    }

    // Метод для вызова меню добаления клиента
    public static void addClientMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите данные через пробел\r\n(Имя, Фамилия, Отчество(если нет, то указать \"null\"), Возраст, Серию и Номер паспорта)\r\n");
        Console.WriteLine("-----------------------------------------------------");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных.", "addClientMenu");
                break;

            case "":
                goto case null;

            default:
                BankClient client = null;

                try
                {
                    client = ClientConverter.makeClient("-1 " + ans);
                }
                catch (Exception ex)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({ex.Message})", "addClientMenu");
                }

                try
                {
                    ClientProcessor.regClient(client);
                }
                catch (Exception ex)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при добавлении данных в БД ({ex.Message})", "addClientMenu");
                }

                ConsoleProcessor.showSuccessMenu("Клиент успешно добавлен.", 1);

                break;
        }
    }

    // Метод для вызова меню добавления банковской услуги
    public static void addServiceMenu()
    {
        Console.Clear();

        Console.WriteLine("Укажите уникальный номер клиента, которому оказывается услуга.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных.", "addServiceMenu");
                break;

            case "":
                goto case null;

            default:
                if (ClientProcessor.check(Convert.ToInt32(ans))) addServiceListMenu(Convert.ToInt32(ans));
                else ConsoleProcessor.showErrorMenu("Ошибка. Клиента под таким номером не существует.", "addServiceMenu");
                break;
        }
    }

    // Метод для вызова меню списка услуг банка
    public static void addServiceListMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Выберите нужную услугу.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Счёт");
        Console.WriteLine("2) Вклад");
        Console.WriteLine("3) Кредит");
        Console.WriteLine("4) Банковская карта");
        Console.WriteLine("5) Вернуться назад");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                addServiceListMenu(id);
                break;

            case "":
                goto case null;

            case "1":
                addAccountMenu(id);
                break;

            case "2":
                addDepositMenu(id);
                break;

            case "3":
                addCreditMenu(id);
                break;

            case "4":
                addCardMenu(id);
                break;

            case "5":
                ConsoleProcessor.showMainMenu();
                break;
        }
    }

    // Метод для вызова меню добавления счёта
    public static void addAccountMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите начальную сумму и валюту счёта через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных.", "addAccountMenu", id);
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                Account acc = null;

                try
                {
                    acc = new Account(-1, id, data[1], Convert.ToInt32(data[0]));
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message}", "addAccountMenu", id);
                }

                try
                {
                    AccountProcessor.reg(acc);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при добавлении данных в БД ({e.Message})", "addAccountMenu", id);
                }

                ConsoleProcessor.showSuccessMenu("Счёт успешно добавлен и привязан к клиенту.", 1);

                break;
        }
    }

    // Метод для вызова меню добавления вклада
    public static void addDepositMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите начальную сумму, валюту и процент вклада через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных.", "addDepositMenu", id);
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                Deposit dep = null;

                try
                {
                    dep = new Deposit(-1, id, data[1], Convert.ToInt32(data[0]), Convert.ToInt32(data[2]));
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "addDepositMenu", id);
                }

                try
                {
                    DepositProcessor.reg(dep);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка добавления данных в БД ({e.Message})", "addDepositMenu", id);
                }

                ConsoleProcessor.showSuccessMenu("Вклад успешно добавлен и привязан к клиенту", 1);

                break;
        }
    }

    // Метод для вызова меню добавления кредита
    public static void addCreditMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите сумму и процент кредита через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных.", "addCreditMenu", id);
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                Credit credit = null;

                try
                {
                    credit = new Credit(-1, id, "Ruble", Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "addCreditMenu", id);
                }

                try
                {
                    CreditProcessor.reg(credit);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка добавления данных в БД ({e.Message})", "addCreditMenu", id);
                }

                ConsoleProcessor.showSuccessMenu("Кредит успешно добавлен и привязан к клиенту.", 1);

                break;
        }
    }

    // Метод для вызова меню добавления банковской карты
    public static void addCardMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите номер счёта, номер карты, имя, фамилию, дату (mm/yy), CVV и PIN.");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных.", "addCardMenu", id);
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                BankCard card = null;

                try
                {
                    card = new BankCard(-1, Convert.ToInt32(data[0]), data[1], data[2], data[3], data[4], data[5], data[6]);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "addCardMenu", id);
                }

                try
                {
                    CardProcessor.reg(card);

                    Account acc = AccountProcessor.getAcc(Convert.ToInt32(data[0]));
                    acc.cardID = CardProcessor.getCard(card.cardNumber).cardID;

                    AccountProcessor.changeData(acc.id, acc);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка добавления данных в БД ({e.Message})", "addCardMenu", id);
                }

                ConsoleProcessor.showSuccessMenu("Карта успешно добавлена и привязана к счёту клиента.", 1);

                break;
        }
    }
}