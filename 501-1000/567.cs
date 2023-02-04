public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length)
            return false;
        
        var s1Alphabet = new int[26];
        for (int index = 0; index < s1.Length; index++)
            s1Alphabet[(int)s1[index] - (int)'a']++;
        
        // check if s2 has a permutation of s1 
        
        var substringAlphabet = new int[26];
        int startIndex = 0;
        for (int endIndex = 0; endIndex < s2.Length; endIndex++)
        {            
            char ch = s2[endIndex];            
            substringAlphabet[(int)s2[endIndex] - (int)'a']++;
         
            if ((endIndex - startIndex) + 1 > s1.Length)
            {
                substringAlphabet[(int)s2[startIndex] - (int)'a']--;
                
                startIndex++;
            }
            
            if ((endIndex - startIndex) + 1 == s1.Length && ArePermutations(s1Alphabet, substringAlphabet))
                return true;
        }
        
        return false;
    }
    
    
    private static bool ArePermutations(int[] s1, int[] s2)
    {
        for (int index = 0; index < s1.Length; index++)
            if (s1[index] != s2[index])
                return false;
                
        return true;
    }
}
