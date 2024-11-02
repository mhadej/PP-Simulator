namespace Simulator
{
    public abstract class Creature
    {
        private string name = "Unknown";
        private int level = 1;
        protected int counter = 1;
        public string Name
        {
            get => name;
            init
            {
                name = string.IsNullOrEmpty(value) ? "Unknown" : value.Trim();
                name = name.Length >= 3 ? name : name + new string('#', (3 - name.Length));
                name = name.Length > 25 ? name[..25] : name;
                name = name.Trim();
                name = name.Length >= 3 ? name : name + new string('#', (3 - name.Length));
                name = name.ToUpper()[0] + name[1..name.Length];
            }
        }

        public abstract int Power { get; }
            

        public int Level    
        { 
            get => level; 
            init
            {
                level = (value >= 1 && value <= 10) ? value : (value < 1 ? 1 : 10);
            }
        }

        public Creature(string name, int level = 1)
        {
            Level = level;
            Name = name;
        }

        public Creature() { }

        public abstract void SayHi();

        public string Info => $"{Name} - {Level}";

        public void Upgrade()
        {
            this.level = this.level < 10 ? ++this.level : 10;
        }

        public void Go(Direction dir)
        {
            Console.WriteLine($"{this.name} goes {dir.ToString().ToLower()}");
        }

        public void Go(Direction[] dirtable)
        {
            foreach(Direction move in dirtable)
            {
                Go(move);
            }
        }

        public void Go(string moves)
        {
            Go(DirectionParser.Parse(moves));
        }
    }

    public class Elf : Creature
    {
        private int agility;
        public int Agility 
        {
            get  => agility;
            init => agility = (value >= 1 && value <= 10) ? value : (value < 1 ? 1 : 10);
        }
        public void Sing()
        {
            agility += (this.counter % 3 == 0) ? (agility < 10 ? 1 : 0) : 0;
            this.counter++;
            Console.WriteLine($"{Name} is singing.");
        }

        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

        public Elf(string name = "N/Ae", int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }

        public override int Power => Level * 8 + Agility * 2;
        public Elf() { }
    }
    public class Orc : Creature
    {
        private int rage;
        public int Rage
        {
            get  => rage;
            init => rage = (value >= 1 && value <= 10) ? value : (value < 1 ? 1 : 10);
        }
        public void Hunt()
        {
            rage += (this.counter % 2 == 0) ? (rage < 10 ? 1 : 0) : 0;
            this.counter++;
            Console.WriteLine($"{this.counter}. - {Name} is hunting.");
        }


        public Orc(string name = "N/Ao", int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }

        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

        public override int Power => Level * 7 + Rage * 3;


        //public Orc() : base("N/A", 10) => Rage = 6;

        public Orc() { }
    }

}
