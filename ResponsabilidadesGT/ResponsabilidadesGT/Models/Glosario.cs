namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    using SQLite;
    using SQLiteNetExtensions.Attributes;

    public class Glosario
    {
        [JsonProperty(PropertyName = "id_glosario")]
        [PrimaryKey, Unique]
        public int IdGlosario { get; set; }
        [JsonProperty(PropertyName = "nombre_obligacion")]
        public string NombreObligacion { get; set; }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty(PropertyName = "fecha_limite")]
        public string FechaLimite { get; set; }
        [JsonProperty(PropertyName = "estado_obligacion")]
        public string EstadoObligacion { get; set; }
        [JsonProperty(PropertyName = "ciclo")]
        public string Ciclo { get; set; }
        [JsonProperty(PropertyName = "id_obligacion")]
        public int IdObligacion { get; set; }

    }
}
