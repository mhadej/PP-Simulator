using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X}, {Y})";

        public Point Next(Direction direction)
        {
            Point outcome = default;
            switch (direction)
            {
                case (Direction)0:
                    {
                        outcome = new(this.X, this.Y + 1);
                        break;
                    }
                case (Direction)1:
                    {
                        outcome = new(this.X + 1, this.Y);
                        break;
                    }
                case (Direction)2:
                    {
                        outcome = new(this.X, this.Y - 1);
                        break;
                    }
                case (Direction)3:
                    {
                        outcome = new(this.X - 1, this.Y);
                        break;
                    }
                default:
                    {
                        outcome = default;
                        break;
                    }
            }
            return outcome;
        }

        public Point NextDiagonal(Direction direction)
        {
            Point outcome = default;
            switch (direction)
            {
                case (Direction)0:
                    {
                        outcome = new(this.X + 1, this.Y + 1);
                        break;
                    }
                case (Direction)1:
                    {
                        outcome = new(this.X + 1, this.Y - 1);
                        break;
                    }
                case (Direction)2:
                    {
                        outcome = new(this.X - 1, this.Y - 1);
                        break;
                    }
                case (Direction)3:
                    {
                        outcome = new(this.X - 1, this.Y + 1);
                        break;
                    }
                default:
                    {
                        outcome = default;
                        break;
                    }
            }
            return outcome;
        }
    }
}
