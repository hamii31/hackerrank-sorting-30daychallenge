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
     * Complete the 'rotateLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> rotateLeft(int d, List<int> arr)
    {
        List<int> rotatedArr= new List<int>();
        for (int i = 0; i < d; i++) {
            for (int r = 1; r < arr.Count; r++)
            {
                rotatedArr.Add(arr[r]);
            }
            rotatedArr.Add(arr[0]);

            arr = rotatedArr.ToList();
            rotatedArr.Clear();
        }

        Console.WriteLine(string.Join(" ", arr));

        return arr;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
       
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.rotateLeft(d, arr);

    }
}
