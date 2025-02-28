namespace EjemploMAUI.Pages;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private async void bBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}