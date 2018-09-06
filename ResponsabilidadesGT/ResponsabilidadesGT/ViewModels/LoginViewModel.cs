namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class LoginViewModel:BaseViewModel
    {

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
                    "Debe de ingresar un correo",
                    "Ok");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe de ingresar una contraseña",
                    "Ok");
                return;
            }
            if (this.Email!="abner.jacinto@gmail.com" || this.Password!="1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo o contraseña no son válidos",
                    "Ok");
                return;
            }
            this.IsEnabled = true;
            this.IsRunning = false;

            this.Email = string.Empty;
            this.Password = string.Empty;
            MainViewModel.GetInstance().Responsabilidades = new ResponsabilidadesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ResponsabilidadesPage());
        }
        #endregion
    }
}
