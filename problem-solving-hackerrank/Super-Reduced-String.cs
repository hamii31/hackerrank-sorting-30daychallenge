class Result
{

    /*
     * Complete the 'superReducedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string superReducedString(string s)
    {
       if (s.Length <= 2)
            {
                return "Empty String";
            }

            bool stop = false;
            while (!stop)
            {
                stop = true;
                if (s.Length < 2)
                {
                    break;
                }
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] == s[i + 1])
                    {
                        stop = false;
                        s = s.Remove(i, 2);
                        break;
                    }
                }
            }
            if (s.Length <= 2)
            {
                return "Empty String";
            }
            return s;
    }

}
