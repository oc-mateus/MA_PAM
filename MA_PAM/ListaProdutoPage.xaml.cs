using System;
using System.Collections.Generic;
using System.Linq;
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

            var produtos = MainPage.Produtos.OrderBy(p => p.Validade).ToList();
            lstProduto.ItemsSource = produtos;

            // Alerta de vencidos ou prestes a vencer
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
            var produtos = lstProduto.ItemsSource?.Cast<Produto>().ToList();
            int quantidade = produtos?.Count ?? 0;
            double total = produtos?.Sum(p => p.Preco) ?? 0;

            resumoLabel.Text = $"Total: {quantidade} produto(s) - Valor: R$ {total:F2}";
        }

        private async void ViewCell_Tapped(object sender, ItemTappedEventArgs e)
        {
            // Verifica se um item foi selecionado
            if (e.Item != null)
            {
                // Recupera o produto clicado
                var produtoSelecionado = e.Item as Produto;  // Ajuste "Produto" conforme o tipo do seu modelo

                // Navega até a ProdutoPage e passa o produto selecionado
                await Navigation.PushAsync(new ProdutoPage { BindingContext = produtoSelecionado });

                // Desmarca o item após a navegação
                ((ListView)sender).SelectedItem = null;
            }
        }


        private void FiltrarPorCategoria(object sender, EventArgs e)
        {
            string categoriaSelecionada = filtroCategoriaPicker.SelectedItem?.ToString() ?? "Todas";

            IEnumerable<Produto> produtosFiltrados;

            if (categoriaSelecionada == "Todas")
            {
                produtosFiltrados = MainPage.Produtos;
            }
            else
            {
                produtosFiltrados = MainPage.Produtos
                    .Where(p => p.Categoria == categoriaSelecionada);
            }

            lstProduto.ItemsSource = produtosFiltrados
                .OrderBy(p => p.Validade)
                .ToList();

            AtualizarResumo();
        }

       
    }
}
