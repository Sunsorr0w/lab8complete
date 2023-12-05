using System;

// Клас, що відповідає за конфігураційні налаштування
public class ConfigurationManager
{
    private static ConfigurationManager? instance;

    // Параметри конфігурації (в даному випадку просто для прикладу)
    public string LoggingLevel { get; set; }
    public string DatabaseConnectionString { get; set; }

    // Приватний конструктор, щоб заборонити створення екземплярів класу поза його власним Singleton
    private ConfigurationManager()
    {
        // Ініціалізація параметрів конфігурації за замовчуванням
        LoggingLevel = "INFO";
        DatabaseConnectionString = "DefaultConnection";
    }

    // Метод для отримання єдиного екземпляру класу
    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    // Метод для виведення конфігураційних параметрів
    public void DisplayConfiguration()
    {
        Console.WriteLine($"Logging Level: {LoggingLevel}");
        Console.WriteLine($"Database Connection String: {DatabaseConnectionString}");
    }
}
