public class Solution 
{
    public bool AreAlmostEqual(string s1, string s2) 
    {
        int[] freq = new int[26];
        int count = 0;
        for(int i = 0; i < s1.Length; i++)
        {
            if(count > 2)
                return false;
            if(s1[i] != s2[i])
                count++;
            freq[s1[i]-'a']++;
        }
        for(int i = 0; i < s1.Length; i++)
        {
            freq[s2[i]-'a']--;
            if(freq[s2[i]-'a'] < 0)
                return false;
        }
        return count < 3;
    }
}
