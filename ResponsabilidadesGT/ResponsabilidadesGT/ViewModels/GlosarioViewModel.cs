
namespace ResponsabilidadesGT.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using ResponsabilidadesGT.Helpers;
    using ResponsabilidadesGT.Views;
    using Services;
    using System;
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
        private DataService dataservice;
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
            this.dataservice = new DataService();
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
                "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var Fix = Application.Current.Resources["UrlFix"].ToString();
            var Res = Application.Current.Resources["UrlRes"].ToString();
            var response = await this.apiservice.GetList<Glosario>(url,
                    Fix,
                   $"{Res}/getglosario/2"/*,
                   "Bearer",
                   Settings.Token*/);
            if (!response.IsSuccess)
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            MainViewModel.GetInstance().GlosarioList = (List<Glosario>)response.Result;
            this.Glosarios = new ObservableCollection<GlosarioItemViewModel>(
            this.ToItemGlosarioViewModel().Where(l => l.IdObligacion.Equals(this.Obligacion.IdObligacion)));
          
        }
        private IEnumerable<GlosarioItemViewModel> ToItemGlosarioViewModel()
        {
            return MainViewModel.GetInstance().GlosarioList.Select(g => new GlosarioItemViewModel
            {

                IdGlosario = g.IdGlosario,
                IdObligacion = g.IdObligacion,
                NombreObligacion=g.NombreObligacion,
                Descripcion = g.Descripcion,
                FechaLimite = g.FechaLimite,
                EstadoObligacion=g.EstadoObligacion,
                Ciclo=g.Ciclo,
            });
        }
        #endregion
        #region Command
        public ICommand AddObligacionCommand
        {
            get
            {
                return new RelayCommand(SaveObligacion);
            }
        }
        #endregion
        #region Methods

        private  async void SaveObligacion()
        {
            var result = await Application.Current.MainPage.DisplayAlert(
                "Guardar",
                "Desea guardar los datos a sus Obligaciones", 
                "Aceptar", 
                "Cancelar"); 
            if (result == true)
            {
                var Glosario = MainViewModel.GetInstance().GlosarioList.Where(a => a.IdObligacion.Equals(this.Obligacion.IdObligacion));
                
                var Obli = new Obligacion();
                Obli.IdObligacion = this.Obligacion.IdObligacion;
                Obli.NombreObligacion = this.Obligacion.NombreObligacion;
                Obli.EstadoObligacion = this.Obligacion.EstadoObligacion;
                Obli.UsuarioAdicionoObligacion = this.Obligacion.UsuarioAdicionoObligacion;
                Obli.FechaAdicionoObligacion = this.Obligacion.FechaAdicionoObligacion;
                Obli.UsuarioModificoObligacion = this.Obligacion.UsuarioModificoObligacion;
                Obli.FechaModificoObligacion = this.Obligacion.FechaModificoObligacion;
                try
                {
                    await dataservice.Insert(Glosario.FirstOrDefault());
                    await dataservice.Insert(Obli);
                    MainViewModel.GetInstance().Principal = new PrincipalViewModel();
                    Application.Current.MainPage = new MasterPage();
                    await Application.Current.MainPage.DisplayAlert(
                    "Éxito",
                    "¡La información se cargo con éxito!",
                    "Aceptar");
                    await dataservice.dbClose();
                    return;
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    e.Message,
                    "ok");
                    return;
                }
            }
            else 
            {
                return;
            }
        }
        #endregion

    }
}
