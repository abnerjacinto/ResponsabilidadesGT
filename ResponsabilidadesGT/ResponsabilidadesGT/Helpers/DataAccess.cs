namespace ResponsabilidadesGT.Helpers
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
            await connection.CreateTableAsync<Actividad>().ConfigureAwait(false);
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

        public async Task<List<Actividad>> GetAllProducts()
        {
            var query = await this.connection.QueryAsync<Actividad>("select * from [Product]");
            var array = query.ToArray();
            var list = array.Select(a => new Actividad
            {
               IdActividad= a.IdActividad,
                FechaAviso = a.FechaAviso,
                Prorroga = a.Prorroga,
                EstadoActvidad = a.EstadoActvidad,
                UsuarioAdiciono = a.UsuarioAdiciono,
                FechaAdiciono = a.FechaAdiciono,
                UsuarioModifico =a.UsuarioModifico,
                FechaModificacion=a.FechaModificacion,
                IdObligacion=a.IdObligacion,
                IdUsuario=a.IdUsuario,
            }).ToList();
            return list;
        }

        public async Task DeleteAllProducts()
        {
            var query = await this.connection.QueryAsync<Actividad>("delete from [Actividad]");
        }
    }

}