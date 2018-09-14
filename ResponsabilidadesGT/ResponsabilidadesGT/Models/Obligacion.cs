namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    public class Obligacion
    {
        #region Properties
        [JsonProperty(PropertyName = "id_obligacion")]
        public int IdObligacion { get; set; }
        [JsonProperty(PropertyName = "nombre_obligacion")]
        public string NombreObligacion { get; set; }
        [JsonProperty(PropertyName = "estado_obligacion")]
        public string EstadoObligacion { get; set; }
        [JsonProperty(PropertyName = "usuario_adiciono_obligacion")]
        public string UsuarioAdicionoObligacion { get; set; }
        [JsonProperty(PropertyName = "fecha_adiciono_obligacion")]
        public string FechaAdicionoObligacion { get; set; }
        [JsonProperty(PropertyName = "usuario_modifico_obligacion")]
        public object UsuarioModificoObligacion { get; set; }
        [JsonProperty(PropertyName = "fecha_modifico_obligacion")]
        public object FechaModificoObligacion { get; set; }
        #endregion
    }
}
