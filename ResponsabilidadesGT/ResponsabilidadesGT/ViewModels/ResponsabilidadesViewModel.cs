namespace ResponsabilidadesGT.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
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
        private bool isRefreshing;
        private string filter;
        private List<Obligacion> ObligacionesList;
        #endregion
        #region Properties
        public ObservableCollection<Obligacion> Obligaciones
        {
            get { return obligaciones; }
            set { SetValue(ref obligaciones, value); }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        public string Filter
        {
            get { return filter; }
            set { SetValue(ref filter, value);
                this.Search();
            }
        }
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
            this.IsRefreshing = true;
            var connection = await this.apiservice.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "ok");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await this.apiservice.GetList<Obligacion>("http://192.168.1.9",
                "/ResponsabilidadesGT",
                "/public/getobligacion");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "ok");
            }
            this.ObligacionesList = (List<Obligacion>)response.Result;
            this.Obligaciones = new ObservableCollection<Obligacion>(this.ObligacionesList);
            this.IsRefreshing = false;
        }
        #endregion
        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadObligaciones);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private  void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Obligaciones = new ObservableCollection<Obligacion>(this.ObligacionesList);
            }
            else
            {
                this.Obligaciones = new ObservableCollection<Obligacion>(
                    this.ObligacionesList.Where(l =>l.NombreObligacion.ToLower().Contains(this.Filter)));
            }
        }
        #endregion
    }
}
