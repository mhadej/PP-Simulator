using SimConsole;
using Simulator.Maps;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Simulator;

public class SimulationHistory
{
    private Simulation simulation;
    private Dictionary <int, object[]> process = new();
    private Map map;
    public SimulationHistory(Simulation sim)
    {
        simulation = sim;
        map = simulation.Map;
        SaveData();
    }

    private void SaveData()
    {

        for (int i = 0; i < simulation.Moves.Length; i++)
        {
            List<Point> pos = new();

            process[i] = new object[4];
            process[i][0] = simulation.Mappables;

            foreach (IMappable mappable in (List<IMappable>)process[i][0])
            {
                pos.Add(mappable.CurrentPosition());
            }

            process[i][1] = simulation.CurrentMappable;
            process[i][2] = simulation.CurrentMoveName;
            process[i][3] = pos;

            simulation.Turn(false);
        }
    }
    public void Step(int tura)
    {
        
        List<IMappable> lista2 = (List<IMappable>) process[tura][0];
        string ruch2           = (string)          process[tura][2];
        List<Point> pos2       = (List<Point>)     process[tura][3];

        List<IMappable> lista  = (List<IMappable>) process[tura - 1][0];
        IMappable obecny       = (IMappable)       process[tura - 1][1];
        string ruch            = (string)          process[tura - 1][2];
        List<Point> pos        = (List <Point>)    process[tura - 1][3];


        Console.WriteLine($"{tura-1}. Tura");
        Simulation sim = new(MapCleaner(map), lista, pos, ruch);
        MapVisualizer mapa1 = new(sim.Map);
        mapa1.Draw();
        MapCleaner(map);


        Console.WriteLine($"{obecny} goes {DirTracker(ruch[0])}");
        Console.ReadKey();
        Console.WriteLine($"{tura}. Tura");

        Simulation sim2 = new(MapCleaner(map), lista2, pos2, ruch2);
        MapVisualizer mapa2 = new(sim2.Map);
        mapa2.Draw();
    }
    private string DirTracker(char a)
    {
        switch(a)
        {
            case 'u': return "up";
            case 'd': return "down";
            case 'r': return "right";
            case 'l': return "left";
            default: return "N/A";
        }
    }

    private Map MapCleaner(Map mapa)
    {
        List<IMappable> toRemove = new List<IMappable>();

        for (int x = 0; x < mapa.SizeX; x++)
        {
            for(int y = 0; y < mapa.SizeY; y++)
            {
                if(mapa.At(x, y)?.Count > 0)
                {
                    foreach (IMappable kreatura in mapa.At(x, y))
                    {
                        toRemove.Add(kreatura);
                    }

                    foreach (IMappable kreatura in toRemove)
                    {
                        mapa.Remove(kreatura, new Point(x, y));
                    }                   
                }
            }
        }

        return mapa;
    }
}
