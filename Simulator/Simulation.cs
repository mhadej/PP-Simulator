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
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

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
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    {
        /* implement getter only */
        get => Creatures[curr%Creatures.Count];
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        /* implement getter only */
        get => DirectionParser.Parse(Moves)[curr].ToString().ToLower();
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
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    { 
        if(creatures.Count < 1 || creatures.Count != positions.Count)
        {
            throw new Exception();
        }
        else
        {
            Map = map;
            Moves = moves;
            Creatures = creatures;
            Positions = positions;

            for(int i = 0; i < Creatures.Count; i++)
            {
                map.Add(Creatures[i], Positions[i]);
            }
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        /* implement */
        if (!Finished)
        {
            Point dest = Map.Next(CurrentCreature.Position, CurrentDirection);
            if (curr > Moves.Length)
            {
                Finished = true;
            }
            else
            {
                Console.WriteLine($"{CurrentCreature.Name} goes {CurrentMoveName} from {CurrentCreature.Position}");
                Map.Move(CurrentCreature, CurrentCreature.Position, dest);
                curr++;
            }
        }
        else
        {
            Console.WriteLine("All moves has been done.");
        }
    }
}