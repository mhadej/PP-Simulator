namespace Simulator
{
    public class DirectionParser
    {
        public static List<Direction> Parse(string directions)
        {
            List<Direction> end = new();
            int next = 0;

            foreach(char letter in directions.ToLower())
            {
                switch(letter)
                {
                    case 'u':
                        {
                            end.Add((Direction)0);
                            next++;
                            break;
                        }
                    case 'r':
                        {
                            end.Add((Direction)1);
                            next++;
                            break;
                        }
                    case 'd':
                        {
                            end.Add((Direction)2);
                            next++;
                            break;
                        }
                    case 'l':
                        {
                            end.Add((Direction)3);
                            next++;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return end;
        }
    }
}
