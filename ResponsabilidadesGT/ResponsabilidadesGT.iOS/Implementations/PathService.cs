﻿[assembly: Xamarin.Forms.Dependency(typeof(ResponsabilidadesGT.iOS.Implementations.PathService))]

namespace ResponsabilidadesGT.iOS.Implementations
{
    using Interfaces;
    using System;
    using System.IO;

    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, "Res.db3");
        }
    }
}