public class Solution {
    private bool IsHammingDist(string s1, string s2)
    {
        int len = s1.Length;
        if(s2.Length != len)
            return false;

        int diffCnt = 0;
        for(int i = 0; i < len; i++)
        {
            if(s1[i] != s2[i])
            {
                if(++diffCnt > 1)
                    return false;
            }
        }

        return diffCnt == 1;
    }
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups) {
       int len = words.Length;
        int[] dp = Enumerable.Repeat(1, len).ToArray(), preId = Enumerable.Repeat(-1, len).ToArray();
        int maxLen = 1, maxId = 0;
        for(int i = 1; i < len; i++)
        {
            for(int j = 0; j < i; j++)
            {
                if(groups[i] == groups[j])
                    continue;

                if(IsHammingDist(words[i], words[j]))
                {
                    if(dp[j]+1 > dp[i])
                    {
                        dp[i] = dp[j]+1;
                        preId[i] = j;
                    }
                }
            }

            if(maxLen < dp[i])
            {
                maxLen = dp[i];
                maxId = i;
            }
        }

        int wId = maxId;
        List<string> res = new();
        while(wId != -1)
        {
            res.Insert(0, words[wId]);
            wId = preId[wId];
        }

        return res;
    }
}
