using GalaSoft.MvvmLight.Command;
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
        #region attributes
        private string name;
        private string email;
        private string rEmail;
        private string password;
        private string rPassword;
        private bool isRunning;
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
        public string REmail
        {
            get { return rEmail; }
            set { SetValue(ref rEmail, value); }
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
        #endregion
        #region Constructor

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
            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El nombre es obligatorio",
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
            if (string.IsNullOrEmpty(this.REmail))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese nuevamente su correo",
                    "Aceptar");
                return;
            }
            else
            {
                bool isEmail = Regex.IsMatch(
                    this.REmail,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Advertencia",
                        "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.",
                        "Aceptar");
                    this.REmail = string.Empty;
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
            if (this.Email!=this.REmail)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El correo debe ser el mismo.",
                    "Aceptar");
                this.Email = string.Empty;
                this.REmail = string.Empty;
                return;
            }
            if (this.Password != this.RPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "La contraseña debe ser el mismo.",
                    "Aceptar");
                this.Email = string.Empty;
                this.REmail = string.Empty;
                return;
            }

        }
        #endregion
    }
}
