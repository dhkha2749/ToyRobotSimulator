using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface ICommand
    {
        void Execute(Robot robot);
    }

    public class PlaceCommand : ICommand
    {
        private readonly Position _position;

        public PlaceCommand(Position position)
        {
            _position = position;
        }

        public void Execute(Robot robot)
        {
            robot.Place(_position);
        }
    }

    public class MoveCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.Move();
        }
    }

    public class LeftCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.RotateLeft();
        }
    }

    public class RightCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.RotateRight();
        }
    }

    public class ReportCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            Console.WriteLine(robot.Report());
        }
    }

}
