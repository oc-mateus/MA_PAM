using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MA_PAM;

namespace MA_PAM
{
    public class Produto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;

        public double Preco { get; set; }
        public double Desconto { get; set; }
        public int Estoque { get; set; }

        public DateTime? Validade { get; set; }

        public string? CaminhoImagem { get; set; }

        [JsonIgnore]
        public string ValidadeFormatada => Validade?.ToString("dd/MM/yyyy") ?? "Sem validade";

        [JsonIgnore]
        public string PrecoFormatado => $"R$ {Preco:F2}";

        public static List<Produto> Produtos = new List<Produto>
        {
            new Produto() { Nome = "Camiseta Polo", Preco = 80, Categoria = "Vestuário", Estoque = 200, Marca = "Lacoste", Desconto = 10, Validade = DateTime.Now.AddDays(30) },
            new Produto() { Nome = "Calça Jeans", Preco = 150, Categoria = "Vestuário", Estoque = 100, Marca = "Levi's", Desconto = 5, Validade = DateTime.Now.AddDays(-5) },
            new Produto() { Nome = "Tênis Esportivo", Preco = 300, Categoria = "Calçados", Estoque = 50, Marca = "Nike", Desconto = 20, Validade = DateTime.Now.AddMonths(2) },
            new Produto() { Nome = "Jaqueta de Couro", Preco = 500, Categoria = "Vestuário", Estoque = 30, Marca = "Calvin Klein", Desconto = 15, Validade = DateTime.Now.AddDays(15) },
            new Produto() { Nome = "Sapato Social", Preco = 400, Categoria = "Calçados", Estoque = 40, Marca = "Ferracini", Desconto = 10 },
            new Produto() { Nome = "Meia Algodão", Preco = 20, Categoria = "Vestuário", Estoque = 500, Marca = "Lupo", Desconto = 5 },
            new Produto() { Nome = "Boné Esportivo", Preco = 60, Categoria = "Acessórios", Estoque = 150, Marca = "Adidas", Desconto = 10, Validade = DateTime.Now.AddDays(-1) },
            new Produto() { Nome = "Relógio Analógico", Preco = 350, Categoria = "Acessórios", Estoque = 80, Marca = "Casio", Desconto = 8 },
            new Produto() { Nome = "Mochila Executiva", Preco = 250, Categoria = "Acessórios", Estoque = 60, Marca = "Samsonite", Desconto = 12 },
            new Produto() { Nome = "Óculos de Sol", Preco = 220, Categoria = "Acessórios", Estoque = 90, Marca = "Ray-Ban", Desconto = 10, Validade = DateTime.Now.AddDays(10) },
            new Produto() { Nome = "Luvas de Couro", Preco = 180, Categoria = "Vestuário", Estoque = 40, Marca = "Calvin Klein", Desconto = 10 },
            new Produto() { Nome = "Bermuda Jeans", Preco = 120, Categoria = "Vestuário", Estoque = 120, Marca = "Diesel", Desconto = 7, Validade = DateTime.Now.AddDays(60) },
            new Produto() { Nome = "Carteira de Couro", Preco = 130, Categoria = "Acessórios", Estoque = 200, Marca = "Montblanc", Desconto = 5 },
            new Produto() { Nome = "Cinto de Couro", Preco = 90, Categoria = "Acessórios", Estoque = 170, Marca = "Hugo Boss", Desconto = 8 },
            new Produto() { Nome = "Jaqueta Esportiva", Preco = 280, Categoria = "Vestuário", Estoque = 70, Marca = "Nike", Desconto = 12, Validade = DateTime.Now.AddDays(-10) }
        };
    }
}
