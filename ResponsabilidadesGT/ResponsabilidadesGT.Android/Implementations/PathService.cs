[assembly: Xamarin.Forms.Dependency(typeof(ResponsabilidadesGT.Droid.Implementations.PathService))]

namespace ResponsabilidadesGT.Droid.Implementations
{
    using Interfaces;
    using System;
    using System.IO;

    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "Responsabilidades.db3");
        }
    }
}
