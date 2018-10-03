using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResponsabilidadesGT.Models
{
    public class Usuario
    {
        [PrimaryKey]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        [OneToMany(CascadeOperations =CascadeOperation.All)]
        public List<Actividad> Actividades { get; set; }
        public override int GetHashCode()
        {
            return IdUsuario;
        }
    }
}
