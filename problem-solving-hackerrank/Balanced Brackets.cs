using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'isBalanced' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isBalanced(string s)
    {
        
        for (int i = 0; i < s.Length - 1; i++)
        {
            switch (s[i])
            {
                case '[':
                    if (s[i + 1] == ')' || s[i] == '}')
                        return "NO";
                    break;
                case '{':
                    if (s[i + 1] == ']' || s[i + 1] == ')')
                        return "NO";
                    break;
                case '(':
                    if (s[i + 1] == '}' || s[i + 1] == ']')
                        return "NO";
                    break;
                default:
                    break;
            }
            
        }

        // check if first and last bracket are the same if open
        switch (s[0])
        {
            case '}':
                if (s[s.Length - 1] != '{')
                    return "NO";
                break;
            case ')':
                if (s[s.Length - 1] != '(')
                    return "NO";
                break;
            case ']':
                if (s[s.Length - 1] != '[')
                    return "NO";
                break;
            default:
                break;
        }

        // check if the length is even or odd
        if (s.Length % 2 == 0)
            return "YES";

        return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = Result.isBalanced(s);

            Console.WriteLine(result);
        }
        
    }
}
