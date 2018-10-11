namespace ResponsabilidadesGT.Models
{
    using SQLite;
    using SQLiteNetExtensions.Attributes;
    using System.Collections.Generic;
    public class Usuario
    {
        [PrimaryKey]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        //[OneToMany(CascadeOperations =CascadeOperation.All)]
        //public List<Actividad> Actividades { get; set; }
        
    }
}
