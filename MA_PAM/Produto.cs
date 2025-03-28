using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_PAM
{
    internal class Produto
    {
        public double preco { get; set; }

        public string nome { get; set; }

        public string categoria { get; set; }

        public int estoque { get; set; }

        public double desconto { get; set; }

        public string marca { get; set; }

        public static List<Produto> Listar
        {
            get
            {
                List<Produto> lista = new List<Produto>();
                lista.Add(new Produto() { nome = "Camiseta Polo", preco = 80, categoria = "Vestuário", estoque = 200, marca = "Lacoste", desconto = 10 });
                lista.Add(new Produto() { nome = "Calça Jeans", preco = 150, categoria = "Vestuário", estoque = 100, marca = "Levi's", desconto = 5 });
                lista.Add(new Produto() { nome = "Tênis Esportivo", preco = 300, categoria = "Calçados", estoque = 50, marca = "Nike", desconto = 20 });
                lista.Add(new Produto() { nome = "Jaqueta de Couro", preco = 500, categoria = "Vestuário", estoque = 30, marca = "Calvin Klein", desconto = 15 });
                lista.Add(new Produto() { nome = "Sapato Social", preco = 400, categoria = "Calçados", estoque = 40, marca = "Ferracini", desconto = 10 });

                lista.Add(new Produto() { nome = "Meia Algodão", preco = 20, categoria = "Vestuário", estoque = 500, marca = "Lupo", desconto = 5 });
                lista.Add(new Produto() { nome = "Boné Esportivo", preco = 60, categoria = "Acessórios", estoque = 150, marca = "Adidas", desconto = 10 });
                lista.Add(new Produto() { nome = "Relógio Analógico", preco = 350, categoria = "Acessórios", estoque = 80, marca = "Casio", desconto = 8 });
                lista.Add(new Produto() { nome = "Mochila Executiva", preco = 250, categoria = "Acessórios", estoque = 60, marca = "Samsonite", desconto = 12 });
                lista.Add(new Produto() { nome = "Óculos de Sol", preco = 220, categoria = "Acessórios", estoque = 90, marca = "Ray-Ban", desconto = 10 });

                lista.Add(new Produto() { nome = "Luvas de Couro", preco = 180, categoria = "Vestuário", estoque = 40, marca = "Calvin Klein", desconto = 10 });
                lista.Add(new Produto() { nome = "Bermuda Jeans", preco = 120, categoria = "Vestuário", estoque = 120, marca = "Diesel", desconto = 7 });
                lista.Add(new Produto() { nome = "Carteira de Couro", preco = 130, categoria = "Acessórios", estoque = 200, marca = "Montblanc", desconto = 5 });
                lista.Add(new Produto() { nome = "Cinto de Couro", preco = 90, categoria = "Acessórios", estoque = 170, marca = "Hugo Boss", desconto = 8 });
                lista.Add(new Produto() { nome = "Jaqueta Esportiva", preco = 280, categoria = "Vestuário", estoque = 70, marca = "Nike", desconto = 12 });


                return lista;
            }
        }
    }
}
