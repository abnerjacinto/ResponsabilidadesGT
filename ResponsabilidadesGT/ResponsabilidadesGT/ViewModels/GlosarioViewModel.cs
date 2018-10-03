
namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class GlosarioViewModel : BaseViewModel
    {
        private ObservableCollection<GlosarioItemViewModel> glosarios;
        #region Service
        private ApiService apiservice;
        #endregion
        #region Properties
        public Obligacion Obligacion { get; set; }

        public ObservableCollection<GlosarioItemViewModel> Glosarios
        {
            get { return glosarios; }
            set { SetValue(ref glosarios, value); }
        }

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
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var Fix = Application.Current.Resources["UrlFix"].ToString();
            var Res = Application.Current.Resources["UrlRes"].ToString();
            var response = await this.apiservice.GetList<Glosario>(url,
                    Fix,
                    Res);
            if (!response.IsSuccess)
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "ok");
            }

            MainViewModel.GetInstance().GlosarioList = (List<Glosario>)response.Result;
            //this.ObligacionesList = (List<Obligacion>)response.Result;
            this.Glosarios = new ObservableCollection<GlosarioItemViewModel>(
                this.ToItemGlosarioViewModel().Where(l => l.IdObligacion.Equals(this.Obligacion.IdObligacion)));




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
                UsuarioModificoGlosario = g.UsuarioModificoGlosario,
                fechaModificoGlosario = g.fechaModificoGlosario,
                UsuarioAdicionoGlosario = g.UsuarioAdicionoGlosario,
                FechaAdicionoGlosario = g.FechaAdicionoGlosario

            });
        }
        #endregion
        #region Command
        public ICommand AddObligacionCommand
        {
            get
            {
                return new RelayCommand();
            }
        }
        #endregion

    }
}
