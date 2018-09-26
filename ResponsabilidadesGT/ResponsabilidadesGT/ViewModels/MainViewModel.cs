

namespace ResponsabilidadesGT.ViewModels
{
    using System.Collections.Generic;
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

        public TokenResponse Token
        {
            get;
            set;
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

    }
}
