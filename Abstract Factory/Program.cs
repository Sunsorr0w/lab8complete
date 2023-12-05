class Program
{
    static void Main()
    {
        Console.Write("Enter product type (smartphone, laptop, tablet): ");
        string productType = Console.ReadLine().ToLower();

        IProductFactory productFactory = null;

        switch (productType)
        {
            case "smartphone":
                productFactory = new SmartphoneFactory();
                break;
            // Додайте реалізації для інших типів продуктів (лаптопів, планшетів) за аналогією
            // case "laptop":
            //     productFactory = new LaptopFactory();
            //     break;
            // case "tablet":
            //     productFactory = new TabletFactory();
            //     break;
            default:
                Console.WriteLine("Invalid product type");
                return;
        }

        ProductAssembler assembler = new ProductAssembler(productFactory);
        assembler.AssembleProduct();
    }
}