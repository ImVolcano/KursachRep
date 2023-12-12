// Класс для редактирования данных в БД через консоль
class ConsoleEditProcessor
{
    // Метод для вызова меню редактирования данных
    public static void showEditMenu()
    {
        Console.Clear();

        Console.WriteLine("Выберите объект редактирования.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Данные клиента");
        Console.WriteLine("2) Данные банковской услуги");
        Console.WriteLine("3) Вернуться назад");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showEditMenu();
                break;

            case "":
                goto case null;

            case "1":
                editClientMenu();
                break;

            case "2":
                editServiceMenu();
                break;

            case "3":
                ConsoleProcessor.showMainMenu();
                break;
        }
    }

    // Метод для вызова меню редактирования клиента
    public static void editClientMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите уникальный номер, имя, фамилию, отчество (если нет, то 'null'), возраст, серию и номер паспорта через пробел.");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                ConsoleProcessor.showErrorMenu("Ошибка ввода данных", "editClientMenu");
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                if (ClientProcessor.check(Convert.ToInt32(data[0]), "client") == false) ConsoleProcessor.showErrorMenu("Пользователя с таким номером не существует", "editClientMenu"); 

                BankClient client = null;
                try
                {
                    client = new BankClient(-1, data[1], data[2], data[3], Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6]));
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "editClientMenu");
                }

                try
                {
                    ClientProcessor.changeData(Convert.ToInt32(data[0]), client);
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка редактирования данных в БД({e.Message})", "editClientMenu");
                }

                ConsoleProcessor.showSuccessMenu("Изменение данных прошло успешно", 2);

                break;
        }
    }

    // Метод для вызова меню редактирования услуги
    public static void editServiceMenu()
    {
        Console.Clear();

        Console.WriteLine("Выберите услугу для редактирования.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Счёт");
        Console.WriteLine("2) Вклад");
        Console.WriteLine("3) Кредит");
        Console.WriteLine("4) Вернуться назад");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                editServiceMenu();
                break;

            case "":
                goto case null;

            case "1":
                editAccountMenu();
                break;

            case "2":
                editDepositMenu();
                break;

            case "3":
                editCreditMenu();
                break;

            case "4":
                showEditMenu();
                break;
        }
    }

    // Метод для редактирования счёта
    public static void editAccountMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите номер, валюту и баланс счёта через пробел");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                editAccountMenu();
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                if (AccountProcessor.check(Convert.ToInt32(data[0]), "account") == false) ConsoleProcessor.showErrorMenu("Счёта с таким номером не существует", "editAccountMenu");

                Account acc = null;
                try
                {
                    acc = AccountProcessor.getAcc(Convert.ToInt32(data[0]));
                    acc.currency = data[1];
                    acc.sum = Convert.ToInt32(data[2]);
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "editAccountMenu");
                }

                try
                {
                    AccountProcessor.changeData(Convert.ToInt32(data[0]), acc);
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка редактирования данных в БД ({e.Message})", "editAccountMenu");
                }

                ConsoleProcessor.showSuccessMenu("Изменение данных прошло успешно", 2);

                break;
        }
    }

    // Метод для редактирования вклада
    public static void editDepositMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите номер, валюту, баланс и процент вклада через пробел");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                editDepositMenu();
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                try
                {
                    if (DepositProcessor.check(Convert.ToInt32(data[0]), "deposit") == false) ConsoleProcessor.showErrorMenu("Вклада с таким номером не существует", "editDepositMenu");
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "editDepositMenu");
                }

                Deposit dep = null;
                try
                {
                    dep = DepositProcessor.getDep(Convert.ToInt32(data[0]));
                    dep.currency = data[1];
                    dep.sum = Convert.ToInt32(data[2]);
                    dep.percentage = Convert.ToInt32(data[3]);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "editDepositMenu");
                }

                try
                {
                    DepositProcessor.changeData(Convert.ToInt32(data[0]), dep);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка редактирования данных в БД ({e.Message})", "editDepositMenu");
                }

                ConsoleProcessor.showSuccessMenu("Изменение данных прошло успешно", 2);

                break;
        }
    }

    // Метод для редактирования кредита
    public static void editCreditMenu()
    {
        Console.Clear();

        Console.WriteLine("Введите номер, валюту, сумму, процент и погашенную сумму кредита через пробел");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                editCreditMenu();
                break;

            case "":
                goto case null;

            default:
                string[] data = ans.Split(" ");

                try
                {
                    if (CreditProcessor.check(Convert.ToInt32(data[0]), "credit") == false) ConsoleProcessor.showErrorMenu("Кредита с таким номером не существует", "editCreditMenu");
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "editCreditMenu");
                }

                Credit credit = null;
                try
                {
                    credit = CreditProcessor.getCred(Convert.ToInt32(data[0]));
                    credit.currency = data[1];
                    credit.sum = Convert.ToInt32(data[2]);
                    credit.percentage = Convert.ToInt32(data[3]);
                    credit.payedSum = Convert.ToInt32(data[4]);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "editCreditMenu");
                }

                try
                {
                    CreditProcessor.changeData(Convert.ToInt32(data[0]), credit);
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка редактирования данных в БД ({e.Message})", "editCreditMenu");
                }

                ConsoleProcessor.showSuccessMenu("Изменение данных прошло успешно", 2);

                break;
        }
    }
}