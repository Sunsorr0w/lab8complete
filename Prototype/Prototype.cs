using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Formats.Asn1;

// Інтерфейс для прототипу шаблонів даних
public interface IDataTemplate
{
    IDataTemplate Clone();
    void FillData();
    void DisplayData();
}

// Клас для шаблону даних в форматі JSON
public class JsonDataTemplate : IDataTemplate
{
    private Dictionary<string, object> data;

    public JsonDataTemplate()
    {
        data = new Dictionary<string, object>();
    }

    private JsonDataTemplate(JsonDataTemplate source)
    {
        data = new Dictionary<string, object>(source.data);
    }

    public IDataTemplate Clone()
    {
        return new JsonDataTemplate(this);
    }

    public void FillData()
    {
        Console.WriteLine("Enter JSON data (key1:value1,key2:value2,...): ");
        string jsonData = Console.ReadLine();
    }

    public void DisplayData()
    {
        Console.WriteLine("JSON Data:");
        Console.WriteLine((data, Formatting.Indented));
    }
}

// Клас для шаблону даних в форматі XML
public class XmlDataTemplate : IDataTemplate
{
    private XmlDocument data;

    public XmlDataTemplate()
    {
        data = new XmlDocument();
    }

    private XmlDataTemplate(XmlDataTemplate source)
    {
        data = (XmlDocument)source.data.Clone();
    }

    public IDataTemplate Clone()
    {
        return new XmlDataTemplate(this);
    }

    public void FillData()
    {
        Console.WriteLine("Enter XML data: ");
        string xmlData = Console.ReadLine();
        data.LoadXml(xmlData);
    }

    public void DisplayData()
    {
        Console.WriteLine("XML Data:");
        Console.WriteLine(data.OuterXml);
    }
}

// Клас для шаблону даних в форматі CSV
public class CsvDataTemplate : IDataTemplate
{
    private List<Dictionary<string, string>> data;

    public CsvDataTemplate()
    {
        data = new List<Dictionary<string, string>>();
    }

    private CsvDataTemplate(CsvDataTemplate source)
    {
        data = new List<Dictionary<string, string>>(source.data);
    }

    public IDataTemplate Clone()
    {
        return new CsvDataTemplate(this);
    }

    public void FillData()
    {
        Console.WriteLine("Enter CSV data (key1,value1,key2,value2,...): ");
        string csvData = Console.ReadLine();
        using (TextReader reader = new StringReader(csvData))
        {
            var config = new CsvConfiguration();
            var csvReader = new CsvReader(reader, config);

           
        }
    }

    public void DisplayData()
    {
        Console.WriteLine("CSV Data:");
        foreach (var record in data)
        {
            Console.WriteLine(string.Join(", ", record.Select(kv => $"{kv.Key}: {kv.Value}")));
        }
    }
}

internal class CsvReader
{
    private TextReader reader;
    private CsvConfiguration config;

    public CsvReader(TextReader reader, CsvConfiguration config)
    {
        this.reader = reader;
        this.config = config;
    }
}

internal class CsvConfiguration
{
    public CsvConfiguration()
    {
    }
}

// Інтерфейс для адаптера
public interface IDataAdapter
{
    void ImportData(IDataTemplate source);
    void ExportData(IDataTemplate target);
}

// Адаптер для перетворення даних між різними форматами
public class DataAdapter : IDataAdapter
{
    public void ImportData(IDataTemplate source)
    {
        Console.WriteLine("Importing data from source template...");
        // Реалізація логіки імпорту з одного формату в інший
    }

    public void ExportData(IDataTemplate target)
    {
        Console.WriteLine("Exporting data to target template...");
        // Реалізація логіки експорту з одного формату в інший
    }
}