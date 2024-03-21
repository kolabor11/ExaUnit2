
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string json = @"
        [
            6410,
            2831,
            5049,
            7554,
            [
                8707,
                6940,
                9517,
                7565,
                7522,
                9242,
                7972,
                7064,
                3441,
                [
                    9960,
                    4966,
                    9368,
                    1634,
                    5150,
                    3709,
                    6660,
                    [
                        7155, 8056, 7834,
                        2639, 6601, 8063,
                        2390, 2544, 7022
                    ]
                ],
                2385,
                573,
                656,
                733,
                1620,
                3626,
                [
                    6274,
                    1935,
                    [ 6481, 928, 8291, 3196, 3431, 6058 ],
                    8010,
                    5052,
                    892,
                    3490,
                    2369,
                    951,
                    1606,
                    6763,
                    7260,
                    6122
                ]
            ],
            5655,
            4223
        ]";

    
        List<object> array = ParseJsonArray(json);
        List<int> flattened = FlattenArray(array);
        foreach (int num in flattened)
        {
            Console.WriteLine(num);
        }
    }

    public static List<object> ParseJsonArray(string json)
    {
        List<object> array = new List<object>();
        int i = 0;
        while (i < json.Length)
        {
            if (json[i] == '[')
            {
                int startIndex = i + 1;
                int endIndex = FindEndOfArray(json, startIndex);
                string subArrayJson = json.Substring(startIndex, endIndex - startIndex);
                array.Add(ParseJsonArray(subArrayJson));
                i = endIndex + 1;
            }
            else if (json[i] == ']' || json[i] == ',')
            {
                i++;
            }
            else
            {
                int endIndex = FindEndOfNumber(json, i);
                string numStr = json.Substring(i, endIndex - i);
                array.Add(int.Parse(numStr));
                i = endIndex;
            }
        }
        return array;
    }

    public static int FindEndOfArray(string json, int startIndex)
    {
        int count = 1;
        int i = startIndex;
        while (count != 0)
        {
            if (json[i] == '[')
                count++;
            else if (json[i] == ']')
                count--;
            i++;
        }
        return i - 1;
    }

    public static int FindEndOfNumber(string json, int startIndex)
    {
        int i = startIndex;
        while (i < json.Length && char.IsDigit(json[i]))
        {
            i++;
        }
        return i;
    }

    public static List<int> FlattenArray(List<object> array)
    {
        List<int> flattened = new List<int>();
        FlattenArrayHelper(array, flattened);
        return flattened;
    }

    private static void FlattenArrayHelper(List<object> array, List<int> flattened)
    {
        foreach (var item in array)
        {
            if (item is int)
            {
                flattened.Add((int)item);
            }
            else if (item is List<object>)
            {
                FlattenArrayHelper((List<object>)item, flattened);
            }
        }
    }
}
