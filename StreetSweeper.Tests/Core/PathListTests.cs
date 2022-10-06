using FluentAssertions;
using StreetSweeper.Core;

namespace StreetSweeper.Tests.Core
{
    public class PathListTests : BaseTest
    {
        [Fact]
        public void ForEachTest()
        {
            Action action = () =>
            {
                foreach (var p in new PathList(target))
                {
                }
            };

            action.Should().NotThrow();
        }
    }
}
