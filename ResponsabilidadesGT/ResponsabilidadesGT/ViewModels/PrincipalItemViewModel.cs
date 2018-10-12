namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using ResponsabilidadesGT.Views;
    using System.Windows.Input;

    public class PrincipalItemViewModel:Glosario
    {
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
            await App.Navigator.PushAsync(new PreferenciaPage());
        }


    }
}
