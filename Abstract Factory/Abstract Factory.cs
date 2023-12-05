using System;

// Інтерфейс абстрактної фабрики компонентів
public interface IProductFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}

// Інтерфейс компонента - екран
public interface IScreen
{
    void Display();
}

// Інтерфейс компонента - процесор
public interface IProcessor
{
    void Process();
}

// Інтерфейс компонента - камера
public interface ICamera
{
    void Capture();
}

// Конкретна реалізація екрана для смартфона
public class SmartphoneScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Smartphone Screen Displaying");
    }
}

// Конкретна реалізація процесора для смартфона
public class SmartphoneProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Smartphone Processor Processing");
    }
}

// Конкретна реалізація камери для смартфона
public class SmartphoneCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Smartphone Camera Capturing Photo");
    }
}

// Конкретна реалізація фабрики для смартфона
public class SmartphoneFactory : IProductFactory
{
    public IScreen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public ICamera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

// Клас для збірки і використання продукту
public class ProductAssembler
{
    private IProductFactory productFactory;

    public ProductAssembler(IProductFactory factory)
    {
        productFactory = factory;
    }

    public void AssembleProduct()
    {
        IScreen screen = productFactory.CreateScreen();
        IProcessor processor = productFactory.CreateProcessor();
        ICamera camera = productFactory.CreateCamera();

        Console.WriteLine("Assembling Product:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
