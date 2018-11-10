using GalaSoft.MvvmLight.Command;
using ResponsabilidadesGT.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ResponsabilidadesGT.ViewModels
{
    public class MyProfileViewModel :BaseViewModel
    {

        #region Commands
        public ICommand UpdateUserCommand
        {
            get
            {
                return new RelayCommand(UpdateUser);
            }
        }
        public ICommand UpdatePassCommand
        {
            get
            {
                return new RelayCommand(UpdatePass);
            }
        }

       
        public ICommand ChangePasswordCommand
        {
            get
            {
                return new RelayCommand(ChangePass);
            }
        }
       
        #endregion

        private void UpdateUser()
        {
            //throw new NotImplementedException();
        }
        private void UpdatePass()
        {
            //App.Navigator.PushAsync(new ChangePassPage());
        }

        private void ChangePass()
        {
            
            App.Navigator.PushAsync(new ChangePassPage());
        }

    }
}
