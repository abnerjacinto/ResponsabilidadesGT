namespace ResponsabilidadesGT
{
    using ResponsabilidadesGT.Helpers;
    using ResponsabilidadesGT.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;


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
                this.MainPage = new MasterPage();
            }
            
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
