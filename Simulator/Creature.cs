namespace Simulator
{
    internal class Creature
    {
        private string? name;
        private int level;
        public string? Name { get; set; }
        public int Level    { get; set; } = 1;

        public Creature(string name, int level)
        {
            Level = level;
            this.Name = name;
        }

        public Creature() { }

        public void SayHi() => Console.WriteLine($"Hi, my name is {Name}, my level is {Level}");

        public string Info() => $"{Name} - {Level}";
    }
}
