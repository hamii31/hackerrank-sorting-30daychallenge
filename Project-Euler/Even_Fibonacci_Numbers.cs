namespace Project_Euler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 1;
            var y = 0;
            var sum = 0;
            for (int i = 0; i < 16; i++)
            {
                y += n;
                n += y;

                if(y >= 4000000 || n >= 4000000)
                {
                    break;
                }
                else
                {
                    if (n % 2 == 0)
                    {
                        sum += n;
                    }
                    else if (y % 2 == 0)
                    {
                        sum += y;
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
