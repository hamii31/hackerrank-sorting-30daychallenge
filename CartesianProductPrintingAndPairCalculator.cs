using System.Text;

namespace CartesianProductPairCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>()
            {
                1,2,3,4,5,6,
            };
            List<string> b = new List<string>()
            {
                "b", "u", "m", "e", "s", "e"
            };

            (StringBuilder aXb, int pairs) = PairCalculator(a, b);

            Console.WriteLine(string.Join("", aXb));

            Console.WriteLine();

            Console.WriteLine("Total pairs in the Cartesian product: " + pairs);
        }
        public static Tuple<StringBuilder, int> PairCalculator(List<int> a, List<string> b)
        {
            StringBuilder CP = new StringBuilder();
            int pairs = 0;

            for (int i = 0; i < a.Count; i++)
            {
                for (int r = 0; r < b.Count; r++)
                {
                    CP.Append("[" + a[i].ToString() + "," + b[r]+ "]; ");
                    pairs++;
                }
                CP.AppendLine();
            }

            return Tuple.Create(CP, pairs);
        }
    }
}
