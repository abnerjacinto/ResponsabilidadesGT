namespace ResponsabilidadesGT.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ResponsabilidadesGT.Models;
    using ResponsabilidadesGT.Services;
    using Xamarin.Forms;

    public class ResponsabilidadesViewModel:BaseViewModel
    {
        #region Service

        #endregion
        private ApiService apiservice;
        #region attributes
        private ObservableCollection<Obligacion> obligaciones;
        #endregion
        #region Properties
        public ObservableCollection<Obligacion> Obligaciones { get; set; }
        #endregion
        #region Constructor
        public ResponsabilidadesViewModel()
        {
            this.apiservice = new ApiService();
            this.LoadObligaciones();
        }
        #endregion
        #region Methods
        private async void LoadObligaciones()
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
            var response = await this.apiservice.GetList<Obligacion>("http://192.168.10.3",
                "/ResponsabilidadesGT",
                "/public/getobligacion");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "ok");
            }
            var list = (List<Obligacion>)response.Result;
            this.Obligaciones = new ObservableCollection<Obligacion>(list);
        }
        #endregion
    }
}
