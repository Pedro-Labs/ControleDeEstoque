using System;
using System.Collections.Generic;

namespace ControleDeEstoque
{
    class Program
    {
        public class Produto
        {
            public string Nome { get; set; }
            public int QuantidadeEmEstoque { get; set; }
        }

        static void Main(string[] args)
        {
            List<Produto> estoque = new List<Produto>();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Controle de Estoque");
                Console.WriteLine("===================");

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Registrar Entrada de Produto");
                Console.WriteLine("2 - Registrar Saída de Produto");
                Console.WriteLine("3 - Consultar Estoque");
                Console.WriteLine("4 - Encerrar");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o nome do produto: ");
                        string nomeProduto = Console.ReadLine();

                        Console.Write("Digite a quantidade em estoque: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        Produto produto = new Produto { Nome = nomeProduto, QuantidadeEmEstoque = quantidade };
                        estoque.Add(produto);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Write("Digite o nome do produto: ");
                        string produtoSaida = Console.ReadLine();

                        Console.Write("Digite a quantidade vendida: ");
                        int quantidadeSaida = int.Parse(Console.ReadLine());

                        foreach (var p in estoque)
                        {
                            if (p.Nome.ToLower() == produtoSaida.ToLower())
                            {
                                if (quantidadeSaida <= p.QuantidadeEmEstoque)
                                {
                                    p.QuantidadeEmEstoque -= quantidadeSaida;
                                    Console.WriteLine($"{quantidadeSaida} unidades de {produtoSaida} foram vendidas.");
                                }
                                else
                                {
                                    Console.WriteLine($"Estoque insuficiente para {produtoSaida}.");
                                }
                                break;
                            }
                        }
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Produtos em Estoque:");
                        foreach (var p in estoque)
                        {
                            Console.WriteLine($"{p.Nome} - Quantidade em Estoque: {p.QuantidadeEmEstoque}");
                        }
                        Console.WriteLine();
                        break;

                    case 4:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
