using Simulator.Maps;
using Simulator;
using System.Runtime.CompilerServices;

public class Simulation
{
    /// <summary>
    /// Index of current creature to move
    /// </summary>
    private int curr = 0;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Mappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; } = "";

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable
    {
        /* implement getter only */
        get => Mappables[curr% Mappables.Count];
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        /* implement getter only */
        get => Moves[curr].ToString().ToLower();
    }

    public Direction CurrentDirection 
    {
        get => DirectionParser.Parse(Moves)[curr];
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    { 
        if(mappables.Count < 1 || mappables.Count != positions.Count)
        {
            throw new Exception();
        }
        else
        {
            foreach (Direction dir in DirectionParser.Parse(moves))
            {
                Moves += dir.ToString()[0];
            }

            Map = map;
            Mappables = mappables;
            Positions = positions;

            for(int i = 0; i < Mappables.Count; i++)
            {
                map.Add(Mappables[i], Positions[i]);
            }
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn(bool showoutput) 
    {
        /* implement */
        if (!Finished)
        {
            if (curr >= Moves.Length)
            {
                Finished = true;
                Environment.Exit(0);
            }
            else
            {
                if (showoutput)
                {
                    Console.Write($"{CurrentMappable} goes ");
                }
                CurrentMappable.Go(CurrentDirection, showoutput);
                curr++;
            }
        }
        else
        {
            if (showoutput)
            {
                Console.WriteLine("All moves has been done.");
            }
        }
    }
}