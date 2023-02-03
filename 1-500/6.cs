public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1)
        {
            return s;
        }
        
        char[] res = new char[s.Length];
        int i = 0,
            groupLen = numRows * 2 - 2;
        
        for (int j = 0; j < numRows; j++)
        {
            int k = (numRows - j - 1) * 2,
                l = j;
            
            while (l < s.Length)
            {
                res[i++] = s[l];
                
                if (j != 0 && j != numRows - 1 && l + k < s.Length)
                {
                    res[i++] = s[l + k];
                }
                
                l += groupLen;
            }
        }
        
        return new string(res);
    }
}
