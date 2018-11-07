namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    using SQLite;
    using SQLiteNetExtensions.Attributes;

    public class Glosario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "id_glosario")]
        public int IdGlosario { get; set; }
        [JsonProperty(PropertyName = "id_obligacion")]
        public int IdObligacion { get; set; }
        [JsonProperty(PropertyName = "nombre_obligacion")]
        public string NombreObligacion { get; set; }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty(PropertyName = "fecha_limite")]
        public string FechaLimite { get; set; }
<<<<<<< HEAD
        [JsonProperty(PropertyName = "id_punto_de_atencion")]
        public int IdPuntodeAtencion { get; set; }
=======
>>>>>>> 9ef731b6110a1b5190a12cba0138a6171dcb3785
        [JsonProperty(PropertyName = "nombre_institucion")]
        public string NombreInstitucion { get; set; }
        [JsonProperty(PropertyName = "estado_obligacion")]
        public string EstadoObligacion { get; set; }
        [JsonProperty(PropertyName = "ciclo")]
        public string Ciclo { get; set; }
        

    }
}
