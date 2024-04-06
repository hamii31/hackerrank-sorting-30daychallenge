using System.Linq;

namespace edabit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            ArrayOfMultiples(num, length);

            //Console.WriteLine(string.Join(",", ArrayOfMultiples(num, length)));
        }
        public static int[] ArrayOfMultiples(int num, int length)
        {
            int[] list = new int[length];
            for (int i = 1; i <= length; i++)
            {
                int numToMultiply = num;
                list[i-1] = (numToMultiply *= i);
            }

            return list;
        }
       
    }
}
