namespace StreetSweeper.Tests.Core
{
    public abstract class BaseTest
    {
        internal readonly EnvironmentVariableTarget target = EnvironmentVariableTarget.Process;

        internal void SetPath(string value)
        {
            Environment.SetEnvironmentVariable("Path", value, target);
        }

        internal string? GetPath()
        {
            return Environment.GetEnvironmentVariable("Path", target);
        }
    }
}
