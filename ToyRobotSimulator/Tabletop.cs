using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class Tabletop
    {
        public int Width { get; }
        public int Height { get; }

        public Tabletop(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsPositionValid(Position position)
        {
            return position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;
        }
    }

    public class Robot
    {
        public Position Position { get; private set; }
        private readonly Tabletop _tabletop;

        public Robot(Tabletop tabletop)
        {
            _tabletop = tabletop;
        }

        public void Place(Position position)
        {
            if (_tabletop.IsPositionValid(position))
            {
                Position = position;
            }
        }

        public void Move()
        {
            if (Position == null) return;

            var newPosition = new Position(Position.X, Position.Y, Position.Facing);
            switch (Position.Facing)
            {
                case Direction.NORTH: newPosition.Y += 1; break;
                case Direction.EAST: newPosition.X += 1; break;
                case Direction.SOUTH: newPosition.Y -= 1; break;
                case Direction.WEST: newPosition.X -= 1; break;
            }

            if (_tabletop.IsPositionValid(newPosition))
            {
                Position = newPosition;
            }
        }

        public void RotateLeft()
        {
            if (Position == null) return;

            Position.Facing = (Direction)(((int)Position.Facing + 3) % 4);
        }

        public void RotateRight()
        {
            if (Position == null) return;

            Position.Facing = (Direction)(((int)Position.Facing + 1) % 4);
        }

        public string Report()
        {
            if (Position == null) return "Robot not placed.";

            return $"{Position.X},{Position.Y},{Position.Facing}";
        }
    }

}
