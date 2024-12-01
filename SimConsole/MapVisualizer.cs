using Simulator;
using Simulator.Maps;
using System.Xml.Schema;

namespace SimConsole
{
    public class MapVisualizer
    {
        private Map Map;
        public MapVisualizer(Map map)
        {
            Map = map;
        }

        public void Draw()
        {
            int line = Map.SizeY - 1;
            Console.Write($"{Box.TopLeft}{Box.Horizontal}");
            for(int i = 0; i < Map.SizeX-1; i++)
            {
                Console.Write(Box.TopMid);
                Console.Write(Box.Horizontal);
            }
            Console.WriteLine(Box.TopRight);

            for(int i = 0; i < (Map.SizeY*2) - 1; i++)
            {
                if(i%2 == 0)
                {
                    for (int j = 0; j < Map.SizeX; j++)
                    {
                        Console.Write(Box.Vertical);

                        if (Map.At(j, line)?.Count == 1)
                        {
                            Map.At(j, line)?[0].Symbol();
                        }
                        else if (Map.At(j, line)?.Count > 1)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write($" ");
                        }
                    }
                    line--;
                    Console.Write(Box.Vertical);
                }
                else
                {
                    Console.Write(Box.MidLeft);
                    for (int j = 0; j < Map.SizeX - 1; j++)
                    {
                        Console.Write(Box.Horizontal);
                        Console.Write(Box.Cross);
                    }
                    Console.Write($"{Box.Horizontal}{Box.MidRight}");
                }
                Console.WriteLine();
            }

            Console.Write($"{Box.BottomLeft}{Box.Horizontal}");
            for (int i = 0; i < Map.SizeX - 1; i++)
            {
                Console.Write(Box.BottomMid);
                Console.Write(Box.Horizontal);
            }
            Console.WriteLine(Box.BottomRight);
        }
    }
}
