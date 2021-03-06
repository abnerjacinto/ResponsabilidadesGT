﻿namespace ResponsabilidadesGT.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Models;
    using ResponsabilidadesGT.Helpers;
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
            
            var response = await this.apiservice.GetList<PuntodeAtencion>(
                    url,
                   "/getpuntoatencion/2",
                   "Bearer",
                   Settings.Token);
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
                Link=p.Link,
                
            });
        }
        #endregion
        #region ICommand
       
        #endregion
    }
}
