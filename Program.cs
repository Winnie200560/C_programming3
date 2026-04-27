using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        string way = "shop.dat";
        WorkWithShop.Fill(way);

        while (true)
        {

            Console.WriteLine("\n--- МАГАЗИН ---");
            Console.WriteLine("1. Показать содержимое");
            Console.WriteLine("2. Добавить элемент");
            Console.WriteLine("3. Удалить элемент");
            Console.WriteLine("4. Товары дороже цены");
            Console.WriteLine("5. Товары с малым количеством");
            Console.WriteLine("6. Средняя цена");
            Console.WriteLine("7. Самый дорогой товар");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine();
                        WorkWithShop.PrintBinaryFile(way);
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine();
                        WorkWithShop.Add(way);
                        break;
                    }

                case 3:
                    {
                        Console.Write("Введите id: ");
                        int id = 0;
                        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                        {
                            Console.Write("Ошибка! Введите целое число больше 0: ");
                        }
                        Console.WriteLine();
                        WorkWithShop.DeleteFromFile(way, id);
                        break;
                    }
                case 4:
                    {
                        Console.Write("Введите цену: ");
                        double price = 0;
                        while (!double.TryParse(Console.ReadLine(), out price) || price <= 0.0)
                        {
                            Console.Write("Ошибка! Введите число больше 0: ");
                        }
                        Console.WriteLine();
                        List<Shop> res = WorkWithShop.GetExpensive(way, price);
                        for (int i = 0; i < res.Count; i++)
                        {
                            Console.WriteLine(res[i]);
                            Console.WriteLine("---------------------");
                        }
                        break;
                    }
                case 5:
                    {
                        Console.Write("Введите минимальное количество: ");
                        int limit = 0;
                        while (!int.TryParse(Console.ReadLine(), out limit) || limit <= 0)
                        {
                            Console.Write("Ошибка! Введите целое число больше 0: ");
                        }
                        Console.WriteLine();
                        List<Shop> res = WorkWithShop.LowStock(way, limit);
                        for (int i = 0; i < res.Count; i++)
                        {
                            Console.WriteLine(res[i]);
                            Console.WriteLine("---------------------");
                        }
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Средняя цена: " + WorkWithShop.AveragePrice(way));
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Самый дорогой товар: ");
                        Shop max = WorkWithShop.ExpensiveProduct(way);
                        Console.WriteLine(max);
                        break;
                    }
                case 0:
                    {
                        return;
                    }

                default:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Неверный выбор!");
                        break;
                    }
            }
        }
    }
}