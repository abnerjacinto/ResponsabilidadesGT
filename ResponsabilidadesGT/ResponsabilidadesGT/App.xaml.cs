﻿namespace ResponsabilidadesGT
{
    using ResponsabilidadesGT.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    public partial class App : Application
    {
        public static NavigationPage Navigator
        {
            get; internal set;
        }
        public static object Master { get; internal set; }

        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());
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
