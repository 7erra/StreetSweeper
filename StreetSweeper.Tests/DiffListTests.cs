using StreetSweeper.Core;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StreetSweeper.Tests
{
    public class DiffListTests
    {
        [Fact]
        public void SimpleTest()
        {
            var list1 = new List<string>() { "A", "B", "C" };
            var list2 = new List<string>() { "A", "C" };
            DiffList diff = new DiffList(list1, list2);
            diff[1].Should().Be(new DiffItem("B", missing: true));
        }
    }
}
