

namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    class PuntoAtencionViewModel
    {
        #region Properties
        public Glosario Glosario { get; set; }
        #endregion
        #region Constructor
        public PuntoAtencionViewModel(Glosario glosario)
        {
            this.Glosario = glosario;
            
        } 
        #endregion
    }
}
