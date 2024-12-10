using Simulator.Maps;
using System.Text;
using SimConsole;
using Simulator;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        BigBounceMap map = new(8, 6);

        List<IMappable> creatures =
            [
            new Elf("Elandor"),
                new Orc("Gorbag"),
                new Animals { Description = "Rabbits", Size = 20},
                new Birds { Description = "Eagles"},
                new Birds { Description = "Ostriches", CanFly = false}
            ];

        List<Point> points = [new(0, 0), new(7, 0), new(7, 5), new(0, 5), new(7, 5)];
        string moves = "drUdurdurdruulrXXXXudlruudlrooxuuurlr";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        SimulationHistory hist = new(simulation);
    }
}