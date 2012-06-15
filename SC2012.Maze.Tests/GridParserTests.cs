using System;
using NUnit.Framework;
using SharpTestsEx;

namespace SC2012.Maze.Tests
{
    [TestFixture]
    public class GridParserTests
    {
        private GridParser subject;

        [SetUp]
        public void SetUp()
        {
            subject = new GridParser();
        }

        [Test]
        public void Parseinput()
        {
            const string input = "*";

            var actual = subject.ParseGrid(input);

            actual.Length.Should().Be(1);
            actual[0, 0].Should().Be(CellType.Wall);
        }
        
        [Test]
        public void ParseIce()
        {
            const string input = "_";

            var actual = subject.ParseGrid(input);

            actual.Length.Should().Be(1);
            actual[0, 0].Should().Be(CellType.Ice);
        }

        [Test]
        public void ParseClear()
        {
            const string input = ".";

            var actual = subject.ParseGrid(input);

            actual.Length.Should().Be(1);
            actual[0, 0].Should().Be(CellType.Clear);
        }

        [Test]
        public void ParsePlayer1()
        {
            const string input = "1";

            var actual = subject.ParseGrid(input);

            actual.Length.Should().Be(1);
            actual[0, 0].Should().Be(CellType.Player1);
        }

        [Test]
        public void ParsePlayer2()
        {
            const string input = "2";

            var actual = subject.ParseGrid(input);

            actual.Length.Should().Be(1);
            actual[0, 0].Should().Be(CellType.Player2);
        }

        [Test]
        public void ParseFinish()
        {
            const string input = "F";

            var actual = subject.ParseGrid(input);

            actual.Length.Should().Be(1);
            actual[0, 0].Should().Be(CellType.Finish);
        }

        [Test]
        public void Parse_2x2_Grid()
        {
            var input = string.Format("*_{0}..", Environment.NewLine);

            var actual = subject.ParseGrid(input);

            actual[0, 0].Should().Be(CellType.Clear);
            actual[0, 1].Should().Be(CellType.Clear);
            actual[1, 0].Should().Be(CellType.Wall);
            actual[1, 1].Should().Be(CellType.Ice);
        }


    }
}
