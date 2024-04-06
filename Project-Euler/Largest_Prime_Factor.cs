using System.Numerics;

namespace Project_Euler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Takes a long time to calculate it, but it does the job. Will have to optimize it.
            BigInteger n = 600851475143; //6857

            //int n = 13195;

            List<BigInteger> nums = new List<BigInteger>();

            for (BigInteger i = 1; i <= n; i++)
            {
                if(n % i == 0)
                {
                    nums.Add(i);
                }
            }

            List<BigInteger> primes = new List<BigInteger>();

            BigInteger sum = 1;

            foreach (BigInteger num in nums)
            {
                sum *= num;
                primes.Add(num);
                if(sum == n)
                {
                    Console.WriteLine(primes.Max());
                    break;
                }
            }
        }
    }
}
