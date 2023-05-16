using AplicativoAlimentos;
using System;
using System.Collections.Generic;

namespace AplicativoAlimentos
{
    class Alimento
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    class Program
    {
        static List<Alimento> alimentos = new List<Alimento>();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("========== Aplicativo de Alimentos ==========");
                Console.WriteLine("1 - Adicionar alimento");
                Console.WriteLine("2 - Listar alimentos");
                Console.WriteLine("3 - Buscar alimento");
                Console.WriteLine("4 - Remover alimento");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("============================================");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarAlimento();
                        break;
                    case "2":
                        ListarAlimentos();
                        break;
                    case "3":
                        BuscarAlimento();
                        break;
                    case "4":
                        RemoverAlimento();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AdicionarAlimento()
        {
            Console.WriteLine("========== Adicionar Alimento ==========");

            Console.Write("Digite o nome do alimento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço do alimento: ");
            decimal preco;
            while (!decimal.TryParse(Console.ReadLine(), out preco))
            {
                Console.WriteLine("Valor inválido. Digite um preço válido: ");
            }

            alimentos.Add(new Alimento { Nome = nome, Preco = preco });

            Console.WriteLine("Alimento adicionado com sucesso!");
        }

        static void ListarAlimentos()
        {
            Console.WriteLine("========== Lista de Alimentos ==========");

            if (alimentos.Count == 0)
            {
                Console.WriteLine("Nenhum alimento cadastrado.");
            }
            else
            {
                foreach (var alimento in alimentos)
                {
                    Console.WriteLine($"Nome: {alimento.Nome}, Preço: {alimento.Preco:C}");
                }
            }
        }

        static void BuscarAlimento()
        {
            Console.WriteLine("========== Buscar Alimento ==========");

            Console.Write("Digite o nome do alimento a ser buscado: ");
            string nome = Console.ReadLine();

            List<Alimento> resultados = alimentos.FindAll(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum alimento encontrado com o nome especificado.");
            }
            else
            {
                Console.WriteLine($"Foram encontrados {resultados.Count} alimentos com o nome '{nome}':");
                foreach (var alimento in resultados)
                {
                    Console.WriteLine($"Nome: {alimento.Nome}, Preço: {alimento.Preco:C}");
                }
            }
        }
         static void RemoverAlimento()
        {
            Console.WriteLine("========== Remover Alimento ==========");

            Console.Write("Digite o nome do alimento a ser removido: ");
            string nome = Console.ReadLine();

            Alimento alimento = alimentos.Find(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (alimento != null)
            {
                alimentos.Remove(alimento);
                Console.WriteLine("Alimento removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Nenhum alimento encontrado com o nome especificado.");
            }
        }






    }






}
