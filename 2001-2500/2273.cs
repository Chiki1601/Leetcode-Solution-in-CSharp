public class Solution {
    public IList<string> RemoveAnagrams(string[] words)
    {
        List<string> res = new List<string>();
        res.Add(words[0]);
        
        for(int i = 1; i < words.Length; i++)
            if(!AnagramsTwoStr(words[i] , words[i-1]))
                res.Add(words[i]);
        
        return res;
    }

    static bool AnagramsTwoStr(string minusIndex, string index)
    {
        var minusIndexChars = minusIndex.ToCharArray();
        var indexChars = index.ToCharArray();
        Array.Sort(minusIndexChars);
        Array.Sort(indexChars);
        
        return new string(minusIndexChars) == new string(indexChars);
    }
}
