namespace ResponsabilidadesGT.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Interfaces;
    using SQLite;
    using Xamarin.Forms;

    public class DataService
    {
        private SQLiteAsyncConnection connection;

        public DataService()
        {
            this.OpenOrCreateDB();
        }

        private async Task OpenOrCreateDB()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            this.connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<Glosario>().ConfigureAwait(false);
            await connection.CreateTableAsync<Actividad>().ConfigureAwait(false);
            await connection.CreateTableAsync<Obligacion>().ConfigureAwait(false);
            await connection.CreateTableAsync<PuntodeAtencion>().ConfigureAwait(false);
            await connection.CreateTableAsync<Usuario>().ConfigureAwait(false);
        }

        public async Task Insert<T>(T model)
        {
            await this.connection.InsertAsync(model);
        }

        public async Task Insert<T>(List<T> models)
        {
            await this.connection.InsertAllAsync(models);
        }

        public async Task Update<T>(T model)
        {
            await this.connection.UpdateAsync(model);
        }

        public async Task Update<T>(List<T> models)
        {
            await this.connection.UpdateAllAsync(models);
        }

        public async Task Delete<T>(T model)
        {
            await this.connection.DeleteAsync(model);
        }

        public async Task<List<Glosario>> GetAllGlosario()
        {
            var query = await this.connection.QueryAsync<Glosario>("select * from [Glosario]");
            var array = query.ToArray();
            var list = array.Select(g => new Glosario
            {
            
                IdGlosario=g.IdGlosario,
                Descripcion=g.Descripcion,
                FechaLimite=g.FechaLimite,
                Link=g.Link,
                UsuarioAdicionoGlosario=g.UsuarioAdicionoGlosario,
                FechaAdicionoGlosario=g.FechaAdicionoGlosario,
                UsuarioModificoGlosario=g.UsuarioModificoGlosario,
                fechaModificoGlosario=g.fechaModificoGlosario,
                IdObligacion=g.IdGlosario,
                IdPuntodeAtencion=g.IdPuntodeAtencion,
            }).ToList();
            return list;
        }
        public async Task<List<Obligacion>> GetAllObligacion()
        {
            var query = await this.connection.QueryAsync<Obligacion>("select * from [Obligacion]");
            var array = query.ToArray();
            var list = array.Select(o => new Obligacion
            {
                IdObligacion=o.IdObligacion,
                NombreObligacion=o.NombreObligacion,
                EstadoObligacion=o.EstadoObligacion,
                UsuarioAdicionoObligacion=o.UsuarioAdicionoObligacion,
                FechaAdicionoObligacion=o.FechaAdicionoObligacion,
                UsuarioModificoObligacion=o.UsuarioModificoObligacion,
                FechaModificoObligacion=o.FechaModificoObligacion,
            }).ToList();
            return list;
        }

        public async Task<List<Actividad>> GetAllActividad()
        {
            var query = await this.connection.QueryAsync<Actividad>("select * from [Actividad]");
            var array = query.ToArray();
            var list = array.Select(a => new Actividad
            {
                IdActividad=a.IdActividad,
                FechaAviso=a.FechaAviso,
                Prorroga=a.Prorroga,
                EstadoActvidad=a.EstadoActvidad,
                UsuarioAdiciono=a.UsuarioAdiciono,
                FechaAdiciono=a.FechaAdiciono,
                UsuarioModifico=a.UsuarioModifico,
                FechaModificacion=a.FechaModificacion,
                IdUsuario=a.IdUsuario,
                IdObligacion=a.IdObligacion,
            }).ToList();
            return list;
        }
        public async Task<List<PuntodeAtencion>> GetAllPuntoAtencion()
        {
            var query = await this.connection.QueryAsync<PuntodeAtencion>("select * from [PuntodeAtencion]");
            var array = query.ToArray();
            var list = array.Select(p => new PuntodeAtencion
            {
                IdPuntodeAtencion=p.IdPuntodeAtencion,
                Institucion=p.Institucion,
                Direccion=p.Direccion,
                Telefono=p.Telefono,
                UsuarioAdicionoPunto=p.UsuarioAdicionoPunto,
                FechaAdicionoPunto=p.FechaAdicionoPunto,
                UsuarioModificoPunto=p.UsuarioModificoPunto,
                FechaModificoPunto=p.FechaModificoPunto,
            }).ToList();
            return list;
        }

        public async Task DeleteAllGlosario()
        {
            var query = await this.connection.QueryAsync<Glosario>("delete from [Glosario]");
        }
        public async Task DeleteAllObligacion()
        {
            var query = await this.connection.QueryAsync<Glosario>("delete from [Obligacion]");
        }
        public async Task DeleteAllActividad()
        {
            var query = await this.connection.QueryAsync<Glosario>("delete from [Actividad]");
        }
        public async Task DeleteAllPuntoAtencion()
        {
            var query = await this.connection.QueryAsync<Glosario>("delete from [PuntodeAtencion]");
        }
        public async Task DeleteAllUsuario()
        {
            var query = await this.connection.QueryAsync<Glosario>("delete from [Usuario]");
        }
    }
}

