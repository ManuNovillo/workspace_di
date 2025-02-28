namespace EjemploMAUI.Pages;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
	}

    private async void bBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}
