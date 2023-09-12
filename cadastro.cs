using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> produtos = new List<Produto>();
    static int proximoId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar um produto");
            Console.WriteLine("2. Remover um produto pelo ID");
            Console.WriteLine("3. Editar o nome de um produto pelo ID");
            Console.WriteLine("4. Visualizar todos os produtos");
            Console.WriteLine("5. Sair");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AdicionarProduto();
                    break;
                case "2":
                    RemoverProduto();
                    break;
                case "3":
                    EditarProduto();
                    break;
                case "4":
                    VisualizarProdutos();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine();
        Produto produto = new Produto { Id = proximoId, Nome = nome };
        produtos.Add(produto);
        proximoId++;
        Console.WriteLine("Produto adicionado com sucesso.");
    }
//remover produtos 
    static void RemoverProduto()
    {
        Console.WriteLine("Digite o ID do produto que deseja remover:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = produtos.Find(p => p.Id == id);
            if (produto != null)
            {
                produtos.Remove(produto);
                Console.WriteLine("Produto removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }
//editar produtos
    static void EditarProduto()
    {
        Console.WriteLine("Digite o ID do produto que deseja editar:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = produtos.Find(p => p.Id == id);
            if (produto != null)
            {
                Console.WriteLine("Digite o novo nome do produto:");
                string novoNome = Console.ReadLine();
                produto.Nome = novoNome;
                Console.WriteLine("Nome do produto editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    //visualizar produtos

    static void VisualizarProdutos()
    {
        Console.WriteLine("Lista de Produtos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}");
        }
    }
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
