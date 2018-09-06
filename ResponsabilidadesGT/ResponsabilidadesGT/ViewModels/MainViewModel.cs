using System;
using System.Collections.Generic;
using System.Text;

namespace ResponsabilidadesGT.ViewModels
{
    class MainViewModel
    {
        #region ViewModel
        public LoginViewModel Login { get; set; }
        #endregion
        #region Constructor
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion

    }
}
