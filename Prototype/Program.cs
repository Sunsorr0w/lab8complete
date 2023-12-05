
class Program
{
    static void Main()
    {
        Console.WriteLine("Choose source template format (JSON, XML, CSV): ");
        string sourceFormat = Console.ReadLine().ToUpper();

        IDataTemplate sourceTemplate = null;

        switch (sourceFormat)
        {
            case "JSON":
                sourceTemplate = new JsonDataTemplate();
                break;
            case "XML":
                sourceTemplate = new XmlDataTemplate();
                break;
            case "CSV":
                sourceTemplate = new CsvDataTemplate();
                break;
            default:
                Console.WriteLine("Invalid source format");
                return;
        }

        Console.WriteLine("Fill in data for the source template:");
        sourceTemplate.FillData();
        sourceTemplate.DisplayData();

        Console.WriteLine("Choose target template format (JSON, XML, CSV): ");
        string targetFormat = Console.ReadLine().ToUpper();

        IDataTemplate targetTemplate = null;

        switch (targetFormat)
        {
            case "JSON":
                targetTemplate = new JsonDataTemplate();
                break;
            case "XML":
                targetTemplate = new XmlDataTemplate();
                break;
            case "CSV":
                targetTemplate = new CsvDataTemplate();
                break;
            default:
                Console.WriteLine("Invalid target format");
                return;
        }

        Console.WriteLine("Fill in data for the target template:");
        targetTemplate.FillData();

        IDataAdapter dataAdapter = new DataAdapter();
        dataAdapter.ImportData(sourceTemplate);
        dataAdapter.ExportData(targetTemplate);

        Console.WriteLine("Data transformation completed.");
    }
}
