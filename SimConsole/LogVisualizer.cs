using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class LogVisualizer
{
    SimulationHistory Log { get; }
    public LogVisualizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex == 0)
        {
            Console.WriteLine($"Pozycja Startowa");
        }
        else
        {
            Console.WriteLine($"Tura {turnIndex} {Log.TurnLogs[turnIndex-1].Mappable} goes {DirTracker(Log.TurnLogs[turnIndex-1].Move[0])}");
        }

        int line = Log.SizeY - 1;
        Console.Write($"{Box.TopLeft}{Box.Horizontal}");
        for (int i = 0; i < Log.SizeX - 1; i++)
        {
            Console.Write(Box.TopMid);
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.TopRight);

        for (int i = 0; i < (Log.SizeY * 2) - 1; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < Log.SizeX; j++)
                {
                    Console.Write(Box.Vertical);
                    Console.Write(Log.TurnLogs[turnIndex].Symbols[new Point(j, line)]);
                }
                line--;
                Console.Write(Box.Vertical);
            }
            else
            {
                Console.Write(Box.MidLeft);
                for (int j = 0; j < Log.SizeX - 1; j++)
                {
                    Console.Write(Box.Horizontal);
                    Console.Write(Box.Cross);
                }
                Console.Write($"{Box.Horizontal}{Box.MidRight}");
            }
            Console.WriteLine();
        }

        Console.Write($"{Box.BottomLeft}{Box.Horizontal}");
        for (int i = 0; i < Log.SizeX - 1; i++)
        {
            Console.Write(Box.BottomMid);
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.BottomRight);
    }

    private string DirTracker(char a)
    {
        switch (a)
        {
            case 'u': return "up";
            case 'd': return "down";
            case 'r': return "right";
            case 'l': return "left";
            default: return "N/A";
        }
    }
}