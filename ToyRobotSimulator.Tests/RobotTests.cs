using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ToyRobotSimulator.Tests
{
       public class RobotTests
    {
        private readonly Tabletop _tabletop;
        private readonly Robot _robot;

        public RobotTests()
        {
            _tabletop = new Tabletop(5, 5);
            _robot = new Robot(_tabletop);
        }

        [Fact]
        public void Robot_Should_Be_Placed_Correctly()
        {
            // Arrange
            var expectedPosition = new Position(0, 0, Direction.NORTH);

            // Act
            _robot.Place(expectedPosition);

            // Assert
            Assert.AreEqual(expectedPosition, _robot.Position);
        }

        [Fact]
        public void Robot_Should_Ignore_Invalid_Placement()
        {
            // Arrange
            var invalidPosition = new Position(5, 5, Direction.NORTH);

            // Act
            _robot.Place(invalidPosition);

            // Assert
            Assert.IsNull(_robot.Position);
        }

        [Fact]
        public void Robot_Should_Move_Forward()
        {
            // Arrange
            var initialPosition = new Position(0, 0, Direction.NORTH);
            var expectedPosition = new Position(0, 1, Direction.NORTH);

            _robot.Place(initialPosition);

            // Act
            _robot.Move();

            // Assert
            Assert.AreEqual(expectedPosition, _robot.Position);
        }

        [Fact]
        public void Robot_Should_Not_Move_Beyond_Boundaries()
        {
            // Arrange
            var initialPosition = new Position(0, 4, Direction.NORTH); // Near the edge
            var expectedPosition = new Position(0, 4, Direction.NORTH); // Should not move beyond

            _robot.Place(initialPosition);

            // Act
            _robot.Move(); // This should not change the position

            // Assert
            Assert.AreEqual(expectedPosition, _robot.Position);
        }

        [Fact]
        public void Robot_Should_Rotate_Correctly()
        {
            // Arrange
            var initialPosition = new Position(0, 0, Direction.NORTH);
            var expectedPosition = new Position(0, 0, Direction.EAST); // Assuming rotation changes direction

            _robot.Place(initialPosition);

            // Act
            _robot.RotateRight(); // This method should rotate the robot to the right

            // Assert
            Assert.AreEqual(expectedPosition, _robot.Position);
        }
        [Fact]
        public void Robot_Should_Update_Position_When_Placed_Again()
        {
            // Arrange
            var initialPosition = new Position(0, 0, Direction.NORTH);
            var newPosition = new Position(1, 1, Direction.EAST);

            _robot.Place(initialPosition);

            // Act
            _robot.Place(newPosition);

            // Assert
            Assert.AreEqual(newPosition, _robot.Position);
        }

        // More tests here...
    }

}
