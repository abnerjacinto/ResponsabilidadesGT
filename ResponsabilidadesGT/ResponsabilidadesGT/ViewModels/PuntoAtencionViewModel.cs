namespace ResponsabilidadesGT.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models;
    using Services;
    using Xamarin.Forms;

    class PuntoAtencionViewModel:BaseViewModel
    {
        #region Attributes
        private ObservableCollection<PuntoAtencionItemViewModel> puntodeAtencion;
        #endregion
        #region Service
        private ApiService apiservice;

        #endregion
        #region Properties
        public List<PuntodeAtencion> MyPunto;
        public Glosario Glosario { get; set; }
        public ObservableCollection<PuntoAtencionItemViewModel> PuntodeAtencion
        {
            get { return puntodeAtencion; }
            set { SetValue(ref puntodeAtencion, value); }
        }
        #endregion
        #region Constructor
        public PuntoAtencionViewModel(Glosario glosario)
        {
            this.apiservice = new ApiService();
            this.Glosario = glosario;
            this.LoadPunto();
        }
        #endregion
        #region methods
        private async void LoadPunto()
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
            var response = await this.apiservice.GetList<PuntodeAtencion>(url,
                    Fix,
                   $"{Res}/getpuntoatencion/2");
            if (!response.IsSuccess)
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            MainViewModel.GetInstance().PuntoList = (List<PuntodeAtencion>)response.Result; 
            this.PuntodeAtencion = new ObservableCollection<PuntoAtencionItemViewModel>(
            this.ToItemGlosarioViewModel().Where(p => p.IdGlosario.Equals(this.Glosario.IdGlosario)));

        }

        private IEnumerable<PuntoAtencionItemViewModel> ToItemGlosarioViewModel()
        {
            return MainViewModel.GetInstance().PuntoList.Select(p => new PuntoAtencionItemViewModel
            {
                IdPuntodeAtencion = p.IdPuntodeAtencion,
                IdGlosario=p.IdGlosario,
                NombreInstitucion = p.NombreInstitucion,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                
            });
        }
        #endregion
    }
}
