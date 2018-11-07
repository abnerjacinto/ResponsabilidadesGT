
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
    using ObligacionesGT.Views;

    public class ObligacionItemViewModel: Obligacion
    {
        
        private DataService dataservice;
        #region Commands
        public ICommand SelectObligacionCommand
        {
            get
            {
                return new RelayCommand(SelectObligacion);
            }
        }
        public ICommand SelectPrefencesCommand
        {
            get
            {
                return new RelayCommand(LoadPreferences);
            }
        }
        public ICommand DeleteObligacionCommand
        {
            get
            {
                return new RelayCommand(DeleteObligacion);
            }
        }

       

        #endregion
        #region Methods
        private async void SelectObligacion()
        {
            MainViewModel.GetInstance().Glosario = new GlosarioViewModel(this);
            await App.Navigator.PushAsync(new GlosarioPage());
        }

        

        private async void LoadPreferences()
        {
            MainViewModel.GetInstance().Preferencia = new PreferenciaViewModel(this);
            await App.Navigator.PushAsync(new PreferenciaPage(),true);

           
        }
        private async void DeleteObligacion()
        {
            Obligacion obligacion = new Obligacion();
            obligacion.ID = this.ID;
            obligacion.IdObligacion = this.IdObligacion;
            obligacion.NombreObligacion = this.NombreObligacion;
            obligacion.EstadoObligacion = this.EstadoObligacion;
            
            var result = await Application.Current.MainPage.DisplayAlert(
                "Eliminar",
                "Desea eliminar los datos de su Obligación",
                "Aceptar",
                "Cancelar");
            if (result == true)
            {
                this.dataservice = new DataService();
                await dataservice.Delete(obligacion);
                await dataservice.dbClose();
                MainViewModel.GetInstance().Principal = new PrincipalViewModel();
                Application.Current.MainPage = new MasterPage();
            }
                
        }
        #endregion
    }
}
