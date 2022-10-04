using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Core
{
    internal class Tools
    {
        public static List<string> GetPaths(EnvironmentVariableTarget target)
        {
            string path = Environment.GetEnvironmentVariable("Path", target) ?? string.Empty;
            return path.Split(';').ToList();
        }
    }
}
