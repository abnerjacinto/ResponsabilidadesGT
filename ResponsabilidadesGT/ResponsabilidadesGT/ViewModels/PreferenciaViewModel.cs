using ResponsabilidadesGT.Models;
using ResponsabilidadesGT.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ResponsabilidadesGT.ViewModels
{
    public class PreferenciaViewModel : BaseViewModel
    {
        #region Service
        private DataService dataService;
        #endregion
        #region atributes
        private DateTime fechaSelect;
        private DateTime timeSelect;
        private string prorroga;
        private bool isRemember;
        private Obligacion Obligacion;
        
        #endregion
        #region Properties
       

        public DateTime FechaSelect
        {
            get { return fechaSelect; }
            set { SetValue(ref fechaSelect, value); }
        }
        public DateTime TimeSelect
        {
            get { return timeSelect; }
            set { SetValue(ref timeSelect, value); }
        }
        public string Prorroga
        {
            get { return prorroga; }
            set { SetValue(ref prorroga, value); }
        }
        public bool IsRemember
        {
            get { return isRemember; }
            set { SetValue(ref isRemember, value); }
        }
        #endregion
        #region Constructor
        public PreferenciaViewModel(Obligacion obligacion)
        {
            this.dataService = new DataService();
            this.IsRemember = true;
            this.Obligacion = obligacion;
            this.fechaSelect = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Local);
            TimePicker timePicker = new TimePicker();
            timePicker.Time =DateTime.Now.TimeOfDay;
            this.timeSelect.AddHours(timePicker.Time.Hours);
            this.timeSelect.AddMinutes(timePicker.Time.Minutes);
        }


        #endregion
        #region Methods

        #endregion
        #region ICommand

        #endregion

    }
}
