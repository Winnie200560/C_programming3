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
}


































/*
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
*/