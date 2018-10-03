

namespace ResponsabilidadesGT.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    class MainViewModel
    {
        #region Properties
       
        public List<Obligacion> ObligacionesList
        {
            get;
            set;
        }
        public List<Glosario> GlosarioList
        {
            get;
            set;
        }

        public string Token { get; set; }
        public string TokenType { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus
        {
            get; set;
        }
        #endregion
        #region ViewModel
        public LoginViewModel Login { get; set; }
        public ResponsabilidadesViewModel Responsabilidades { get; set; }
        public RegisterViewModel Register { get; set; }
        public GlosarioViewModel Glosario { get; set; }
        public PuntoAtencionViewModel PuntoAtencion { get; set; }
        
        #endregion
        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
          
        }

        
        #endregion
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
        #region methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_invitation",
                Title = "Responsabilidades en Linea",
                PageName = "ResponsabilidadesPage",
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                Title = "Mi Perfil",
                PageName = "PerfilPage",
            });         
          
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                Title = "Salir",
                PageName = "LoginPage",
            });
        }
        #endregion
    }
}
