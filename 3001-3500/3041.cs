using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int MaxSelectedElements(int[] A) 
    {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            Array.Sort(A);
            int br = 0;
            foreach (int num in A) 
            {
                dictionary[num + 1] = dictionary.GetValueOrDefault(num, 0) + 1;
                dictionary[num] = dictionary.GetValueOrDefault(num - 1, 0) + 1;
                br = Math.Max(br, Math.Max(dictionary[num], dictionary[num + 1]));
            }
        
            return br;
    }
}
