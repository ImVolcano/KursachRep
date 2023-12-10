class ConsoleProcessor
{
    // Метод для вызова главного меню
    public static void showMainMenu()
    {
        Console.Clear();

        Console.WriteLine("Главное меню приложения. Выберите следующие действие.");
        Console.WriteLine("1) Добавить новые данные");
        Console.WriteLine("2) Редактировать существующие данные");
        Console.WriteLine("3) Удалить существующие данные");
        Console.WriteLine("4) Закрыть приложение");
    }
}