namespace ResponsabilidadesGT.Infraestructure
{
    using ResponsabilidadesGT.ViewModels;
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
