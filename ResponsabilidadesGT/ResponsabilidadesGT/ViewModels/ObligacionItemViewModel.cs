
namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Interfaces;
    using ResponsabilidadesGT.Services;

    public class ObligacionItemViewModel: Obligacion
    {
        #region Commands
        public ICommand SelectObligacionCommand
        {
            get
            {
                return new RelayCommand(SelectObligacion);
            }
        }

        private async void SelectObligacion()
        {
            MainViewModel.GetInstance().Glosario = new GlosarioViewModel(this);
            await App.Navigator.PushAsync(new GlosarioPage());
        }

        public ICommand SelectPrefencesCommand
        {
            get
            {
                return new RelayCommand(LoadPreferences);
            }
        }

        private async void LoadPreferences()
        {
            MainViewModel.GetInstance().Preferencia = new PreferenciaViewModel();
            await App.Navigator.PushAsync(new PreferenciaPage(),true);
            NotificationService Noty = new NotificationService();
            Noty.Show("Test", "This is a test notification from the future.", 0, DateTime.Now.AddSeconds(10),true,true);
           
        }
        #endregion
    }
}
