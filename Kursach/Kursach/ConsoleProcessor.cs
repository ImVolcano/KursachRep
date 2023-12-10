// Класс для работы с пользователем в консоли
class ConsoleProcessor
{
    // Метод для вызова главного меню
    public static void showMainMenu()
    {
        Console.Clear();

        Console.WriteLine("Главное меню приложения. Выберите следующие действие.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Добавить новые данные");
        Console.WriteLine("2) Редактировать существующие данные");
        Console.WriteLine("3) Удалить существующие данные");
        Console.WriteLine("4) Посмотреть существующие данные");
        Console.WriteLine("5) Закрыть приложение");
        Console.WriteLine();

        string? ans = Console.ReadLine();

        switch (ans){
            case null:
                goto case "4";

            case "":
                goto case "4";

            case "1":
                showAddMenu();
                break;

            case "2":
                showEditMenu();
                break;

            case "3":
                showDelMenu();
                break;

            case "4":
                break;

            case "5":
                break;
        }
    }

    // Метод для вызова меню добавления новых данных
    private static void showAddMenu()
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
                showMainMenu();
                break;
        }
    }

    // Метод для вызова меню редактирования данных
    private static void showEditMenu()
    {

    }

    // Метод для вызова меню удаления данных
    private static void showDelMenu()
    {

    }

    // Метод для вызова меню добаления клиента
    private static void addClientMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите данные через пробел\r\n(Имя, Фамилия, Отчество(если нет, то указать \"null\"), Возраст, Серию и Номер паспорта)\r\n");
        Console.WriteLine("-----------------------------------------------------");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu("Ошибка ввода данных.", "addClientMenu");
                break;

            case "":
                goto case null;

            default:
                BankClient client = null;

                try
                {
                    client = ClientConverter.makeClient("-1 " + ans);
                } catch (Exception ex)
                {
                    showErrorMenu($"Ошибка ввода данных ({ex.Message})", "addClientMenu");
                }

                try
                {
                    ClientProcessor.regClient(client);
                } catch (Exception ex)
                {
                    showErrorMenu($"Ошибка при добавлении данных в БД ({ex.Message})", "addClientMenu");
                }

                showSuccessMenu("Клиент успешно добавлен.", 1);

                break;
        }
    }

    // Метод для вызова меню добавления банковской услуги
    private static void addServiceMenu()
    {
        Console.Clear();

        Console.WriteLine("Укажите уникальный номер клиента, которому оказывается услуга.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu("Ошибка ввода данных.", "addServiceMenu");
                break;

            case "":
                goto case null;

            default:
                if (ClientProcessor.check(Convert.ToInt32(ans))) addServiceListMenu(Convert.ToInt32(ans));
                else showErrorMenu("Ошибка. Клиента под таким номером не существует.", "addServiceMenu");
                break;
        }
    }

    // Метод для вызова меню списка услуг банка
    private static void addServiceListMenu(int id)
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
                showMainMenu();
                break;
        }
    }

    // Метод для вызова меню добавления счёта
    private static void addAccountMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите начальную сумму и валюту счёта через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu("Ошибка ввода данных.", "addAccountMenu");
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                Account acc = null;

                try
                {
                    acc = new Account(-1, id, data[1], Convert.ToInt32(data[0]));
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка ввода данных ({e.Message}", "addAccountMenu");
                }

                try
                {
                    AccountProcessor.reg(acc);
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка при добавлении данных в БД ({e.Message})", "addAccountMenu");
                }

                showSuccessMenu("Счёт успешно добавлен и привязан к клиенту.", 1);

                break;
        }
    }

    // Метод для вызова меню добавления вклада
    private static void addDepositMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите начальную сумму, валюту и процент вклада через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu("Ошибка ввода данных.", "addDepositMenu");
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                Deposit dep = null;

                try
                {
                    dep = new Deposit(-1, id, data[1], Convert.ToInt32(data[0]), Convert.ToInt32(data[2]));
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка ввода данных ({e.Message})", "addDepositMenu", id);
                }

                try
                {
                    DepositProcessor.reg(dep);
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка добавления данных в БД ({e.Message})", "addDepositMenu", id);
                }

                showSuccessMenu("Вклад успешно добавлен и привязан к клиенту", 1);

                break;
        }
    }

    // Метод для вызова меню добавления кредита
    private static void addCreditMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите сумму и процент кредита через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu("Ошибка ввода данных.", "addCreditMenu", id);
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                Credit credit = null;

                try
                {
                    credit = new Credit(-1, id, "Ruble", Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка ввода данных ({e.Message})", "addCreditMenu", id);
                }

                try
                {
                    CreditProcessor.reg(credit);
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка добавления данных в БД ({e.Message})", "addCreditMenu", id);
                }

                showSuccessMenu("Кредит успешно добавлен и привязан к клиенту.", 1);

                break;
        }
    }

    // Метод для вызова меню добавления банковской карты
    private static void addCardMenu(int id)
    {
        Console.Clear();

        Console.WriteLine("Введите номер счёта, номер карты, имя, фамилию, дату (mm/yy), CVV и PIN.");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu("Ошибка ввода данных.", "addCardMenu", id);
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                BankCard card = null;

                try
                {
                    card = new BankCard(-1, Convert.ToInt32(data[0]), data[1], data[2], data[3], data[4], data[5], data[6]);
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка ввода данных ({e.Message})", "addCardMenu", 1);
                }

                try
                {
                    CardProcessor.reg(card);

                    Account acc = AccountProcessor.getAcc(Convert.ToInt32(data[0]));
                    acc.cardID = CardProcessor.getCard(card.cardNumber).cardID;

                    AccountProcessor.changeData(acc.id, acc);
                } catch (Exception e)
                {
                    showErrorMenu($"Ошибка добавления данных в БД ({e.Message})", "addCardMenu", 1);
                }

                showSuccessMenu("Карта успешно добавлена и привязана к счёту клиента.", 1);

                break;
        }
    }

    // Метод для вызова меню по его названию (кроме showErrorMenu)
    private static void callMenu(string name)
    {
        switch (name)
        {
            case "showMainMenu":
                showMainMenu();
                break;

            case "showAddMenu":
                showAddMenu();
                break;

            case "showEditMenu":
                showEditMenu();
                break;

            case "showDelMenu":
                showDelMenu();
                break;

            case "addClientMenu":
                addClientMenu();
                break;

            case "addServiceMenu":
                addServiceMenu();
                break;
        }
    }

    // Перегрузка метода callMenu
    private static void callMenu(string name, int id)
    {
        switch (name)
        {
            case "addAccountMenu":
                addAccountMenu(id);
                break;

            case "addDepositMenu":
                addDepositMenu(id);
                break;

            case "addCreditMenu":
                addCreditMenu(id);
                break;

            case "addCardMenu":
                addCardMenu(id);
                break;
        }
    }

    // Метод для вызова меню успеха выполненной операции при работе с приложением
    private static void showSuccessMenu(string message, int num)
    {
        Console.Clear();

        Console.WriteLine(message);
        Console.WriteLine("Продолжить? (Y/N)");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showSuccessMenu(message, num);
                break;

            case "":
                goto case null;

            case "Y":
                if(num == 1) showAddMenu();
                break;

            case "N":
                showMainMenu();
                break;
        }
    }

    // Метод для вызова меню ошибки при работе с приложением
    private static void showErrorMenu(string message, string calledMenu)
    {
        Console.Clear();

        Console.WriteLine(message);
        Console.WriteLine("Попробовать ещё раз? (Y/N)");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu(message, calledMenu);
                break;

            case "":
                goto case null;

            case "Y":
                callMenu(calledMenu);
                break;

            case "N":
                showMainMenu();
                break;
        }
    }

    // Перегрузка метода showErrorMenu
    private static void showErrorMenu(string message, string calledMenu, int id)
    {
        Console.Clear();

        Console.WriteLine(message);
        Console.WriteLine("Продолжить? (Y/N)");

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showErrorMenu(message, calledMenu, id);
                break;

            case "":
                goto case null;

            case "Y":
                callMenu(calledMenu, id);
                break;

            case "N":
                showMainMenu();
                break;
        }
    }
}