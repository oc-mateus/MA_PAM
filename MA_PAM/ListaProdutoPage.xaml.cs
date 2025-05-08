using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MA_PAM
{
    public partial class ListaProdutoPage : ContentPage
    {
        public ListaProdutoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Ordena e exibe os produtos
            var produtos = Produto.Produtos.OrderBy(p => p.Validade).ToList();
            lstProduto.ItemsSource = produtos;

            // Alerta de vencidos ou prestes a vencer (PDF - item 5)
            var hoje = DateTime.Today;
            var vencidos = produtos.Where(p => p.Validade.HasValue && p.Validade.Value < hoje).ToList();
            var proximos = produtos.Where(p => p.Validade.HasValue && p.Validade.Value <= hoje.AddDays(3) && p.Validade.Value >= hoje).ToList();

            if (vencidos.Any() || proximos.Any())
            {
                alertaLabel.Text = $"    Atenção: {vencidos.Count} vencido(s), {proximos.Count} prestes a vencer!";
            }
            else
            {
                alertaLabel.Text = string.Empty;
            }

            AtualizarResumo();
        }

        private void AtualizarResumo()
        {
            var produtos = lstProduto.ItemsSource as List<Produto>;
            int quantidade = produtos?.Count ?? 0;
            double total = produtos?.Sum(p => p.preco) ?? 0;

            resumoLabel.Text = $"Total: {quantidade} produto(s) - Valor: R$ {total:F2}";
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

            AtualizarResumo();
        }

        private async void lstProduto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Produto produto)
            {
                bool confirmar = await DisplayAlert("Remover Produto",
                    $"Deseja remover o produto \"{produto.nome}\"?", "Sim", "Não");

                if (confirmar)
                {
                    Produto.Produtos.Remove(produto);
                    lstProduto.ItemsSource = Produto.Produtos.OrderBy(p => p.Validade).ToList();
                    AtualizarResumo();
                }
            }
        }
    }
}
