namespace EjemploMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} vez";
            else
                CounterBtn.Text = $"Clicked {count} veces";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void BIr_Clicked(object sender, EventArgs e)
        {
            Button pulsado = (Button)sender;
            if (pulsado.Text.Equals("Ir a la Calculadora"))
            {
                await Shell.Current.GoToAsync("//Pages.Page1");
            }
            else
            {
                if (pulsado.Text.Equals("Ir al Conversor de Binario"))
                {
                    await Shell.Current.GoToAsync("//Pages.Page2");
                }
            }
            
        }
    }

}
