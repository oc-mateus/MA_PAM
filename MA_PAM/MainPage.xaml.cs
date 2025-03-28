namespace MA_PAM
{
    public partial class MainPage : ContentPage
    {
    

        public MainPage()
        {
            InitializeComponent();
        }

       

        private void BtnCatalogo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutoPage());
        }

    }

}
