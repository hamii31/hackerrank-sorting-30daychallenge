class Result
{

    /*
     * Complete the 'camelcase' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int camelcase(string s)
    {
        string[] words = Regex.Split(s, @"(?<!^)(?=[A-Z])");

        return words.Length;
    }

}
