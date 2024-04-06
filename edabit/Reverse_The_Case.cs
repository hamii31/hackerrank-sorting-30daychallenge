namespace edabit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Happy Birthday";

            Console.WriteLine(ReverseCase(str));

            //Console.WriteLine(string.Join(",", ArrayOfMultiples(num, length)));
        }
        public static string ReverseCase(string str)
        {
            List<char> strings = new List<char>();

            foreach (char s in str)
            {
                if (char.IsLower(s))
                {
                    // Make uppercase
                    char c = char.ToUpper(s);
                    strings.Add(c);
                }
                else
                {
                    // Make lowercase
                    char c = char.ToLower(s);
                    strings.Add(c);
                }
            }

            string newStr = new string(strings.ToArray());

            return newStr;
        }
    }
}
