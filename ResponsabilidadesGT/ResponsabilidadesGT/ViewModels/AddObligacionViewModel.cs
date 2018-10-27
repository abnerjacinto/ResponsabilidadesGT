using GalaSoft.MvvmLight.Command;
using ResponsabilidadesGT.Models;
using ResponsabilidadesGT.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResponsabilidadesGT.ViewModels
{
    public class AddObligacionViewModel:BaseViewModel
    {
        #region Service
        private DataService dataService;
        #endregion

        #region attributes
        private string nombreObligacion;
        private bool isEnabled;
        private bool isRunning;
        #endregion
        #region Properties
        public string NombreObligacion
        {
            get { return nombreObligacion; }
            set { SetValue(ref nombreObligacion, value); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
       
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion
        #region Construct
        public AddObligacionViewModel()
        {
            this.dataService = new DataService();
            this.IsEnabled = true;
        }
        #endregion
        #region ICommand
        public ICommand AddObligacionCommand
        {
            get
            {
                return new RelayCommand(AgregarObligacion);
            }
        }

        private async void AgregarObligacion()
        {
            this.IsEnabled = false;
            this.IsRunning = true;
            if (string.IsNullOrEmpty(this.NombreObligacion))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe de ingresar una nombre obligación",
                    "Aceptar");
                this.IsEnabled = true;
                this.IsRunning = false;
                return;
            }
            
            Obligacion obli = new Obligacion();
            //se asigna valores al objeto Obligacion en base a IEnumerable
            
                
                obli.IdObligacion = 0;
                obli.NombreObligacion = this.NombreObligacion;
                obli.EstadoObligacion = "Activo";
                obli.UsuarioAdicionoObligacion = string.Empty;
                obli.FechaAdicionoObligacion = string.Empty;
                obli.UsuarioModificoObligacion = string.Empty;
                obli.FechaModificoObligacion = string.Empty;
            try
            {
                await dataService.Insert(obli);
                await Application.Current.MainPage.DisplayAlert(
                        "Éxitoso!",
                        "Registro guardado exitosamente",
                        "Aceptar");
                this.IsEnabled = true;
                this.IsRunning = false;

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                                        "Error",
                                        e.Message,
                                        "Aceptar");
            }
           
        }
        #endregion
    }
}
