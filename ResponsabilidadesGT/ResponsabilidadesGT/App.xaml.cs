namespace ResponsabilidadesGT
{
    using ResponsabilidadesGT.Helpers;
    using ResponsabilidadesGT.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;
    using System;
    using System.Threading.Tasks;
    using ResponsabilidadesGT.Models;
    using ResponsabilidadesGT.Services;

    public partial class App : Application
    {
        public static NavigationPage Navigator
        {
            get; internal set;
        }
        public static MasterPage Master
        {
            get; internal set;
        }

        public App()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage=new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                MainViewModel.GetInstance().Principal = new PrincipalViewModel();
                this.MainPage = new MasterPage();
            }
            
        }
        public static Action HideLoginView
        {
            get
            {
                return new Action(() => Current.MainPage = new NavigationPage(new LoginPage()));
            }
        }

        public static async Task NavigateToProfile(TokenResponse token)
        {
            if (token == null)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                return;
            }

            Settings.IsRemembered = true;
            Settings.Token = token.Token;
            
            var apiService = new ApiService();
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlUsersController"].ToString();
            //var response = await apiService.GetUser(url, prefix, $"{controller}/GetUser", token.UserName, token.TokenType, token.AccessToken);
            //if (response.IsSuccess)
            //{
            //    var userASP = (UserASP)response.Result;
            //    MainViewModel.GetInstance().UserASP = userASP;
            //    Settings.UserASP = JsonConvert.SerializeObject(userASP);
            //}

            MainViewModel.GetInstance().Principal = new PrincipalViewModel();
            Application.Current.MainPage = new MasterPage();
        }
        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
