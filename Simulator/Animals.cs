namespace Simulator
{
    public class Animals
    {
        private string description = "N/A";
        public required string Description 
        {
            get  => description;
            init => description = Validator.Shortener(value, max: 15);
        }
        public uint Size { get; set; } = 3;

        public virtual string Info => $"{Description} <{Size}>";

        public override string ToString() => base.GetType().ToString().ToUpper() + ": " + this.Info;
    }

    public class Birds : Animals
    {
        private bool canfly;

        public bool CanFly
        {
            set;
            get;
        } = true;

        public override string Info => $"{Description} " + (CanFly ? "(fly+)" : "(fly-)") + $" <{Size}>";
    }
}
