namespace MA_PAM;

public partial class ProdutoPage : ContentPage
{
	public ProdutoPage()
	{
        InitializeComponent();
        
    }

    private async void OnRemoveProdutoClicked(object sender, EventArgs e)
    {
        if (BindingContext is Produto produto)
        {
            bool confirmar = await DisplayAlert("Remover Produto",
                $"Deseja remover o produto \"{produto.Nome}\"?", "Sim", "Não");

            if (confirmar)
            {
                MainPage.Produtos.Remove(produto);
                ProdutoStorage.SalvarProdutos(MainPage.Produtos);

                await Navigation.PopAsync(); // Volta para a página anterior (Lista)
            }
        }
    }
}