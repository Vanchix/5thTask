using System.Diagnostics;
using System.Linq.Expressions;
using System.Xml.Linq;
char c;
var inventory = new Inventory();
var products = new Product();
Console.WriteLine("Введите номер необходимой операции.\n" +
    "Введите 1 если хотите добавить продукты в инвентарь\n" +
    "Введите 2 если хотите вывести содержимое инвентаря\n" +
    "Введите 3 если хотите вывести количество продуктов в инвентаре и общую стоимость\n" +
    "Введите 4 если хотите найти продукт в инвентаре\n" +
    "Введите 5 если хотите очистить инвентарь\n");
do
{
    Console.WriteLine("Если хотите увидеть список возможных операций введите 6. Иначе введите номер операции.");
    var input = Convert.ToInt32(Console.ReadLine());
    switch (input)
    {
        case (1):
            inventory.IventoryFilling(products);
            break;
        case (2):
            inventory.IventoryOutput();
            break;
        case (3):
            inventory.InventoryResult();
            break;
        case (4):
            inventory.IventoryFind();
            break;
        case (5):
            inventory.ClearIventory();
            break;
        case (6):
            Console.WriteLine("Введите 1 если хотите добавить продукты в инвентарь\n" +
    "Введите 2 если хотите вывести содержимое инвентаря\n" +
    "Введите 3 если хотите вывести количество продуктов в инвентаре и общую стоимость\n" +
    "Введите 4 если хотите найти продукт в инвентаре\n" +
    "Введите 5 если хотите очистить инвентарь\n");
            break;
        default:
            Console.WriteLine("Ошибка!");
            break;
    }
    Console.WriteLine("Введите f если хотите закончить, если хотите продолжить действия с данным инвентарем нажмите другую клавишу");
    c = Convert.ToChar(Console.ReadLine());
} while (c != 'f');



class Product
{
    public string price;
    public string name;
    public string quantity;

}
class Inventory
{
    int n = 0;
    char cont;
    public string[] productsList = new string[1000];
    public int NumberOfProducts;
    public int TotalPrice;
    public void InventoryResult()
    {
        Console.WriteLine();
        Console.WriteLine($"Количество всех продуктов: {NumberOfProducts} Общая цена: {TotalPrice}");
    }
    public void IventoryFilling(Product productInInventory)
    {
        for (int i = n; i < 1000; i++)
        {
            Console.WriteLine("Если хотите ввести продукт нажмите 1, иначе нажмите другую клавишу");
            cont = Convert.ToChar(Console.ReadLine());
            if (cont != '1')
                break;
            Console.WriteLine("Введите наименование продукта");
            productInInventory.name = Console.ReadLine();
            Console.WriteLine("Введите цену продукта");
            productInInventory.price = Console.ReadLine();
            Console.WriteLine("Введите количество продукта");
            productInInventory.quantity = Console.ReadLine();
            NumberOfProducts += Convert.ToInt32(productInInventory.quantity);
            TotalPrice += Convert.ToInt32(productInInventory.price) * Convert.ToInt32(productInInventory.quantity);
            productsList[i] = $"Наименование: {productInInventory.name}     Цена: {productInInventory.price}     Количество: {productInInventory.quantity}";
            n++;
        }
    }
    public void IventoryOutput()
    {
        Console.WriteLine();
        Console.WriteLine("Содержание инвентаря:");
        if (n == 0)
        {
            Console.WriteLine("Инвентарь пуст!");
        }
        else
        {
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(productsList[i]);
            }
        }
    }
    public void ClearIventory()
    {
        productsList = null;
        n = 0;
    }
    public void IventoryFind()
    {
        Console.WriteLine("Введите наименование продукта который хотите найти");
        var find = Console.ReadLine();
        for (var i = 0; i < n; i++)
        {
            if (productsList[i].Contains(find))
            {
                Console.WriteLine(productsList[i]);
            }
        }
    }
}