
namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

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
            await Application.Current.MainPage.Navigation.PushAsync(new GlosarioPage());
        }
        #endregion
    }
}
