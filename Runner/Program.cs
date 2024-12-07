using Simulator.Maps;
using System.Text;
using SimConsole;
using Simulator;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!");

        bool one = true;
        if (one)
        {
            BigBounceMap mapa = new(8, 10);

            Point[] points = [new Point(0,0), new Point(4,0),
            new Point(0,9), new Point(4,9)];

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{points[i]}");
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"{(Direction)j}: ");
                    Console.WriteLine(mapa.NextDiagonal(points[i % 4], (Direction)j));
                }
                Console.WriteLine();
            }
        }

        Dictionary<Point, List<IMappable>>? _fields = new();

        List<IMappable> imap = new();
        imap.Add(new Elf("Elandor", 2));
        imap.Add(new Orc("Uruk", 7));
        imap.Add(new Birds { Description = "Strusie", Size = 21});
        Point p1 = new(0, 0);

        _fields[p1] = imap;

        Console.WriteLine(_fields[p1]);
    }
}