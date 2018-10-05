using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;


namespace ResponsabilidadesGT.Models
{
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;
    using Models;
    public class Actividad
    {
        [PrimaryKey]
        public int IdActividad { get; set; }
        public string FechaAviso { get; set; }
        public string Prorroga { get; set; }
        public string EstadoActvidad { get; set; }
        public string UsuarioAdiciono { get; set; }
        public string FechaAdiciono { get; set; }
        public string UsuarioModifico { get; set; }
        public string FechaModificacion { get; set; }
        [ForeignKey(typeof(Usuario))]
        public int? IdUsuario { get; set; }
        [ForeignKey(typeof(Obligacion))]
        public int? IdObligacion { get; set; }
        public override int GetHashCode()
        {
            return IdActividad;
        }

    }
}
