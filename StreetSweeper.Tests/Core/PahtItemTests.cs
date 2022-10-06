using FluentAssertions;
using StreetSweeper.Core;

namespace StreetSweeper.Tests.Core
{
    [Collection("PathTests")]
    public class PahtItemTests : BaseTest
    {
        [Fact]
        public void PathExistsTest()
        {
            PathItem p = new("C:\\Windows", target);
            p.PathExists().Should().BeTrue();
            p = new("C:\\Nope", EnvironmentVariableTarget.User);
            p.PathExists().Should().BeFalse();
        }

        [Fact]
        public void IsDuplicateTest()
        {
            SetPath("C:\\Windows;C:\\Windows\\System32");
            PathItem p = new("C:\\Windows", target);
            p.IsDuplicate().Should().BeFalse();
            SetPath(GetPath() + ";C:\\Windows");
            p.IsDuplicate().Should().BeTrue();
        }
    }
}
