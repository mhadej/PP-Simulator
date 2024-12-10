using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature : IMappable
    {
        public Map? Map { get; private set; }
        public Point Position { get; private set; }

        private string name = "Unknown";
        private int level = 1;
        protected int counter = 1;
        public string Name
        {
            get => name;
            init
            {
                name = Validator.Shortener(value);
            }
        }

        public abstract int Power { get; }

        public int Level
        {
            get => level;
            init
            {
                level = Validator.Limiter(value);
            }
        }

        public Creature(string name, int level = 1)
        {
            Level = level;
            Name = name;
        }

        public Creature() { }

        public abstract string Greeting();

        public abstract string Info { get; }

        public override string ToString()
        {
            return base.GetType().ToString().ToUpper() + ": " + this.Info;
        }

        public void Upgrade()
        {
            this.level = this.level < 10 ? ++this.level : 10;
        }

        void IMappable.Go(Direction direction, bool output)
        {
            // zgodnie z regułą mapy
            try
            {
                Map?.Move(this, Position, Map.Next(Position, direction));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"This creature ({this.name}) is not on any map!");
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

        void IMappable.Symbol() => Console.Write("C");

        public Point CurrentPosition()
        {
            return Position;
        }
    }

    public class Elf : Creature, IMappable
    {
        private int agility;
        public int Agility 
        {
            get  => agility;
            init => agility = Validator.Limiter(value, min: 0);
        }
        public void Sing()
        {
            agility += (this.counter % 3 == 0) ? (agility < 10 ? 1 : 0) : 0;
            this.counter++;
        }

        public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

        public Elf(string name = "N/Ae", int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }

        public override int Power => Level * 8 + Agility * 2;

        public override string Info => $"{Name} [{Level}][{Agility}]";
        public Elf() { }

        void IMappable.Symbol() => Console.Write("E");

    }
    public class Orc : Creature, IMappable
    {
        private int rage;
        public int Rage
        {
            get  => rage;
            init => rage = Validator.Limiter(value, min: 0);
        }
        public void Hunt()
        {
            rage += (this.counter % 2 == 0) ? (rage < 10 ? 1 : 0) : 0;
            this.counter++;
        }


        public Orc(string name = "N/Ao", int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }

        public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

        public override int Power => Level * 7 + Rage * 3;

        public override string Info => $"{Name} [{Level}][{Rage}]";


        //public Orc() : base("N/A", 10) => Rage = 6;

        public Orc() { }

        void IMappable.Symbol() => Console.Write("O");
    }

}
