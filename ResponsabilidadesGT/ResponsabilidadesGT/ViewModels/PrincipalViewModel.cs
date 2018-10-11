namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

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
         
        public ObservableCollection<Glosario> ListObligacion;
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
            this.dataService = new DataService();
            this.LoadPrincipal();
        }


        #endregion
        #region Methods
        private async void LoadPrincipal()
        {
            
            this.IsRefreshing = true;

            //this.ListObligacion  await dataService.GetAllGlosario();

            //var myListCategoriesItemViewModel = this.MyCategories.Select(c => new CategoryItemViewModel
            //{
            //    CategoryId = c.CategoryId,
            //    Description = c.Description,
            //    ImagePath = c.ImagePath,
            //}).Where(c => c.Description.ToLower().Contains(this.Filter.ToLower())).ToList();

            //this.Categories = new ObservableCollection<CategoryItemViewModel>(
            //    myListCategoriesItemViewModel.OrderBy(c => c.Description));




        }
        private void Search()
        {
            throw new NotImplementedException();
        }
        private IEnumerable<GlosarioItemViewModel> ToItemGlosarioViewModel()
        {
            return MainViewModel.GetInstance().GlosarioList.Select(g => new GlosarioItemViewModel
            {
                IdGlosario = g.IdGlosario,
                IdObligacion = g.IdObligacion,
                IdPuntodeAtencion = g.IdPuntodeAtencion,
                Descripcion = g.Descripcion,
                FechaLimite = g.FechaLimite,
                Link = g.Link,
                UsuarioAdicionoGlosario = g.UsuarioAdicionoGlosario,
                FechaAdicionoGlosario = g.FechaAdicionoGlosario,
                UsuarioModificoGlosario = g.UsuarioModificoGlosario,
                fechaModificoGlosario = g.fechaModificoGlosario,
            });
        }
        #endregion
    }
}
