public class Solution {
    public int CountPrefixSuffixPairs(string[] words) {
        if(words.Length == 1) 
            return 0;
        var count = 0;
        for(var i = 0; i < words.Length; i++){
            for(var j = i + 1; j < words.Length; j++){
                if(words[j].Length < words[i].Length) 
                    continue;
                var pre = words[j].Substring(0, words[i].Length);
                var suf = words[j].Substring(words[j].Length - words[i].Length, words[i].Length);
                if(words[i] == pre && words[i] == suf)
                    count++;
            }
        }
        return count;
    }
}
