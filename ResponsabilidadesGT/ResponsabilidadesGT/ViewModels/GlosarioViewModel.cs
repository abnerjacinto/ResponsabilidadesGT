
namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    public class GlosarioViewModel
    {
        #region Service
        private ApiService apiservice;
        #endregion
        #region Properties
        public Obligacion Obligacion { get; set; }
        #endregion
        

        #region Constructor
        public GlosarioViewModel(Obligacion obligacion)
        {
            this.Obligacion = obligacion;
            this.apiservice = new ApiService();
            this.LoadGlosario();
        }
        #endregion
        #region methods
        private void LoadGlosario()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
