using Simulator;
using Simulator.Maps;
using System.Collections.Generic;

namespace SimWeb;

public static class App
{
    public static readonly Simulation _sim;
    public static readonly SimulationHistory _simHis;
    static App()
    {
        _sim = 
            new Simulation(
                new BigTorusMap(8, 6),
                new List<IMappable>([new Orc("Gorbag"), new Elf("Elandor"),
                                     new Animals { Description = "Rabbits", Size = 20},
                                     new Birds { Description = "Eagles"},
                                     new Birds { Description = "Ostriches", CanFly = false}]),
                new List<Point>([new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)]),
                "dlrludluddlrulr");

        _simHis = new SimulationHistory(_sim);
    }
}
