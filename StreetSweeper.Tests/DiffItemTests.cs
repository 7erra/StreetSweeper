using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetSweeper.Core;
using FluentAssertions;

namespace StreetSweeper.Tests
{
    public class DiffItemTests
    {
        [Fact]
        public void EqualsTest()
        {
            string commonValue = "abcdef";
            DiffItem item1, item2;
            item1 = new(commonValue);
            item2 = new(commonValue);
            item1.Should().Be(item2);

            item1.IsMissing = true;
            item1.Should().NotBe(item2);
        }
    }
}
