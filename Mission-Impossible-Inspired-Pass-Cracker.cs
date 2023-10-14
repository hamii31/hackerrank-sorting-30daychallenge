using System.Diagnostics;

namespace rainbow_pass_cracker_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pass = GenerateRandomNumberPassword();

            CrackPass(pass);
        }

        private static void CrackPass(int pass)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string passToString = Convert.ToString(pass);
            string generatedPass = "";

            foreach (var item in passToString)
            {
                int generatedNumber = 0;

                for (int i = 0; i < 10; i++)
                {
                    if (generatedNumber.ToString() == item.ToString())
                    {
                        generatedPass += generatedNumber;
                        break;
                    }

                    generatedNumber++;
                }
                Console.WriteLine(generatedPass);
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Original pass: " + pass);
            Console.WriteLine("The pass was cracked in: " + sw.ElapsedMilliseconds + "ms");
        }

        static int GenerateRandomNumberPassword()
        {
            Random rng = new Random();
            return rng.Next();
        }
    }
}
