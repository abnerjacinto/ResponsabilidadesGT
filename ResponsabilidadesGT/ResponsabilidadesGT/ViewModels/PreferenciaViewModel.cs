using GalaSoft.MvvmLight.Command;
using ResponsabilidadesGT.Models;
using ResponsabilidadesGT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResponsabilidadesGT.ViewModels
{
    public class PreferenciaViewModel : BaseViewModel
    {
        #region Service
        //Atributo de servio de SQLite
        private DataService dataService;
        #endregion
        #region atributes
        //Atributo de binding de datapicker  
        private DateTime fechaSelect;
        //Atributo de binding de timepicker
        private TimeSpan timeSelect;
        //Atributo de binding del campo prorroga
        private string prorroga;
        //Atributo de binding estado de la actividad
        private bool isRemember;
        //atributo binding con boton
        private bool isEnabled;
        private bool isRunning;
        //Objeto del modelo Obligacion para asignar datos
        private Obligacion Obligacion;

        #endregion
        #region Properties
        //Propiedades
        
        public List<Obligacion> Obligaciones;
        public DateTime FechaSelect
        {
            get { return fechaSelect; }
            set { SetValue(ref fechaSelect, value); }
        }
        public TimeSpan TimeSelect
        {
            get { return timeSelect; }
            set { SetValue(ref timeSelect, value); }
        }
        public string Prorroga
        {
            get { return prorroga; }
            set { SetValue(ref prorroga, value); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemember { get; set; }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion
        #region Constructor
        //Constructor y la inicializacion de propiedades
        public PreferenciaViewModel(Obligacion obligacion)
        {
            this.dataService = new DataService();
            this.IsRemember = true;
            this.Obligacion = obligacion;
            this.fechaSelect = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Local);
            this.timeSelect = DateTimeOffset.Now.TimeOfDay;
            this.IsEnabled = true;
        }


        #endregion
        #region Methods
        private async void SaveActividad()
        {
            this.IsEnabled = false;
            this.IsRunning = true;
            //realiza consulta a la DB, obtiene todas las obligaciones
            this.Obligaciones = await dataService.GetAllObligacion();
            //Se filtra la obligacion, de acuerdo a la obligacion seleccionada
            var obligacion = this.Obligaciones.Where(o => o.IdObligacion.Equals(this.Obligacion.IdObligacion));
            //se instancia un nuevo objeto tipo Obligacion
            Obligacion obli = new Obligacion();
            //se asigna valores al objeto Obligacion en base a IEnumerable
            foreach (Obligacion o in obligacion)
            {
                obli.ID = o.ID;
                obli.IdObligacion = o.IdObligacion;
                obli.NombreObligacion = o.NombreObligacion;
                obli.EstadoObligacion = o.EstadoObligacion;
                obli.UsuarioAdicionoObligacion = o.UsuarioAdicionoObligacion;
                obli.FechaAdicionoObligacion = o.FechaAdicionoObligacion;
                obli.UsuarioModificoObligacion = o.UsuarioModificoObligacion;
                obli.FechaModificoObligacion = o.FechaModificoObligacion;
            }
            //Se instancia nueva fecha, que proviene de la View con los valores ingresados
            DateTime fechaRecordatorio = new DateTime(Convert.ToInt32(FechaSelect.ToString("yyyy")),
                                                        Convert.ToInt32(FechaSelect.ToString("MM")), 
                                                        Convert.ToInt32(FechaSelect.ToString("dd")), 
                                                        Convert.ToInt32(TimeSelect.ToString("hh")), 
                                                        Convert.ToInt32(TimeSelect.ToString("mm")), 
                                                        Convert.ToInt32(TimeSelect.ToString("ss")), 
                                                        0);
            //Se instancia notificacion
            NotificationService Noty = new NotificationService();
            //Metodo de mostrar notificacion, de la instancia de notificacion, parametros, Titulo,Mensaje,ID,Fecha,Sonido,Vibracion
            Noty.Show(obli.NombreObligacion,
                                             $"Se le recuerda la obligacion {obli.NombreObligacion} que esta proximo a vencer",
                                             0, fechaRecordatorio,
                                             true,
                                             true);
            this.IsEnabled = true;
            this.IsRunning = false;
            await Application.Current.MainPage.DisplayAlert(
                    "Exitoso",
                    "Preferecia guardado exitosamente!",
                    "Aceptar");
            

            return;
        }
        #endregion
        #region ICommand
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(SaveActividad);
            }
        }

        #endregion

    }
}
