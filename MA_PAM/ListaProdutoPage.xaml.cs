using System;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MA_PAM
{
    public partial class ListaProdutoPage : ContentPage
    {
        public ListaProdutoPage()
        {
            InitializeComponent();
            AtualizarListaProdutos();
        }

        // Método para atualizar a lista de produtos
        private void AtualizarListaProdutos()
        {
            // Atualizando a lista de produtos na interface
            lstProduto.ItemsSource = Produto.Produtos.OrderBy(p => p.Validade).ToList();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = sender as ViewCell;
            if (viewCell?.BindingContext is Produto produto)
            {
                Navigation.PushAsync(new ProdutoPage { BindingContext = produto });
            }
        }

        private void FiltrarPorCategoria(object sender, EventArgs e)
        {
            string categoriaSelecionada = filtroCategoriaPicker.SelectedItem?.ToString() ?? "Todas";

            IEnumerable<Produto> produtosFiltrados;

            if (categoriaSelecionada == "Todas")
            {
                produtosFiltrados = Produto.Produtos;
            }
            else
            {
                produtosFiltrados = Produto.Produtos
                    .Where(p => p.categoria == categoriaSelecionada);
            }

            lstProduto.ItemsSource = produtosFiltrados
                .OrderBy(p => p.Validade)
                .ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AtualizarListaProdutos();
        }
    }
}
