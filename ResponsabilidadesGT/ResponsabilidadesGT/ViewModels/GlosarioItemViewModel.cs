

namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using ResponsabilidadesGT.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class GlosarioItemViewModel:Glosario
    {
        #region Command
        public ICommand SelectPuntoAtencionCommand
        {
            get
            {
                return new RelayCommand(SelectPuntos);
            }
        }
        public ICommand UrlCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri($"http://{url}"));
        });
        #endregion
        #region Construct
        private async void SelectPuntos()
        {
            MainViewModel.GetInstance().PuntoAtencion = new PuntoAtencionViewModel(this);
            await App.Navigator.PushAsync(new PuntoAtencionPage());
            
        }
        #endregion
    }
}
