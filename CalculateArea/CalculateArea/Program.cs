using System;
using System.Collections.Generic;
using System.Globalization;
using CalculateArea.Entities;
using CalculateArea.Entities.Enums;

namespace CalculateArea
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int quantity = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Shape # {i} data: ");
                Console.Write("Rectangle or Cicle (r/c)? ");
                char choice = char.Parse(Console.ReadLine());

                if (choice == 'r')
                {
                    Console.Write("Color (Black/Blue/Red): ");
                    Color color = (Color)Enum.Parse(typeof(Color), Console.ReadLine());
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine());
                    list.Add(new Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Color (Black/Blue/Red): ");
                    Color color = (Color)Enum.Parse(typeof(Color), Console.ReadLine());
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    list.Add(new Circle(color, radius));
                }
            }
            Console.WriteLine("SHAPES AREAS: ");
            foreach (Shape all in list)
            {
                Console.WriteLine(all.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
