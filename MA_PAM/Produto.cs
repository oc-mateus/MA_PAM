using System;
using System.Collections.Generic;
using System.Linq;

namespace MA_PAM
{
    internal class Produto
    {
        public string nome { get; set; }
        public double preco { get; set; }
        public string categoria { get; set; }
        public int estoque { get; set; }
        public double desconto { get; set; }
        public string marca { get; set; }

        public DateTime? Validade { get; set; } 

        public string ValidadeFormatada => Validade.HasValue
            ? Validade.Value.ToString("dd/MM/yyyy")
            : "Sem validade"; 

        public static List<Produto> Listar
        {
            get
            {
                List<Produto> lista = new List<Produto>
                {
                    new Produto() { nome = "Camiseta Polo", preco = 80, categoria = "Vestuário", estoque = 200, marca = "Lacoste", desconto = 10, Validade = DateTime.Now.AddDays(30) },
                    new Produto() { nome = "Calça Jeans", preco = 150, categoria = "Vestuário", estoque = 100, marca = "Levi's", desconto = 5, Validade = DateTime.Now.AddDays(-5) }, // vencido
                    new Produto() { nome = "Tênis Esportivo", preco = 300, categoria = "Calçados", estoque = 50, marca = "Nike", desconto = 20, Validade = DateTime.Now.AddMonths(2) },
                    new Produto() { nome = "Jaqueta de Couro", preco = 500, categoria = "Vestuário", estoque = 30, marca = "Calvin Klein", desconto = 15, Validade = DateTime.Now.AddDays(15) },
                    new Produto() { nome = "Sapato Social", preco = 400, categoria = "Calçados", estoque = 40, marca = "Ferracini", desconto = 10 },

                    new Produto() { nome = "Meia Algodão", preco = 20, categoria = "Vestuário", estoque = 500, marca = "Lupo", desconto = 5 },
                    new Produto() { nome = "Boné Esportivo", preco = 60, categoria = "Acessórios", estoque = 150, marca = "Adidas", desconto = 10, Validade = DateTime.Now.AddDays(-1) }, // vencido
                    new Produto() { nome = "Relógio Analógico", preco = 350, categoria = "Acessórios", estoque = 80, marca = "Casio", desconto = 8 },
                    new Produto() { nome = "Mochila Executiva", preco = 250, categoria = "Acessórios", estoque = 60, marca = "Samsonite", desconto = 12 },
                    new Produto() { nome = "Óculos de Sol", preco = 220, categoria = "Acessórios", estoque = 90, marca = "Ray-Ban", desconto = 10, Validade = DateTime.Now.AddDays(10) },

                    new Produto() { nome = "Luvas de Couro", preco = 180, categoria = "Vestuário", estoque = 40, marca = "Calvin Klein", desconto = 10 },
                    new Produto() { nome = "Bermuda Jeans", preco = 120, categoria = "Vestuário", estoque = 120, marca = "Diesel", desconto = 7, Validade = DateTime.Now.AddDays(60) },
                    new Produto() { nome = "Carteira de Couro", preco = 130, categoria = "Acessórios", estoque = 200, marca = "Montblanc", desconto = 5 },
                    new Produto() { nome = "Cinto de Couro", preco = 90, categoria = "Acessórios", estoque = 170, marca = "Hugo Boss", desconto = 8 },
                    new Produto() { nome = "Jaqueta Esportiva", preco = 280, categoria = "Vestuário", estoque = 70, marca = "Nike", desconto = 12, Validade = DateTime.Now.AddDays(-10) } // vencido
                };

                return lista;
            }
        }
    }
}
