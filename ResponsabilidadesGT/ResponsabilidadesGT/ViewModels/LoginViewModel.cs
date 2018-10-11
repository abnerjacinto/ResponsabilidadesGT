﻿namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;
    using Views;
    using System.Text.RegularExpressions;
    using ResponsabilidadesGT.Helpers;

    public class LoginViewModel:BaseViewModel
    {
        #region Service
        private ApiService apiservice;
        #endregion

        #region attributes
        private string email;
            private string password;
            private bool isEnabled; 
            private bool isRunning;
        #endregion
        #region Propierties
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
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemember { get; set; }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.apiservice = new ApiService();
            this.IsRemember = true;
            this.IsEnabled = true;
        }
        #endregion
        #region Commad
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese correo electrónico",
                    "Aceptar");

                return;
            }
            else
            {
             /*   bool isEmail = Regex.IsMatch(
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
                }*/
                if (string.IsNullOrEmpty(this.Password))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debe de ingresar una contraseña",
                        "Aceptar");
                    return;
                }
                this.IsEnabled = false;
                this.IsRunning = true;
                var connection = await this.apiservice.CheckConnection();
                if (!connection.IsSuccess)
                {
                    this.IsEnabled = true;
                    this.IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        connection.Message,
                        "Ok");
                    return;
                }
                var url = Application.Current.Resources["UrlAPI"].ToString();
                var fix = Application.Current.Resources["UrlFix"].ToString();
                var res = Application.Current.Resources["UrlRes"].ToString();
                var token = await this.apiservice.GetToken($"{url}{fix}{res}/", this.Email, this.Password);

                if (token==null)
                {
                    this.IsEnabled = true;
                    this.IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Operación no completada, porfavor intente otra vez",
                        "ok");
                    return;

                }
                if (!token.Success)
                {
                    this.IsEnabled = true;
                    this.IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        token.Message,
                        "ok");
                    this.Password = string.Empty;
                    return;
                }
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = token.Token;
                //mainViewModel.TokenType = token.TokenType;
                if(this.IsRemember)
                {
                    Settings.Token = token.Token;
                    //Settings.TokenType = token.TokenType;
                }

                //mainViewModel.Responsabilidades = new ResponsabilidadesViewModel();
                Application.Current.MainPage=new MasterPage();

                this.IsEnabled = true;
                this.IsRunning = false;

                this.Email = string.Empty;
                this.Password = string.Empty;


            }
        }
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }
        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

            #endregion
        }
}
