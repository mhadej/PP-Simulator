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

        public char Symbol => 'A';

        void IMappable.Go(Direction direction, bool output)
        {
            // zgodnie z regułą mapy
            try
            {
                Map?.Move(this, Position, Map.Next(Position, direction));
            }
            catch (NullReferenceException)
            {
                if(output)
                {
                     Console.WriteLine($"This creature ({this}) is not on any map!");
                }
            }
            if (output)
            {
                Console.WriteLine($"{direction.ToString().ToLower()}");
            }
        }
        void IMappable.InitMapAndPosition(Map map, Point p)
        {
            Map = map;
            Position = p;
        }
        public override string ToString() => base.GetType().ToString().ToUpper() + ": " + this.Info;

    }

    public class Birds : Animals, IMappable
    {
        void IMappable.Go(Direction direction, bool output)
        {
            if(CanFly)
            {
                Map?.Move( this, Position, Map.Next(Map.Next(Position, direction), direction));
            }
            else
            {
                Map?.Move(this, Position, Map.NextDiagonal(Position, direction));
            }

            if (output)
            {
                Console.WriteLine($"{direction.ToString().ToLower()}");
            }
        }
        public bool CanFly
        {
            set;
            get;
        } = true;

        public char Symbol => CanFly ? 'B' : 'b';

        public override string Info => $"{Description} " + (CanFly ? "(fly+)" : "(fly-)") + $" <{Size}>";
    }
}
