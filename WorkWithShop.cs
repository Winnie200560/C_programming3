using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class WorkWithShop
{
    public static void Fill(string way)
    {
        Shop[] shops =
        {
        new Shop(1, "Молоко", "Молочные", 90.0, 10),
        new Shop(2, "Хлеб", "Выпечка", 50.0, 20),
        new Shop(3, "Сыр", "Молочные", 200.0, 5),
        new Shop(4, "Сок", "Напитки", 140.0, 10)
        };

        BinaryWriter w = new BinaryWriter(File.Open(way, FileMode.Create));
        {
            w.Write(shops.Length);

            for (int i = 0; i < shops.Length; i++)
            {
                w.Write(shops[i].Id);
                w.Write(shops[i].Name);
                w.Write(shops[i].Category);
                w.Write(shops[i].Price);
                w.Write(shops[i].Count);
            }
        }
        w.Close();
    }

    public static void PrintBinaryFile(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        BinaryReader r = new BinaryReader(File.Open(way, FileMode.Open));

        while (r.BaseStream.Position < r.BaseStream.Length)
        {
            int n = r.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                int id = r.ReadInt32();
                string name = r.ReadString();
                string category = r.ReadString();
                double price = r.ReadDouble();
                int count = r.ReadInt32();

                Shop s = new Shop(id, name, category, price, count);
                Console.WriteLine(s);
                Console.WriteLine("-------------------");
            }
        }
        Console.WriteLine();
        r.Close();
    }

    public static List<Shop> Load(string way)
    {
        List<Shop> shops = new List<Shop>();

        if (!File.Exists(way))
        {
            return shops;
        }

        BinaryReader r = new BinaryReader(File.Open(way, FileMode.Open));
        {
            int n = r.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                int id = r.ReadInt32();
                string name = r.ReadString();
                string category = r.ReadString();
                double price = r.ReadDouble();
                int count = r.ReadInt32();

                shops.Add(new Shop(id, name, category, price, count));
            }
        }
        r.Close();
        return shops;
    }

    public static void Save(string way, List<Shop> shops)
    {
        BinaryWriter w = new BinaryWriter(File.Open(way, FileMode.Create));
        {
            w.Write(shops.Count);
            for (int i = 0; i < shops.Count; i++)
            {
                w.Write(shops[i].Id);
                w.Write(shops[i].Name);
                w.Write(shops[i].Category);
                w.Write(shops[i].Price);
                w.Write(shops[i].Count);
            }
        }
        w.Close();
    }

    public static void Add(string way)
    {
        List<Shop> shops = Load(way);

        Console.Write("Id: ");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.Write("Ошибка! Введите целое число больше 0: ");
        }

        Console.Write("Название: ");
        string name = Console.ReadLine(); ;
        while (name.Length == 0 && name == null)
        {
            Console.Write("Ошибка! Введите название: ");
            name = Console.ReadLine();
        }

        Console.Write("Цена: ");
        double price = 0;
        while (!double.TryParse(Console.ReadLine(), out price) || price <= 0.0)
        {
            Console.Write("Ошибка! Введите число больше 0: ");
        }

        Console.Write("Категория: ");
        string category = Console.ReadLine();
        while (category.Length == 0 && category == null)
        {
            Console.Write("Ошибка! Введите категорию: ");
            category = Console.ReadLine();
        }

        Console.Write("Количество: ");
        int count = 0;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.Write("Ошибка! Введите целое число больше 0: ");
        }

        shops.Add(new Shop(id, name, category, price, count));

        Save(way, shops);

        Console.WriteLine("Товар добавлен!");
    }

    public static void DeleteFromFile(string way, int id)
    {
        List<Shop> shops = Load(way);

        Shop item = shops.FirstOrDefault(s => s.Id == id);

        if (item != null)
        {
            shops.Remove(item);
            Save(way, shops);
            Console.WriteLine("Товар удалён!");
        }
        else
        {
            Console.WriteLine("Товар не найден!");
        }
    }

    public static List<Shop> GetExpensive(string way, double price)
    {
        List<Shop> shops = Load(way);

        return shops
            .Where(s => s.Price > price)
            .ToList();
    }

    public static List<Shop> LowStock(string way, int limit)
    {
        List<Shop> shops = Load(way);

        return shops
            .Where(s => s.Count < limit)
            .ToList();
    }

    public static double AveragePrice(string way)
    {
        List<Shop> shops = Load(way);

        if (shops.Count == 0)
            return 0;

        return shops
            .Average(s => s.Price);
    }

    public static Shop ExpensiveProduct(string way)
    {
        List<Shop> shops = Load(way);

        if (shops.Count == 0)
            return null;

        return shops
            .OrderByDescending(s => s.Price)
            .First();
    }

}
