using System;
using System.Collections.Generic;

// Інтерфейс або абстрактний клас графіка
public abstract class Chart
{
    public abstract void Draw();
}

// Конкретна реалізація лінійного графіка
public class LineChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Chart");
        // Логіка візуалізації лінійного графіка
    }
}

// Конкретна реалізація стовпчикового графіка
public class BarChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
        // Логіка візуалізації стовпчикового графіка
    }
}

// Конкретна реалізація кругової діаграми
public class PieChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Логіка візуалізації кругової діаграми
    }
}

// Інтерфейс фабрики графіків
public interface IChartFactory
{
    Chart CreateChart();
}

// Реалізація фабрики для лінійного графіка
public class LineChartFactory : IChartFactory
{
    public Chart CreateChart()
    {
        return new LineChart();
    }
}

// Реалізація фабрики для стовпчикового графіка
public class BarChartFactory : IChartFactory
{
    public Chart CreateChart()
    {
        return new BarChart();
    }
}

// Реалізація фабрики для кругової діаграми
public class PieChartFactory : IChartFactory
{
    public Chart CreateChart()
    {
        return new PieChart();
    }
}

// Клас фабрики графіків, який використовує Factory Method
public class GraphFactory
{
    private Dictionary<string, IChartFactory> chartFactories;

    public GraphFactory()
    {
        chartFactories = new Dictionary<string, IChartFactory>
        {
            { "line", new LineChartFactory() },
            { "bar", new BarChartFactory() },
            { "pie", new PieChartFactory() }
        };
    }

    public void CreateAndDrawChart(string chartType)
    {
        if (chartFactories.TryGetValue(chartType, out var factory))
        {
            Chart chart = factory.CreateChart();
            chart.Draw();
        }
        else
        {
            Console.WriteLine("Invalid chart type");
        }
    }
}
