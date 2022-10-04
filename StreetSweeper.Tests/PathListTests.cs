using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using StreetSweeper.Core;

namespace StreetSweeper.Tests
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
