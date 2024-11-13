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

        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

        public string[] Go(Direction[] dirtable)
        {
            string[] output = new string[dirtable.Length];

            for(int i=0; i<dirtable.Length; i++)
            {
                output[i] = Go(dirtable[i]);
            }

            return output;
        }

        public string[] Go(string moves) => Go(DirectionParser.Parse(moves));

    }

    public class Elf : Creature
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
    }
    public class Orc : Creature
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
    }

}
