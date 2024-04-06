namespace edabit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 123;

            Console.WriteLine(ReverseAndNot(i));
        }
        public static string ReverseAndNot(int i)
        {
            string s = i.ToString();

            Stack<char> stack1 = new Stack<char>();
            Stack<char> stack2 = new Stack<char>();


            foreach (char c in s)
            {
                stack1.Push(c);

                // Rotate
                stack2.Push(stack1.Pop());
            }

            string stackToStr = new string(stack2.ToArray());

            string newStr = "";

            newStr += stackToStr + s; 

            return newStr;
        }
    }
}
