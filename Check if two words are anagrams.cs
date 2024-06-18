namespace Anagrams
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Check if anagrams

            string word = "anagram";
            string anagram = "marnaga";

            List<char> anagramChars = anagram.ToList();

            int successCount = 0;

            foreach (char c in anagramChars)
            {
                if (word.Contains(c))
                {
                    successCount++;
                }
            }

            if( successCount == word.Length)
                Console.WriteLine($"{word} and {anagram} are anagrams!");

            else
                Console.WriteLine("Nope.");

        }
        
    }
}
