namespace Simulator
{
    internal class DirectionParser
    {
        public static Direction[] Parse(string directions)
        {
            Direction[] end = new Direction[directions.Length];
            int next = 0;

            foreach(char letter in directions.ToLower())
            {
                switch(letter)
                {
                    case 'u':
                        {
                            end[next] = (Direction)0;
                            next++;
                            break;
                        }
                    case 'r':
                        {
                            end[next] = (Direction)1;
                            next++;
                            break;
                        }
                    case 'd':
                        {
                            end[next] = (Direction)2;
                            next++;
                            break;
                        }
                    case 'l':
                        {
                            end[next] = (Direction)3;
                            next++;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            return end[..next];
        }
    }
}
