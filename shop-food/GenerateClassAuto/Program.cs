using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var arrClass = new string[]
        {
            "Inventory", "Product", "Supplier", "Transaction", "Unit"
        };
    }

    public static void GenModels(string[] arrClass)
    {
        var content = File.ReadAllText("templace_controller.txt");
        foreach (var item in arrClass)
        {
            if (!string.IsNullOrEmpty(item))
            {
                string filePath = $"D:\\Woks\\du-an-1\\du-an-trieu-do\\shop-food\\shop-food-api\\Controllers\\Warehouses\\{item}WhModels.cs";
                var contenNew = Regex.Replace(content, @"_ClassName_", item);
                File.WriteAllText(filePath, contenNew);
            }
        }
    }

    public static void GenController(string[] arrClass)
    {
        var content = File.ReadAllText("template_controller.txt");
        foreach (var item in arrClass)
        {
            if (!string.IsNullOrEmpty(item))
            {
                string filePath = $"D:\\Woks\\du-an-1\\du-an-trieu-do\\shop-food\\shop-food-api\\Controllers\\Warehouses\\{item}WhController.cs";
                var contenNew = Regex.Replace(content, @"_ClassName_", item);
                contenNew = Regex.Replace(contenNew, @"route", item.ToLower());
                File.WriteAllText(filePath, contenNew);
            }
        }
    }

    public static void GenInterface(string[] arrClass)
    {
        var content = File.ReadAllText("template_gen_interface.txt");
        foreach (var item in arrClass)
        {
            if (!string.IsNullOrEmpty(item))
            {
                string filePath = $"D:\\Woks\\du-an-1\\du-an-trieu-do\\shop-food\\shop-food-api\\Services\\Warehouse\\I{item}WhService.cs";
                var contenNew = Regex.Replace(content, @"_ClassName_", item);
                File.WriteAllText(filePath, contenNew);
            }
        }
    }

    public static void GenService(string[] arrClass)
    {
        var content = File.ReadAllText("template_gen_service.txt");
        foreach (var item in arrClass)
        {
            if (!string.IsNullOrEmpty(item))
            {
                string filePath = $"D:\\Woks\\du-an-1\\du-an-trieu-do\\shop-food\\shop-food-api\\Services\\Warehouse\\Impl\\{item}WhService.cs";
                var contenNew = Regex.Replace(content, @"_ClassName_", item);
                File.WriteAllText(filePath, contenNew);
            }
        }
    }
}