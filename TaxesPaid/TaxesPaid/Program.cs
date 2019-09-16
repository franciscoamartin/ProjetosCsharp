using System;
using TaxesPaid.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace TaxesPaid
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int numberEmployee = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberEmployee; i++)
            {
                Console.WriteLine($"Tax Payer # {i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char choice = char.Parse(Console.ReadLine());

                if (choice == 'i')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine());
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine());
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine());
                    Console.Write("Number of employees: ");
                    int numberEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberEmployee));
                }

            }
            double sum = 0;
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer all in list)
            {
                double tax = all.Tax();
                Console.WriteLine(all.Name + " $ " + tax.ToString("F2"), CultureInfo.InvariantCulture);
                sum += tax;
            }
            Console.WriteLine("TOTAL TAXES: $" + sum.ToString(("F2"), CultureInfo.InvariantCulture));
        }
    }
}
