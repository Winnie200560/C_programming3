using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Shop
{
    private int _id;
    private string _name;
    private string _category;
    private double _price;
    private int _count;
   

    public Shop()
    {
        _id = 1;
        _name = "";
        _category = "";
        _price = 1.0;
        _count = 1;
    }

    public Shop(int id, string name, string category, double price, int count)
    {
        _id = id;
        _name = name;
        _category = category;
        _price = price;
        _count = count;   
    }

    public Shop(Shop OtherShop)
    {
        this._id = OtherShop._id;
        this._name = OtherShop._name;
        this._category = OtherShop._category;
        this._price = OtherShop._price;
        this._count = OtherShop._count;
    }

    public int Id
    {
        get { 
            return _id; 
        }
        set {
            if (value <= 0)
            {
                Console.WriteLine("Ошибка! Значение должно быть не отрицательным!");
            }
            else
            {
                _id = value;
            }
        }
    }
    public string Name
    {
        get { 
            return _name; 
        }
        set {
            if (value.Length != 0 && value != null)
            {
                _name = value;
            }
            else
            {
                Console.WriteLine("Название не может быть пустым!");
            } 
        }
    }
    public string Category
    {
        get
        {
            return _category;
        }
        set
        {
            if (value.Length != 0 && value != null)
            {
                _category = value;
            }
            else
            {
                Console.WriteLine("Категория не может быть пустой!");
            }
        }
    }
    public double Price
    {
        get {
            return _price; 
        }
        set {
            if (value <= 0)
            {
                Console.WriteLine("Ошибка! Значение должно быть не отрицательным!");
            }
            else
            {
                _price = value;
            }
        }
    }
    public int Count
    {
        get {
            return _count; 
        }
        set {
            if (value <= 0)
            {
                Console.WriteLine("Ошибка! Значение должно быть не отрицательным!");
            }
            else
            {
                _count = value;
            }
        }
    }

    public override string ToString() 
    {
        return "id: " + Id + "\nНазвание: " + Name + "\nЦена: " + Price 
            +"\nКатегория: " + Category + "\nКоличество: " + Count;
    }

    public static void Fill(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        BinaryWriter w = new BinaryWriter(File.Open(way, FileMode.Create));
        w.Write(4);

        w.Write(1);
        w.Write("Молоко");
        w.Write("Молочные");
        w.Write(90.0);
        w.Write(10);
 
        w.Write(2);
        w.Write("Хлеб");
        w.Write("Выпечка");
        w.Write(50.0);
        w.Write(20);

        w.Write(3);
        w.Write("Сыр");
        w.Write("Молочные");
        w.Write(200.0);
        w.Write(5);

        w.Write(4);
        w.Write("Сок");
        w.Write("Напитки");
        w.Write(140.0);
        w.Write(10);


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
        List<Shop> shops = new List<Shop>(); // пустой список

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
        r.Close ();
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
        w.Close ();
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

        Console.Write("Категория: ");
        string category = Console.ReadLine();
        while (category.Length == 0 && category == null)
        {
            Console.Write("Ошибка! Введите категорию: ");
            category = Console.ReadLine();
        }

        Console.Write("Цена: ");
        double price = 0;
        while (!double.TryParse(Console.ReadLine(), out price) || price <= 0.0)
        {
            Console.Write("Ошибка! Введите число больше 0: ");
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

