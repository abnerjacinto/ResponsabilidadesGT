using GalaSoft.MvvmLight.Command;
using ResponsabilidadesGT.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResponsabilidadesGT.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        #region Service
        private ApiService apiservice;
        #endregion
        #region attributes
        private string name;
        private string email;
        private string password;
        private string rPassword;
        private bool isRunning;
        private bool isEnabled;
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetValue(ref name, value);
            }
        }
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }
        public string RPassword
        {
            get { return rPassword; }
            set { SetValue(ref rPassword, value); }
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
        #region Constructor
        public RegisterViewModel()
        {
            this.apiservice = new ApiService();
            this.IsEnabled = true;
            
        }
        #endregion
        #region Cammand
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        private async void Register()
        {
            //Validacion();
            this.IsRunning = true;
            this.IsEnabled = false;
            var connection = await this.apiservice.CheckConnection();
            if (!connection.IsSuccess)
            {
               
               await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "ok");
                this.IsRunning = false;
                this.IsEnabled = true;
                return;
            }
            
            var url = Application.Current.Resources["UrlAPI"].ToString();
            
            var response = await this.apiservice.createuser($"{url}/",
            $"name={this.Name}&email={this.Email}&password={this.Password}&confirmarpassword={this.RPassword}&usuarioadiciono={this.Name}&slctipousuario=2");
            if (!response.Success)
            {
                
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                this.IsRunning = false;
                this.IsEnabled = true;
                return;
            }
            else
            {

                await Application.Current.MainPage.DisplayAlert(
                   "Creado",
                   response.Message,
                   "Aceptar");
                this.IsEnabled = true;
                this.IsRunning = false;
                this.Name = string.Empty;
                this.Email = string.Empty;
                this.Password = string.Empty;
                this.RPassword = string.Empty;
                return;
            }

        }

        private async void Validacion()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario obligatorio",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese Correo",
                    "Aceptar");
                
                return;
            }
            else
            {
                bool isEmail = Regex.IsMatch(
                    this.Email,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Advertencia", 
                        "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.",
                        "Aceptar");
                    this.Email = string.Empty;
                    return;
                }
            }
            
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese contraseña",
                    "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.RPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese nuevamente su contraseña",
                    "Aceptar");
                return;
            }
            
            if (this.Password != this.RPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "La contraseña debe ser el mismo.",
                    "Aceptar");
                this.Password= string.Empty;
                this.RPassword = string.Empty;
                return;
            }


        }
        #endregion
    }
}
