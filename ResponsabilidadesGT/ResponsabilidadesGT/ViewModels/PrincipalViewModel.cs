namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using ResponsabilidadesGT.Views;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class PrincipalViewModel:BaseViewModel
    {
        #region Service
        private DataService dataService;
        #endregion

        #region attributes
        private ObservableCollection<ObligacionItemViewModel> principales;
        private bool isRefreshing;
        private string filter;

        #endregion
        #region Properties
        public List<Obligacion> Obligacions;
        public ObservableCollection<ObligacionItemViewModel> Principales
        {
            get {  return principales; }
            set { SetValue(ref principales, value); }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        public string Filter
        {
            get { return filter; }
            set
            {
                SetValue(ref filter, value);
                this.Search();
            }
        }

        
        #endregion
        #region Constructor
        public PrincipalViewModel()
        {
            instance = this;
            this.dataService = new DataService();
            this.LoadPrincipal();
        }


        #endregion
        #region Singleton
        private static PrincipalViewModel instance;

        public static PrincipalViewModel GetInstance()
        {
            return instance;
        }
        #endregion
        #region Methods
        private async void LoadPrincipal()
        {
            try
            {
                this.IsRefreshing = true;
                this.Obligacions = await dataService.GetAllObligacion();
                this.Principales = new ObservableCollection<ObligacionItemViewModel>(this.ToItemObligacionViewModel());
                this.IsRefreshing = false;
            }
            catch (Exception)
            {

                throw;
            }
           



        }
        public void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Principales = new ObservableCollection<ObligacionItemViewModel>(this.ToItemObligacionViewModel());
            }
            else
            {
                this.Principales = new ObservableCollection<ObligacionItemViewModel>(
                    this.ToItemObligacionViewModel().Where(l => l.NombreObligacion.ToLower().Contains(this.Filter)));
            }
        }
        private IEnumerable<ObligacionItemViewModel> ToItemObligacionViewModel()
        {
            
            return this.Obligacions.Select(o => new ObligacionItemViewModel
            {
                IdObligacion = o.IdObligacion,
                NombreObligacion = o.NombreObligacion,
                EstadoObligacion = o.EstadoObligacion,
                UsuarioAdicionoObligacion = o.UsuarioAdicionoObligacion,
                FechaAdicionoObligacion = o.FechaAdicionoObligacion,
                UsuarioModificoObligacion = o.UsuarioModificoObligacion,
                FechaModificoObligacion = o.FechaModificoObligacion,
            });
           
        }
        #endregion
        #region ICommand
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPrincipal);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
       
        #endregion
    }
}
