using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MA_PAM;

public partial class ListaProdutoPage : ContentPage
{
    private List<Produto> produtos = Produto.Listar;

    public ListaProdutoPage()
    {
        InitializeComponent();
        lstProduto.ItemsSource = produtos.OrderBy(p => p.Validade).ToList();
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
            produtosFiltrados = produtos;
        }
        else
        {
            produtosFiltrados = produtos
                .Where(p => p.categoria == categoriaSelecionada);
        }

        lstProduto.ItemsSource = produtosFiltrados
            .OrderBy(p => p.Validade)
            .ToList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        lstProduto.ItemsSource = produtos.OrderBy(p => p.Validade).ToList();
    }
}
