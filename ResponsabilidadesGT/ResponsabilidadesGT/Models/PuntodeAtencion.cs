namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    public class PuntodeAtencion
    {
        [JsonProperty(PropertyName = "id_punto_de_atencion")]
        public int IdPuntodeAtencion { get; set; }
        [JsonProperty(PropertyName = "institucion")]
        public string Institucion { get; set; }
        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }
        [JsonProperty(PropertyName = "telefono")]
        public int Telefono { get; set; }
        [JsonProperty(PropertyName = "usuario_adiciono_punto")]
        public string UsuarioAdicionoPunto { get; set; }
        [JsonProperty(PropertyName = "fecha_adiciono_punto")]
        public string FechaAdicionoPunto { get; set; }
        [JsonProperty(PropertyName = "usuario_modifico_punto")]
        public object UsuarioModificoPunto { get; set; }
        [JsonProperty(PropertyName = "fecha_modifico_punto")]
        public object FechaModificoPunto { get; set; }
    }
}
