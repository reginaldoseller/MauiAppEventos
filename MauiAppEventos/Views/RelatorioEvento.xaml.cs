namespace MauiAppEventos.Views;

public partial class RelatorioEvento : ContentPage
{
	public RelatorioEvento()
	{
		InitializeComponent();
	}

    private async void Button_Clicked_Voltar_Fake(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}