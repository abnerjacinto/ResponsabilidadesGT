

namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    using ResponsabilidadesGT.Views;
    using Xamarin.Forms;

    public class GlosarioItemViewModel:Glosario
    {
        #region Construct
        private async void SelectPuntos()
        {
            MainViewModel.GetInstance().PuntoAtencion = new PuntoAtencionViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PuntoAtencionPage());
        }
        #endregion
    }
}
