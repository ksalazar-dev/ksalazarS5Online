using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksalazarS5Online.Utils
{
    public class FileAccessHelper
    {
        public static string GetFolderPath(string filename)
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, filename);
            return path;
        }
    }
}
