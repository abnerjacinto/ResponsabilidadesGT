namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    using SQLite;
    using SQLiteNetExtensions.Attributes;
    using System.Collections.Generic;

    public class Obligacion
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "id_obligacion")]
        public int IdObligacion { get; set; }
        [JsonProperty(PropertyName = "nombre_obligacion")]
        public string NombreObligacion { get; set; }
        [JsonProperty(PropertyName = "estado_obligacion")]
        public string EstadoObligacion { get; set; }
       
        
        #endregion
    }
}
