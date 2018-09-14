namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    public class Glosario
    {
        [JsonProperty(PropertyName = "id_glosario")]
        public int IdGlosario { get; set; }
        [JsonProperty(PropertyName = "id_obligacion")]
        public int IdObligacion { get; set; }
        [JsonProperty(PropertyName = "id_punto_de_atencion")]
        public int IdPuntodeAtencion { get; set; }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty(PropertyName = "fecha_limite")]
        public string FechaLimite { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "usuario_adiciono_glosario")]
        public string UsuarioAdicionoGlosario { get; set; }
        [JsonProperty(PropertyName = "fecha_adiciono_glosario")]
        public string FechaAdicionoGlosario { get; set; }
        [JsonProperty(PropertyName = "usuario_modifico_glosario")]
        public object UsuarioModificoGlosario { get; set; }
        [JsonProperty(PropertyName = "fecha_modifico_glosario")]
        public object fechaModificoGlosario { get; set; }
    }
}
