namespace ResponsabilidadesGT.Models
{
    using Newtonsoft.Json;
    using SQLite;
    using SQLiteNetExtensions.Attributes;
    using System.Collections.Generic;

    public class PuntodeAtencion
    {
        [JsonProperty(PropertyName = "id_punto_de_atencion")]
        [PrimaryKey, Unique]
        public int IdPuntodeAtencion { get; set; }
        [JsonProperty(PropertyName = "id_glosario")]
        public int IdGlosario { get; set; }
        [JsonProperty(PropertyName = "nombre_institucion")]
        public string NombreInstitucion { get; set; }
        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }
        [JsonProperty(PropertyName = "telefono")]
        public string Telefono { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
