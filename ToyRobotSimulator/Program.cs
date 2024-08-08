using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tabletop = new Tabletop(5, 5);
            var robot = new Robot(tabletop);

            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;

                var command = ParseCommand(input);
                command?.Execute(robot);
            }
        }

        static ICommand ParseCommand(string input)
        {
            var parts = input.Split(' ');
            switch (parts[0])
            {
                case "PLACE":
                    var args = parts[1].Split(',');
                    var x = int.Parse(args[0]);
                    var y = int.Parse(args[1]);
                    var facing = (Direction)Enum.Parse(typeof(Direction), args[2]);
                    return new PlaceCommand(new Position(x, y, facing));
                case "MOVE":
                    return new MoveCommand();
                case "LEFT":
                    return new LeftCommand();
                case "RIGHT":
                    return new RightCommand();
                case "REPORT":
                    return new ReportCommand();
                default:
                    return null;
            }
        }
    }
}
