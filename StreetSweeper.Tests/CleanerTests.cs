using FluentAssertions;
using StreetSweeper.Core;

namespace StreetSweeper.Tests
{
    [Collection("PathTests")]
    public class CleanerTests : BaseTest
    {
        [Fact]
        public void GetPathAsListTest()
        {
            // Arrange
            SetPath("C:\\Windows;C:\\Windows\\System32;C:\\Users\\Me");
            // Act
            var paths = Cleaner.GetPathAsList(target);
            paths.Should().Equal("C:\\Windows", "C:\\Windows\\System32", "C:\\Users\\Me");
        }

        [Fact]
        public void RemoveDuplicatesTest()
        {
            // Arrange, set fake environment
            SetPath("C:\\duplicate;C:\\duplicate");
            // Act
            Cleaner.RemoveDuplicates(target);
            // Assert
            GetPath().Should().Be("C:\\duplicate");
        }

        [Fact]
        public void RemoveNonExistentTest()
        {
            // Arrange
            var target = EnvironmentVariableTarget.Process;
            SetPath("C:\\Windows;C:\\nope");
            // Act
            Cleaner.RemoveDeleted(target);
            // Assert
            GetPath().Should().Be("C:\\Windows");
        }

        [Fact]
        public void RemoveDuplicatesAcrossTargetsArgumentOrderTest()
        {
            // Arrange
            Action act = () => { Cleaner.RemoveDuplicatesAcrossTargets(EnvironmentVariableTarget.Process, EnvironmentVariableTarget.Machine); };
            // Act, Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void RemoveDuplicatesAcrossTargetsTest()
        {
            // Arrange
            SetPath("C:\\Windows;C:\\Users\\Me;C:\\Windows\\system32;C:\\Users\\Me\\Code");
            // Act
            Cleaner.RemoveDuplicatesAcrossTargets(EnvironmentVariableTarget.Machine, target);
            // Assert
            GetPath().Should().Be("C:\\Users\\Me;C:\\Users\\Me\\Code");
        }

        [Fact]
        public void GetDuplicatesTest()
        {
            // Arrange
            SetPath("C:\\Windows\\system32;C:\\Windows;C:\\Windows;C:\\Users\\Me");
            var duplicates = Cleaner.GetDuplicates(target);
            duplicates.Should().BeEquivalentTo("C:\\Windows");
        }
    }
}
