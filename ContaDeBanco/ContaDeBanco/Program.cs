using System;
using System.Collections.Generic;
using ContaDeBanco.Entities;
using System.Globalization;


namespace ContaDeBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.WriteLine("Quantidade de Funcionários? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantidade; i++)
            {
                Console.WriteLine($"Empregado número #{i}");
                Console.Write("Terceirizado? y/n ?");
                char pergunta = char.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Horas trabalhadas: ");
                int horasTrabalhadas = int.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (pergunta == 'y')
                {
                    Console.Write("Valor adicional:");
                    double valorAdicional = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new OutsourcedEmployee(nome, horasTrabalhadas, valorHora, valorAdicional));
                }
                else
                {
                    list.Add(new Employee(nome, horasTrabalhadas, valorHora));
                }
            }

            Console.WriteLine("Pagamentos : ");
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}