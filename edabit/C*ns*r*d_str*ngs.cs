namespace edabit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txt = "Wh*r* d*d my v*w*ls g*?";
            string vowels = "eeioeo";

            Console.WriteLine(Uncensor(txt, vowels));
        }
        public static string Uncensor(string txt, string vowels)
        {

           Queue<char> queue = new Queue<char>();

            foreach (char item in vowels)
            {
                queue.Enqueue(item);
            }

            List<char> chars = new List<char>();

           foreach(char c in txt)
            {
                if (c == '*')
                {

                    chars.Add(queue.Dequeue());
                }
                else
                {
                    chars.Add(c);
                }
               
            }

            string newStr = new string(chars.ToArray());

            return newStr;
        }
    }
}
