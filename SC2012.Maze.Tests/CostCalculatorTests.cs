using NUnit.Framework;
using SharpTestsEx;
using System.Linq;

namespace SC2012.Maze.Tests
{
    [TestFixture]
    public class CostCalculatorTests
    {
        private CostCalculator subject;

        [SetUp]
        public void SetUp()
        {
            subject = new CostCalculator();
        }

        [Test]
        public void Can_calculate_right()
        {
            var grid = new CellType[1,2];
            grid[0, 0] = CellType.Player1;
            grid[0, 1] = CellType.Clear;

            const int horizontalPosition = 0;
            const int verticalPosition = 0;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(1);
        }

        [Test]
        public void Can_calculate_left()
        {
            var grid = new CellType[1,2];
            grid[0, 0] = CellType.Clear;
            grid[0, 1] = CellType.Player1;

            const int horizontalPosition = 1;
            const int verticalPosition = 0;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(1);
        }

        [Test]
        public void Can_calculate_up()
        {
            var grid = new CellType[2,1];
            grid[0, 0] = CellType.Player1;
            grid[1, 0] = CellType.Clear;

            const int horizontalPosition = 0;
            const int verticalPosition = 0;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(1);
        }
        
        [Test]
        public void Can_calculate_down()
        {
            var grid = new CellType[2,1];
            grid[0, 0] = CellType.Clear;
            grid[1, 0] = CellType.Player1;

            const int horizontalPosition = 0;
            const int verticalPosition = 1;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(1);
        }

        [Test]
        public void Can_calculate_right_wall()
        {
            var grid = new CellType[1,2];
            grid[0, 0] = CellType.Player1;
            grid[0, 1] = CellType.Wall;

            const int horizontalPosition = 0;
            const int verticalPosition = 0;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(int.MaxValue);
        }
        
        [Test]
        public void Can_calculate_left_wall()
        {
            var grid = new CellType[1,2];
            grid[0, 0] = CellType.Wall;
            grid[0, 1] = CellType.Player1;

            const int horizontalPosition = 1;
            const int verticalPosition = 0;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(int.MaxValue);
        }

        [Test]
        public void Can_calculate_up_wall()
        {
            var grid = new CellType[2,1];
            grid[0, 0] = CellType.Wall;
            grid[1, 0] = CellType.Player1;

            const int horizontalPosition = 0;
            const int verticalPosition = 1;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(int.MaxValue);
        }

        [Test]
        public void Can_calculate_down_wall()
        {
            var grid = new CellType[2,1];
            grid[0, 0] = CellType.Player1;
            grid[1, 0] = CellType.Wall;

            const int horizontalPosition = 0;
            const int verticalPosition = 0;
            
            var results = subject.Calculate(grid, horizontalPosition, verticalPosition);

            results.Single().Cost.Should().Be(int.MaxValue);
        }
    }
}