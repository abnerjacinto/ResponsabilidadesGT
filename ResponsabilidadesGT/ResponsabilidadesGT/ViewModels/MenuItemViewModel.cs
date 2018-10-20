using GalaSoft.MvvmLight.Command;
using ResponsabilidadesGT.Helpers;
using ResponsabilidadesGT.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResponsabilidadesGT.ViewModels
{
   public class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;

            if (this.PageName == "LoginPage")
            {
                Settings.IsRemembered = false;
                Settings.Token = String.Empty;
                //Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                //mainViewModel.User = null;
                Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
            else if (this.PageName == "ResponsabilidadesPage")
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Responsabilidades = new ResponsabilidadesViewModel();
                App.Navigator.PushAsync(new ResponsabilidadesPage());
                
                //MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
                //App.Navigator.PushAsync(new MyProfilePage());
            }
        }
        #endregion
    }
}
