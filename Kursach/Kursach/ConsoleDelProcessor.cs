class ConsoleDelProcessor
{
    // Метод для вызова меню удаления данных
    public static void showDelMenu()
    {
        Console.Clear();

        Console.WriteLine("Выберите, что удалить.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Удалить клиента");
        Console.WriteLine("2) Удалить услугу");
        Console.WriteLine("3) Вернуться назад");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                showDelMenu();
                break;

            case "":
                goto case null;

            case "1":
                delClientMenu();
                break;

            case "2":
                delServiceMenu();
                break;

            case "3":
                ConsoleProcessor.showMainMenu();
                break;
        }
    }

    // Метод для вызова меню удаления клиента
    public static void delClientMenu()
    {
        Console.Clear();

        Console.WriteLine("Укажите номер клиента, которого хотите удалить");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                delClientMenu();
                break;

            case "":
                goto case null;

            default:
                try
                {
                    if(ClientProcessor.check(Convert.ToInt32(ans), "client") == false) ConsoleProcessor.showErrorMenu("Данного пользователя не существует", "delClientMenu");
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "delClientMenu");
                }

                try
                {
                    ClientProcessor.del(Convert.ToInt32(ans), "client");
                } catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при удалении данных из БД ({e.Message})", "delClientMenu");
                }

                ConsoleProcessor.showSuccessMenu("Удаление клиента прошло успешно", 3);

                break;
        }
    }

    // Метод для вызова меню удаления услуг
    public static void delServiceMenu()
    {
        Console.Clear();

        Console.WriteLine("Выберите услугу, которую хотите удалить.");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("1) Счёт");
        Console.WriteLine("2) Вклад");
        Console.WriteLine("3) Кредит");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                delServiceMenu();
                break;

            case "":
                goto case null;

            case "1":
                delAccountMenu();
                break;

            case "2":
                delDepositMenu();
                break;

            case "3":
                delCreditMenu();
                break;
        }
    }

    // Метод для вызова меню удаления счёта
    public static void delAccountMenu()
    {
        Console.Clear();

        Console.WriteLine("Укажите номер счёта, который хотите удалить");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                delAccountMenu();
                break;

            case "":
                goto case null;

            default:
                try
                {
                    if (AccountProcessor.check(Convert.ToInt32(ans), "account") == false) ConsoleProcessor.showErrorMenu("Данного счёта не существует", "delAccountMenu");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "delAccountMenu");
                }

                try
                {
                    AccountProcessor.del(Convert.ToInt32(ans), "account");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при удалении данных из БД ({e.Message})", "delAccountMenu");
                }

                ConsoleProcessor.showSuccessMenu("Удаление счёта прошло успешно", 3);

                break;
        }
    }

    // Метод для вызова меню удаления вклада
    public static void delDepositMenu()
    {
        Console.Clear();

        Console.WriteLine("Укажите номер вклада, который хотите удалить");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                delDepositMenu();
                break;

            case "":
                goto case null;

            default:
                try
                {
                    if (DepositProcessor.check(Convert.ToInt32(ans), "deposit") == false) ConsoleProcessor.showErrorMenu("Данного вклада не существует", "delDepositMenu");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "delDepositMenu");
                }

                try
                {
                    DepositProcessor.del(Convert.ToInt32(ans), "deposit");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при удалении данных из БД ({e.Message})", "delDepositMenu");
                }

                ConsoleProcessor.showSuccessMenu("Удаление вклада прошло успешно", 3);

                break;
        }
    }

    // Метод для вызова меню удаления кредита
    public static void delCreditMenu()
    {
        Console.Clear();

        Console.WriteLine("Укажите номер кредита, который хотите удалить");
        Console.WriteLine();

        string? ans = Console.ReadLine();
        switch (ans)
        {
            case null:
                delCreditMenu();
                break;

            case "":
                goto case null;

            default:
                try
                {
                    if (CreditProcessor.check(Convert.ToInt32(ans), "credit") == false) ConsoleProcessor.showErrorMenu("Данного кредита не существует", "delCreditMenu");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка ввода данных ({e.Message})", "delCreditMenu");
                }

                try
                {
                    CreditProcessor.del(Convert.ToInt32(ans), "credit");
                }
                catch (Exception e)
                {
                    ConsoleProcessor.showErrorMenu($"Ошибка при удалении данных из БД ({e.Message})", "delCreditMenu");
                }

                ConsoleProcessor.showSuccessMenu("Удаление кредита прошло успешно", 3);

                break;
        }
    }
}