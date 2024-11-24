﻿using Simulator.Maps;
using System.Text;
using SimConsole;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\nStarting position:");
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();

        for (int i = 0; i < moves.Length; i++)
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"{i+1}. Turn");
            mapVisualizer.Draw();
            simulation.Turn();
        }
    }
}