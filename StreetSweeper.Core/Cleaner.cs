using System.Security;

namespace StreetSweeper.Core
{
    public class Cleaner
    {
        public static List<string> GetPathAsList(EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
        {
            string? pathVar = Environment.GetEnvironmentVariable("Path", target);
            if (pathVar == null) return new();
            return pathVar.Split(';').ToList();
        }

        public static void RemoveDeleted(EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
        {
            var paths = GetPathAsList(target);
            var existing = paths.Where(x => Directory.Exists(x));
            SetPath(string.Join(';', existing), target);
        }

        public static List<string> GetNonExistant(EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
        {
            var paths = GetPathAsList(target);
            return paths.Where(x => !Directory.Exists(x)).ToList();
        }

        public static void RemoveDuplicates(EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
        {
            var paths = GetPathAsList(target);
            // Remove duplicates:
            var uniques = paths.Distinct().ToList();
            // Set variable
            SetPath(string.Join(';', uniques), target);
        }

        public static List<string> GetDuplicates(EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
        {
            var paths = GetPathAsList(target);
            var duplicates = paths.GroupBy(x => x)
                .Where(y => y.Count() > 1)
                .Select(z => z.Key)
                .ToList();
            return duplicates;
        }

        public static void RemoveDuplicatesAcrossTargets(EnvironmentVariableTarget target1, EnvironmentVariableTarget target2)
        {
            if (target2 >= target1)
            {
                throw new ArgumentException("Order is Machine > User > Process, param 1 must be larger than param 2!");
            }

            var target1Paths = GetPathAsList(target1);
            var target2Paths = GetPathAsList(target2);
            // Remove all paths that are already covered by target1
            var filtered = target2Paths.Where(x => !target1Paths.Contains(x));
            SetPath(string.Join(';', filtered), target2);
        }

        public static void FullClean(EnvironmentVariableTarget target)
        {
            RemoveDuplicates(target);
            if (target < EnvironmentVariableTarget.Machine)
            {
                RemoveDuplicatesAcrossTargets(EnvironmentVariableTarget.Machine, target);
            }
            if (target < EnvironmentVariableTarget.User)
            {
                RemoveDuplicatesAcrossTargets(EnvironmentVariableTarget.User, target);
            }
            RemoveDeleted(target);
        }

        public static void SetPath(string value, EnvironmentVariableTarget target)
        {
            try
            {
                Environment.SetEnvironmentVariable("Path", value, target);
            }
            catch (SecurityException)
            {
                throw new SecurityException("You need admin rights to modify the $Path variable for all users!");
            }
        }
    }
}
