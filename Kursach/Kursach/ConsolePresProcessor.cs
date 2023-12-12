// Класс для просмотра данных в БД в консоли
using System.Data;

class ConsolePresProcessor
{
    // Метод для вызова меню просмотра данных
    public static void showPresMenu()
    {
        Console.Clear();

        Console.WriteLine("Выберите, что хотите просмотреть");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Список клиентов");
        Console.WriteLine("2) Список счётов");
        Console.WriteLine("3) Список вкладов");
        Console.WriteLine("4) Список кредитов");
        Console.WriteLine("5) Список карт");
        Console.WriteLine("6) Полную сумму всех счетов и вкладов клиента");
        Console.WriteLine("7) Полную сумму, которую должен клиент банку");
        Console.WriteLine("8) Вернуться назад");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showPresMenu();
                break;

            case "":
                goto case null;

            case "1":
                presClientsMenu();
                break;

            case "2":
                presAccountsMenu();
                break;

            case "3":
                presDepositsMenu();
                break;

            case "4":
                presCreditsMenu();
                break;

            case "5":
                presCardsMenu();
                break;

            case "6":
                presTotalSumMenu();
                break;

            case "7":
                presTotalDebtMenu();
                break;

            case "8":
                ConsoleProcessor.showMainMenu();
                break;
        }
    }

    // Метод для вызова меню просмотра всех клиентов
    public static void presClientsMenu()
    {
        Console.Clear();

        List<BankClient> clients = ClientProcessor.getAllClients();

        Console.WriteLine("ID\tИмя\tФамилия\tОтчество\tВозраст\tСерия\tНомер");

        foreach (BankClient client in clients)
        {
            Console.WriteLine();
            string patr = null;
            if (client.patronymic == null) patr = "нет_данных";
            else patr = client.patronymic;
            Console.WriteLine($"{client.clientID}\t{client.name}\t{client.surname}\t{patr}\t{client.age}\t{client.passportSerial}\t{client.passportNumber}");
        }

        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите Enter");
        Console.ReadLine();

        showPresMenu();
    }

    // Метод для вызова меню просмотра всех счётов
    public static void presAccountsMenu()
    {
        Console.Clear();

        List<Account> accs = AccountProcessor.getAll();

        Console.WriteLine("ID\tКлиент\tВалюта\tБаланс\tКарта");

        foreach (Account acc in accs)
        {
            Console.WriteLine();
            Console.WriteLine($"{acc.id}\t{acc.clientID}\t{acc.currency}\t{acc.sum}\t{acc.cardID}");
        }

        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите Enter");
        Console.ReadLine();

        showPresMenu();
    }

    // Метод для вызова меню просмотра всех вкладов
    public static void presDepositsMenu()
    {
        Console.Clear();

        List<Deposit> deps = DepositProcessor.getAll();

        Console.WriteLine("ID\tКлиент\tВалюта\tБаланс\tПроцент");

        foreach (Deposit dep in deps)
        {
            Console.WriteLine();
            Console.WriteLine($"{dep.id}\t{dep.clientID}\t{dep.currency}\t{dep.sum}\t{dep.percentage}");
        }

        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите Enter");
        Console.ReadLine();

        showPresMenu();
    }

    // Метод для вызова меню просмотра всех кредитов
    public static void presCreditsMenu()
    {
        Console.Clear();

        List<Credit> creds = CreditProcessor.getAll();

        Console.WriteLine("ID\tКлиент\tБаланс\tПогашено\tПроцент");

        foreach (Credit cred in creds)
        {
            Console.WriteLine();
            Console.WriteLine($"{cred.id}\t{cred.clientID}\t{cred.sum}\t{cred.payedSum}\t{cred.percentage}");
        }

        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите Enter");
        Console.ReadLine();

        showPresMenu();
    }

    // Метод для вызова меню просмотра всех банковских карт
    public static void presCardsMenu()
    {
        Console.Clear();

        List<BankCard> cards = CardProcessor.getAll();

        Console.WriteLine("ID\tСчёт\tНомер\t\t\tИмя\tФамилия\tДата\tCVV\tPIN");

        foreach (BankCard card in cards)
        {
            Console.WriteLine();
            Console.WriteLine($"{card.cardID}\t{card.accountID}\t{card.cardNumber}\t{card.name}\t{card.surname}\t{card.expiryDate}\t{card.codeCVV}\t{card.codePIN}");
        }

        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите Enter");
        Console.ReadLine();

        showPresMenu();
    }

    // Метод для вызова меню просмотра общей суммы всех вкладов и счетов клиента
    public static void presTotalSumMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите номер клиента");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch(ans)
        {
            case null:
                presTotalSumMenu();
                break;

            case "":
                goto case null;

            default:
                try
                {
                    if (ClientProcessor.check(Convert.ToInt32(ans), "client") == false) ConsoleProcessor.showErrorMenu("Клиента с таким номером не существует", "presTotalSumMenu");
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных({e.Message})", "presTotalSumMenu");
                }

                try
                {
                    Console.Clear();

                    Console.WriteLine("Общая сумма");
                    Console.WriteLine(AccountProcessor.findTotalSum(Convert.ToInt32(ans)) + DepositProcessor.findTotalSum(Convert.ToInt32(ans)));
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при получении общей суммы ({e.Message})", "presTotalSumMenu");
                }

                Console.WriteLine();
                Console.WriteLine("Для продолжения нажмите Enter");
                Console.ReadLine();

                showPresMenu();

                break;
        }
    }

    // Метод для вызова меню просмотра общей задолженности клиента по кредитам
    public static void presTotalDebtMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите номер клиента");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                presTotalDebtMenu();
                break;

            case "":
                goto case null;

            default:
                try
                {
                    if (ClientProcessor.check(Convert.ToInt32(ans), "client") == false) ConsoleProcessor.showErrorMenu("Клиента с таким номером не существует", "presTotalDebtMenu");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных({e.Message})", "presTotalDebtMenu");
                }

                try
                {
                    Console.Clear();

                    Console.WriteLine("Общая задолженность");
                    Console.WriteLine(CreditProcessor.findDebt(Convert.ToInt32(ans)));
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при получении общей суммы ({e.Message})", "presTotalDebtMenu");
                }

                Console.WriteLine();
                Console.WriteLine("Для продолжения нажмите Enter");
                Console.ReadLine();

                showPresMenu();

                break;
        }
    }
}