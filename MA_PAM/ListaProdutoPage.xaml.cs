namespace MA_PAM;

public partial class ListaProdutoPage : ContentPage
{
	public ListaProdutoPage()
	{
        List<Produto> lista = Produto.Listar;
        InitializeComponent();
		lstProduto.ItemsSource = lista;
    }

    private void ViewCell_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProdutoPage() { BindingContext = ((ViewCell)sender).BindingContext});
    }

    private void FiltrarPorCategoria(object sender, EventArgs e) 
    {
        string categoriaSelecionada = filtroCategoriaPicker.SelectedItem?.ToString() ?? "Todos";
        if (categoriaSelecionada == "Todas")
        {
            produtoListView.ItemsSource = MainPage.Produto.OrderBy(p => p.Acessórios).ToList();
        }
        else 
        { 
        
        }

    }
}