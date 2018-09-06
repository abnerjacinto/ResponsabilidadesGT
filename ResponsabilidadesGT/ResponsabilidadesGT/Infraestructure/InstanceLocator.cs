using ResponsabilidadesGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResponsabilidadesGT.Infraestructure
{
    class InstanceLocator
    {
        #region propierties
        public MainViewModel Main { get; set; }

        #endregion
        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
