
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

            NotificationService Noty = new NotificationService();
            Noty.Show("Test", "This is a test notification from the future.", 0, DateTime.Now.AddSeconds(10),true,true);
           
        }
        private async void DeleteObligacion()
        {
            Obligacion obligacion = new Obligacion();
            obligacion.IdObligacion = this.IdObligacion;
            obligacion.NombreObligacion = this.NombreObligacion;
            obligacion.EstadoObligacion = this.EstadoObligacion;
            obligacion.UsuarioAdicionoObligacion = this.UsuarioAdicionoObligacion;
            obligacion.FechaAdicionoObligacion = this.FechaAdicionoObligacion;
            obligacion.UsuarioModificoObligacion = this.UsuarioModificoObligacion;
            obligacion.FechaModificoObligacion = this.FechaModificoObligacion;
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
            }
                
        }
        #endregion
    }
}
