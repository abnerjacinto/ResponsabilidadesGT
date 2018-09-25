
namespace ResponsabilidadesGT.ViewModels
{
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Forms;

    public class GlosarioViewModel
    {
        #region Service
        private ApiService apiservice;
        #endregion
        #region Properties
        public Obligacion Obligacion { get; set; }
        public Glosario Glosario { get; set; }
        public ObservableCollection<GlosarioItemViewModel> Glosarios { get; set; }
         
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
        private async void LoadGlosario()
        {
               
                var connection = await this.apiservice.CheckConnection();
                if (!connection.IsSuccess)
                {
                        await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        connection.Message,
                        "ok");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    return;
                }
                var response = await this.apiservice.GetList<Glosario>("http://192.168.10.3",
                    "/ResponsabilidadesGT",
                    "/public/getglosario");
                if (!response.IsSuccess)
                {
                    
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        response.Message,
                        "ok");
                }
            
                MainViewModel.GetInstance().GlosarioList = (List<Glosario>)response.Result;
                //this.ObligacionesList = (List<Obligacion>)response.Result;
                this.Glosarios  = new ObservableCollection<GlosarioItemViewModel>(
                    this.ToItemGlosarioViewModel());

            
        }
        private IEnumerable<GlosarioItemViewModel> ToItemGlosarioViewModel()
        {
            return MainViewModel.GetInstance().GlosarioList.Select(l => new ObligacionItemViewModel
            {
                IdObligacion = l.IdObligacion,
                NombreObligacion = l.NombreObligacion,
                EstadoObligacion = l.EstadoObligacion,
                UsuarioAdicionoObligacion = l.UsuarioAdicionoObligacion,
                FechaAdicionoObligacion = l.FechaAdicionoObligacion,
                UsuarioModificoObligacion = l.UsuarioModificoObligacion,
                FechaModificoObligacion = l.FechaModificoObligacion
            });
        }
        #endregion
    }
}
