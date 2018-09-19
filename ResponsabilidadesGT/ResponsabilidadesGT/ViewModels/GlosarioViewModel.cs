
namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    using System.Collections.Generic;
    class GlosarioViewModel
    {
        #region Properties
        public Obligacion Obligacion { get; set; }
        #endregion


        #region Constructor
        public GlosarioViewModel(Obligacion obligacion)
        {
            this.Obligacion = obligacion;
        } 
        #endregion
    }
}
