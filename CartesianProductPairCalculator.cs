namespace CartesianProductPairCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> A = new HashSet<int>()
            {
                1,2,3,4,5,6,
            };
            HashSet<int> B = new HashSet<int>()
            {
                2,3,4,5,6,7,8
            };

            int pairs = PairCalculator(A, B);
            Console.WriteLine(pairs);
        }
        public static int PairCalculator(HashSet<int> A, HashSet<int> B)
        {
            int pairs = 0;

            for (int i = 0; i < A.Count; i++)
            {
                for (int r = 0; r < B.Count; r++)
                {
                    pairs++;
                }
            }
            return pairs;
        }
    }
}
