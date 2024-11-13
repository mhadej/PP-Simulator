using Simulator.Maps;

namespace Simulator;

internal class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
    }

    public static void Lab5a()
    {
        Point[] pts = [
            new(-3, 1), new(-1, 1),
            new(2, 1) , new(2, -1),
            new(5, -1), new(-2, 2)];

        Rectangle rec1 = new(4, 2, -2, -2);

        for (int i = 0; i < pts.Length; i++)
        {
            Console.WriteLine(rec1.Contains(pts[i]));
        }

        Console.WriteLine();

        for (int i = 0; i < pts.Length - 1; i++)
        {
            try
            {
                Rectangle rec2 = new(pts[i], pts[i + 1]);
                Console.WriteLine(rec2.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /* 
        results:

        false
        true
        true
        true
        false
        true

        exception
        exception
        exception
        exception
        no exception
        */
    }

    public static void Lab5b()
    {
        try
        {
            SmallSquareMap map = new(10);

            Point point1 = new Point(0, 0);
            Point point2 = new Point(9, 9);
            Point point3 = new Point(10, 10);
            Point point4 = new Point(-1, -1);

            Point randomPoint = new Point(-20, 30);

            Console.WriteLine(map.Exist(point1));
            Console.WriteLine(map.Exist(point2));
            Console.WriteLine(map.Exist(point3));
            Console.WriteLine(map.Exist(point4));


            Console.WriteLine(map.Exist(randomPoint));

            /* results:
            true
            true
            false
            false

            False
            */

            Console.WriteLine(map.Next(point1, Direction.Up));
            Console.WriteLine(map.Next(point2, Direction.Right));
            Console.WriteLine(map.NextDiagonal(point1, Direction.Right));

            /* results:
            (0, 1)
            (9, 9)
            (0, 0)
            */

            try
            {
                SmallSquareMap invalidMap = new SmallSquareMap(25);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Expected Exception: {e.Message}");
            }

            try
            {
                SmallSquareMap invalidMap = new SmallSquareMap(3);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Expected Exception: {e.Message}");
            }

            Point edgePoint = new Point(9, 9);

            Console.WriteLine(map.Next(edgePoint, Direction.Left));
            Console.WriteLine(map.NextDiagonal(edgePoint, Direction.Down));
            Console.WriteLine(map.Next(edgePoint, Direction.Up));
            Console.WriteLine(map.NextDiagonal(edgePoint, Direction.Up));

            Console.WriteLine(map.NextDiagonal(randomPoint, Direction.Up));
            Console.WriteLine(map.NextDiagonal(randomPoint, Direction.Down));

            /* results:
            true
            (8, 9)
            (8, 8)
            (9, 9)
            (9, 9)

            (-20, 30)
            (-20, 30)
            */
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Exception: {ex.Message}");
        }
    }
}