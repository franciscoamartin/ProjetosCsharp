using System;
using System.Collections.Generic;
using Alfandega.Entities;
using System.Globalization;

namespace Alfandega
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int numberProducts = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberProducts; i++)
            {
                Console.WriteLine("Product # " + i + " data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char typeProduct = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (typeProduct == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if (typeProduct == 'u')

                {
                    Console.WriteLine("Manufacture date(DD / MM / YYYY): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, data));
                }
                else
                {
                    Console.Write("Customs Fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }

            }
            Console.WriteLine("Price Tags: ");
            foreach (Product n in list)
            {
                Console.WriteLine(n.PriceTag());
            }

            Console.ReadKey();
        }
    }
}

