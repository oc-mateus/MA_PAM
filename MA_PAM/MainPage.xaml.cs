using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
using System.Linq;
using MA_PAM;
using System.Text.Json;

namespace MA_PAM
{
    public partial class MainPage : ContentPage
    {
        public static List<Produto> Produtos { get; set; } = ProdutoStorage.CarregarProdutos();

        private string caminhoImagemSelecionada;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCatalogo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaProdutoPage());
        }

        private async void btnAdicionarProduto_Clicked(object sender, EventArgs e)
        {
            try
            {
                var produto = new Produto
                {
                    Nome = txtNome.Text,
                    Preco = double.TryParse(txtPreco.Text, out double preco) ? preco : 0,
                    Categoria = pickerCategoria.SelectedItem?.ToString() ?? "",
                    Estoque = int.TryParse(txtEstoque.Text, out int estoque) ? estoque : 0,
                    Desconto = double.TryParse(txtDesconto.Text, out double desconto) ? desconto : 0,
                    Marca = txtMarca.Text,
                    Validade = dateValidade.Date,
                    CaminhoImagem = caminhoImagemSelecionada
                };

                Produtos.Add(produto);
                ProdutoStorage.SalvarProdutos(Produtos);

                await DisplayAlert("Sucesso", "Produto adicionado!", "OK");
                LimparCampos();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }

        private async void SelecionarImagem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var resultado = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Selecione uma imagem",
                    FileTypes = FilePickerFileType.Images
                });

                if (resultado != null)
                {
#if WINDOWS
            caminhoImagemSelecionada = resultado.FullPath;
#elif ANDROID || IOS
                    // Em plataformas móveis, usar stream:
                    using var stream = await resultado.OpenReadAsync();
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    var bytes = memoryStream.ToArray();
                    caminhoImagemSelecionada = resultado.FileName;

                    // Salvar localmente se necessário
                    var localPath = Path.Combine(FileSystem.AppDataDirectory, caminhoImagemSelecionada);
                    File.WriteAllBytes(localPath, bytes);
                    caminhoImagemSelecionada = localPath;
#endif

                    previewImagem.Source = ImageSource.FromFile(caminhoImagemSelecionada);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao selecionar imagem: {ex.Message}", "OK");
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            pickerCategoria.SelectedIndex = -1;
            txtEstoque.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            txtMarca.Text = string.Empty;
            dateValidade.Date = DateTime.Today;
            previewImagem.Source = null;
            caminhoImagemSelecionada = null;
        }
    }
}
