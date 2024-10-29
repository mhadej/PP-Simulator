namespace Simulator
{
    internal class Creature
    {
        private string name = "Unknown";
        private int level = 1;
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

        public void SayHi() => Console.WriteLine($"Hi, my name is {Name}, my level is {Level}");

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
}
