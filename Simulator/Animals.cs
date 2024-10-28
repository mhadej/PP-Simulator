namespace Simulator
{
    public class Animals
    {
        private string description = "N/A";
        public required string Description 
        {
            get => description;
            init
            {
                description = string.IsNullOrEmpty(value) ? "Unknown" : value.Trim();
                description = description.Length >= 3 ? description : description + new string('#', (3 - description.Length));
                description = description.Length > 15 ? description[..15] : description;
                description = description.Trim();
                description = description.Length > 15 ? description[..15] : description;
                description = description.ToUpper()[0] + description[1..description.Length];
            }
        }
        public uint Size { get; set; } = 3;

        public string Info => $"{Description} <{Size}>";
    }
}
