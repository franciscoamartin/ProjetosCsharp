using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExerciciosListas.Entities;

namespace ExerciciosListas
{
    class Program
    {
        static List<Pessoa> pessoas = new List<Pessoa>();

        static void Main(string[] args)
        {
            pessoas.Add(new Pessoa("Joao", 24));
            pessoas.Add(new Pessoa("Maria", 24));
            pessoas.Add(new Pessoa("Jose", 34));
            pessoas.Add(new Pessoa("Carlos", 83));
            pessoas.Add(new Pessoa("Bia", 14));
            pessoas.Add(new Pessoa("Osvaldo", 54));
            pessoas.Add(new Pessoa("Pedro", 44));
            pessoas.Add(new Pessoa("Joaquim", 64));
            pessoas.Add(new Pessoa("Allan", 18));
            pessoas.Add(new Pessoa("Thiago", 24));
            Menu();
            Console.ReadKey();
        }

        public static void Menu()
        {
            Console.WriteLine("Menu Pessoas");
            Console.WriteLine();
            Console.WriteLine("Escolha a opção");
            Console.WriteLine("1 - Listar Pessoas em Ordem Alfabética");
            Console.WriteLine("2 - Cadastrar Pessoas");
            Console.WriteLine("3 - Relatório");
            Console.WriteLine("0 - Sair");

            Console.WriteLine();
            var menuEscolhido = int.Parse(Console.ReadLine());

            switch (menuEscolhido)
            {
                case 1:
                    Console.Clear();
                    ListarPessoas();
                    break;
                case 2:
                    Console.Clear();
                    CadastrarPessoa();
                    break;
                case 3:
                    Console.Clear();
                    Relatorio();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Relatorio()
        {
            Console.WriteLine("Pessoa mais velha da lista: ");
            var velha = pessoas.OrderByDescending(x => x.Idade).ToList<Pessoa>()[0];
            Console.WriteLine($"{velha.Nome} com idade de {velha.Idade} é a mais velha da lista");

            Console.WriteLine("Pessoa mais nova da lista: ");
            var nova = pessoas.OrderBy(x => x.Idade).ToList<Pessoa>()[0];
            Console.WriteLine($" {nova.Nome} com {nova.Idade} é a mais nova da lista");

            Console.WriteLine("Soma de todas as idade é: ");
            var soma = pessoas.Sum(item => item.Idade);
            Console.WriteLine(soma + " anos");
            Console.WriteLine();
            Console.WriteLine("Aperte enter para voltar para o menu");
            Console.ReadKey();
            Console.Clear();
            Menu();

        }

        private static void CadastrarPessoa()
        {
            Console.WriteLine("Digite um nome: ");
            var nomeAdd = Console.ReadLine();
            Console.WriteLine("Digite a idade: ");
            var idadeAdd = int.Parse(Console.ReadLine());
            pessoas.Add(new Pessoa(nomeAdd, idadeAdd));
            Console.WriteLine("Cadastro feito com sucesso");
            Console.WriteLine("Aperte enter para voltar para o menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        private static void ListarPessoas()
        {
            pessoas.OrderBy(x => x.Nome).ToList<Pessoa>().ForEach(i => Console.WriteLine($" {i.Nome}"));
            Console.WriteLine("Aperte enter para voltar para o menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
