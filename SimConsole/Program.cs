using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Starting position:");
            Console.OutputEncoding = Encoding.UTF8;

            BigTorusMap map = new(8, 6);

            List<IMappable> creatures = 
                [
                new Orc("Gorbag"), 
                new Elf("Elandor"), 
                new Animals { Description = "Rabbits", Size = 20}, 
                new Birds { Description = "Eagles"}, 
                new Birds { Description = "Ostriches", CanFly = false}
                ];

            List<Point> points = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
            string moves = "dlrludluddlrulr";

            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            //mapVisualizer.Draw();

            //for (int i = 0; i < 3; i++)
            //{
            //    Console.ReadKey();
            //    Console.Clear();
            //    Console.WriteLine($"{i + 1}. Turn");
            //    simulation.Turn(true);
            //    mapVisualizer.Draw();
            //}

            SimulationHistory hist = new(simulation);

            LogVisualizer logv = new(hist);

            logv.Draw(0);
            logv.Draw(5);
            logv.Draw(10);
            logv.Draw(15);

        }
    }
}
