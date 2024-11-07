namespace Simulator;

internal class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5a();
    }

    public static void Lab5a()
    {
        Point[] pts = [
            new(-3, 1), new(-1, 1),
            new(2, 1) , new(2, -1),
            new(5, -1), new(-2, 2)];

        Rectangle rec1 = new(4, 2, -2, -2);
        
        for(int i = 0; i < pts.Length; i++)
        {
            Console.WriteLine(rec1.Contains(pts[i]));
        }

        Console.WriteLine();

        for(int i = 0; i < pts.Length-1; i++)
        {
            try
            {
                Rectangle rec2 = new(pts[i], pts[i+1]);
                Console.WriteLine(rec2.ToString());
            }
            catch(Exception ex)
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
}




