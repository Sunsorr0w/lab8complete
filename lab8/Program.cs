
class Program
{
    static void Main()
    {
        // Отримання єдиного екземпляру ConfigurationManager
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Виведення конфігураційних параметрів
        configManager.DisplayConfiguration();

        // Зміна конфігураційних параметрів через консольний інтерфейс
        Console.WriteLine("\nChange Configuration:");
        Console.Write("Enter new Logging Level: ");
      

        Console.Write("Enter new Database Connection String: ");
       

        // Виведення оновлених конфігураційних параметрів
        Console.WriteLine("\nUpdated Configuration:");
        configManager.DisplayConfiguration();

        // Перевірка, що зміни відображаються у єдиному екземплярі ConfigurationManager
        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;
        Console.WriteLine("\nChecking Another Instance:");
        anotherConfigManager.DisplayConfiguration();
    }
}
