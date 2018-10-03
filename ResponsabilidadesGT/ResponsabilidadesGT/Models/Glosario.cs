namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;
    using System.Collections.Generic;

    public class Glosario
    {
        [JsonProperty(PropertyName = "id_glosario")]
        [PrimaryKey]
        public int IdGlosario { get; set; }
                
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
        
        [JsonProperty(PropertyName = "id_obligacion")]
        [ForeignKey(typeof(Obligacion))]
        public int IdObligacion { get; set; }

        [JsonProperty(PropertyName = "id_punto_de_atencion")]
        [ForeignKey(typeof(PuntodeAtencion))]
        public int IdPuntodeAtencion { get; set; }

        public override int GetHashCode()
        {
            return IdGlosario;
        }

    }
}
