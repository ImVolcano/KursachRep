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
                showMainMenu();
                break;

            case "":
                goto case null;

            case "1":
                ConsoleAddProcessor.showAddMenu();
                break;

            case "2":
                ConsoleEditProcessor.showEditMenu();
                break;

            case "3":
                ConsoleDelProcessor.showDelMenu();
                break;

            case "4":
                ConsolePresProcessor.showPresMenu();
                break;

            case "5":
                Environment.Exit(0);
                break;
        }
    }

    // Метод для вызова меню по его названию (кроме showErrorMenu)
    public static void callMenu(string name)
    {
        switch (name)
        {
            case "showMainMenu":
                showMainMenu();
                break;

            case "showAddMenu":
                ConsoleAddProcessor.showAddMenu();
                break;

            case "showEditMenu":
                ConsoleEditProcessor.showEditMenu();
                break;

            case "showDelMenu":
                ConsoleDelProcessor.showDelMenu();
                break;

            case "addClientMenu":
                ConsoleAddProcessor.addClientMenu();
                break;

            case "addServiceMenu":
                ConsoleAddProcessor.addServiceMenu();
                break;

            case "editClientMenu":
                ConsoleEditProcessor.editClientMenu();
                break;

            case "editServiceMenu":
                ConsoleEditProcessor.editServiceMenu();
                break;

            case "editAccountMenu":
                ConsoleEditProcessor.editAccountMenu();
                break;

            case "editDepositMenu":
                ConsoleEditProcessor.editDepositMenu();
                break;

            case "editCreditMenu":
                ConsoleEditProcessor.editCreditMenu();
                break;

            case "delClientMenu":
                ConsoleDelProcessor.delClientMenu();
                break;

            case "delAccountMenu":
                ConsoleDelProcessor.delAccountMenu();
                break;

            case "delDepositMenu":
                ConsoleDelProcessor.delDepositMenu();
                break;

            case "delCreditMenu":
                ConsoleDelProcessor.delCreditMenu();
                break;

            case "presTotalSumMenu":
                ConsolePresProcessor.presTotalSumMenu();
                break;
        }
    }

    // Перегрузка метода callMenu
    public static void callMenu(string name, int id)
    {
        switch (name)
        {
            case "addAccountMenu":
                ConsoleAddProcessor.addAccountMenu(id);
                break;

            case "addDepositMenu":
                ConsoleAddProcessor.addDepositMenu(id);
                break;

            case "addCreditMenu":
                ConsoleAddProcessor.addCreditMenu(id);
                break;

            case "addCardMenu":
                ConsoleAddProcessor.addCardMenu(id);
                break;
        }
    }

    // Метод для вызова меню успеха выполненной операции при работе с приложением
    public static void showSuccessMenu(string message, int num)
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
                if(num == 1) ConsoleAddProcessor.showAddMenu();
                if(num == 2) ConsoleEditProcessor.showEditMenu();
                if(num == 3) ConsoleDelProcessor.showDelMenu();
                break;

            case "N":
                showMainMenu();
                break;
        }
    }

    // Метод для вызова меню ошибки при работе с приложением
    public static void showErrorMenu(string message, string calledMenu)
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
    public static void showErrorMenu(string message, string calledMenu, int id)
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