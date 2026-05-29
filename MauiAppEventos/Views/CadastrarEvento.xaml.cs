using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastrarEvento : ContentPage
{
    public CadastrarEvento()
    {
        InitializeComponent();

        // aqui eu travo a data inicial como hj
        dt_inicio.MinimumDate = DateTime.Today;
    }

    private void dt_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (dt_inicio.Date.HasValue)
        {
            //recebe a data passada.
            DatePicker elemento = sender as DatePicker;
            // a variável data_selecionada é do tipo DateTime
            DateTime data_selecionada = elemento.Date.Value;
            dt_fim.MinimumDate = data_selecionada.AddDays(1);
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(txt_nome_evento.Text))
        {
            await DisplayAlert("Ops", "Preencha o Nome do Evento", "ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(txt_local_evento.Text))
        {
            await DisplayAlert("Ops", "Informo o Local onde Ocorrerá o Evento", "ok");
            return;
        }

        if (Convert.ToInt32(stp_quantidade.Value) == 0)
        {
            await DisplayAlert("Ops", "Inform a quantidade de participantes", "ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(txt_vlr_por_participante.Text))
        {
            await DisplayAlert("Ops", "Inform o valor por participante", "ok");
            return;
        }

        Evento eventoCadastrado = new Evento
        {
            NomeDoEvento = txt_nome_evento.Text,
            LocalDoEvento = txt_local_evento.Text,
            DataInicio = dt_inicio.Date.Value,
            DataFim = dt_fim.Date.Value,
            NroParticipantes = Convert.ToInt32(stp_quantidade.Value),
            CustoPorParticipante = Convert.ToDouble(txt_vlr_por_participante.Text)

        };

        var proxima_tela = new Views.RelatorioEvento();
        proxima_tela.BindingContext = eventoCadastrado;

        await Navigation.PushAsync(proxima_tela);

    }
}
