using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MA_PAM
{
    public partial class MainPage : ContentPage
    {
        // Lista global de produtos
        private List<Produto> produtos = Produto.Produtos;

        public MainPage()
        {
            InitializeComponent();
        }

        // Método para navegar até o catálogo de produtos
        private void BtnCatalogo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutoPage());
        }

        // Método para adicionar um produto ao catálogo
        private void btnAdicionarProduto_Clicked(object sender, EventArgs e)
        {
            // Obtenha os dados do formulário
            string nome = txtNome.Text;
            double preco = double.TryParse(txtPreco.Text, out var p) ? p : 0;
            string categoria = pickerCategoria.SelectedItem?.ToString();
            int estoque = int.TryParse(txtEstoque.Text, out var E) ? E : 0;
            double desconto = double.TryParse(txtDesconto.Text, out var d) ? d : 0;
            string marca = txtMarca.Text;
            DateTime? validade = dateValidade.Date;

            // Validação básica
            if (string.IsNullOrWhiteSpace(nome) || preco <= 0 || estoque <= 0 || string.IsNullOrWhiteSpace(categoria) || string.IsNullOrWhiteSpace(marca))
            {
                DisplayAlert("Erro", "Por favor, preencha todos os campos corretamente.", "OK");
                return;
            }

            // Criar um novo produto com os dados do formulário
            Produto novoProduto = new Produto
            {
                nome = nome,
                preco = preco,
                categoria = categoria,
                estoque = estoque,
                marca = marca,
                desconto = desconto,
                Validade = validade
            };

            // Adiciona o novo produto à lista
            produtos.Add(novoProduto);

            // Atualizar a lista de produtos no catálogo
            DisplayAlert("Produto Adicionado", "O produto foi adicionado com sucesso!", "OK");

            // Limpar os campos do formulário
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtEstoque.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            txtMarca.Text = string.Empty;
            pickerCategoria.SelectedIndex = -1;
            dateValidade.Date = DateTime.Now;
        }
    }
}
