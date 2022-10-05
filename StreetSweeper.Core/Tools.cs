using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Core
{
    public class Tools
    {
        public static List<string> GetPaths(EnvironmentVariableTarget target)
        {
            string path = Environment.GetEnvironmentVariable("Path", target) ?? string.Empty;
            return path.Split(';').ToList();
        }

        public static bool IsAdmin()
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

    }
}
