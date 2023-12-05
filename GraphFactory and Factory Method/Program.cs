class Program
{
    static void Main()
    {
        GraphFactory graphFactory = new GraphFactory();

        Console.Write("Enter chart type (line, bar, pie): ");
        string chartType = Console.ReadLine().ToLower();

        graphFactory.CreateAndDrawChart(chartType);
    }
}