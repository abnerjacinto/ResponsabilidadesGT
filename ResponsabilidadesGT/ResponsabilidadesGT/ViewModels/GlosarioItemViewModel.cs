

namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    using Xamarin.Forms;

    public class GlosarioItemViewModel:Glosario
    {
        #region Construct
        private async void SelectPuntos()
        {
            MainViewModel.GetInstance().Glosario = new GlosarioViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PuntoAtencionPage());
        }
        #endregion
    }
}
