namespace binaryToText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string binary = "";

            string s = Console.ReadLine();
            Console.WriteLine($"The string '{s}' \n");
            Console.Write("Is turned into: ");

            int counter = 0;
            while (counter != s.Length)
            {
                int[] a = ConvertTextToBinary(s[counter], 2).ToArray();
                for (int i = 0; i < a.Length; i++)
                {
                    binary += a[i].ToString();
                    
                }
                binary += " ";
                counter++;
            }

            List<char> list = ConvertFromBinaryToText(binary);
            Console.WriteLine(string.Join("", list));
        }
        static List<char> ConvertFromBinaryToText(string binary)
        {
            var splitted = binary.Split(" ");
            List<int> binaryList = new List<int>(); // Add binary numbers by hand if you want to translate directly binary

            foreach (var i in splitted)
            {
                if (i != "")
                {
                    binaryList.Add(int.Parse(i));
                }
            }

            Console.WriteLine(string.Join(" ", binaryList) + "\n");
            Console.Write("And then back into: ");
            List<char> res = new List<char>();

            // Convert Binary To Text
            foreach (var bi in binaryList)
            {
                string v = bi.ToString();
                List<int> letter = new List<int>();
                for (int i = 0; i <= v.Length - 1; i++)
                {
                    var l = v[i] - '0';
                    letter.Add(l);
                }

                int result = 0;
                int bitValue = 1;

                for (int i = letter.Count - 1; i >= 0; i--)
                {
                    result += letter[i] * bitValue;
                    bitValue *= 2;
                }

                res.Add((char)result);
            }
            return res;
        }
        static List<int> ConvertTextToBinary(int number, int Base)
        {
            List<int> list = new List<int>();
            while (number != 0)
            {
                list.Add(number % Base);
                number /= Base;
            }
            list.Reverse();
            return list;
        }
    }
}
