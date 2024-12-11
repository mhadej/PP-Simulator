using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0
        
    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        for(int i = 0; i <= _simulation.Moves.Length; i++)
        {
            Dictionary<Point, char> temp = new();

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    if (_simulation.Map.At(x, y)?.Count == 1)
                    {
                        temp.Add(new Point(x, y), _simulation.Map.At(x, y)[0].Symbol);
                    }
                    else if (_simulation.Map.At(x, y)?.Count > 1)
                    {
                        temp.Add(new Point(x, y), 'X');
                    }
                    else
                    {
                        temp.Add(new Point(x, y), ' ');
                    }
                }
            }
            
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = (i == _simulation.Moves.Length) ? " " : _simulation.CurrentMoveName,
                Symbols = temp
            });

            _simulation.Turn(false);
        }
    }
}
