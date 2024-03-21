using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ArrayFlattener
{
    public static List<int> FlattenArray(JArray array)
    {
        List<int> flattenedArray = new List<int>();

        foreach (var item in array)s
        {
            if (item.Type == JTokenType.Integer)
            {
                flattenedArray.Add((int)item);
            }
            else if (item.Type == JTokenType.Array)
            {
                var subArray = (JArray)item;
                flattenedArray.AddRange(FlattenArray(subArray));
            }
        }

        return flattenedArray;
    }
}    