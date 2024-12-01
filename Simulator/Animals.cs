using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {
        public Map? Map { get; private set; }
        public Point Position { get; private set; }


        private string description = "N/A";
        public required string Description 
        {
            get  => description;
            init => description = Validator.Shortener(value, max: 15);
        }
        public uint Size { get; set; } = 3;

        public virtual string Info => $"{Description} <{Size}>";

        void IMappable.Go(Direction direction)
        {
            // zgodnie z regułą mapy
            try
            {
                Map?.Move(this, Position, Map.Next(Position, direction));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"This creature ({this}) is not on any map!");
            }

            Console.WriteLine($"{direction.ToString().ToLower()}");
        }
        void IMappable.InitMapAndPosition(Map map, Point p)
        {
            Map = map;
            Position = p;
        }
        public override string ToString() => base.GetType().ToString().ToUpper() + ": " + this.Info;

        void IMappable.Symbol() => Console.Write("A");
    }

    public class Birds : Animals, IMappable
    {
        void IMappable.Go(Direction direction)
        {
            if(CanFly)
            {
                Map?.Move( this, Position, Map.Next(Map.Next(Position, direction), direction));
            }
            else
            {
                Map?.Move(this, Position, Map.NextDiagonal(Position, direction));
            }

            Console.WriteLine($"{direction.ToString().ToLower()}");
        }
        public bool CanFly
        {
            set;
            get;
        } = true;

        void IMappable.Symbol() => Console.Write(CanFly ? 'B' : 'b');

        public override string Info => $"{Description} " + (CanFly ? "(fly+)" : "(fly-)") + $" <{Size}>";
    }
}
