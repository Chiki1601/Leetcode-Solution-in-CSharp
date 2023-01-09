public class Solution 
{
    public bool IsItPossible(string word1, string word2) 
    {
        Dictionary<char, int> word1Freq = new Dictionary<char, int>();
        Dictionary<char, int> word2Freq = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            word1Freq.TryAdd(c, 0);
            word1Freq[c]++;
        }
        foreach (char c in word2)
        {
            word2Freq.TryAdd(c, 0);
            word2Freq[c]++;
        }

        int word1UniqueCharsCount = word1Freq.Count;
        int word2UniqueCharsCount= word2Freq.Count;
        foreach  (var kv1 in word1Freq)
        {
            foreach (var kv2 in word2Freq)
            {
                int word1UniqueCharsCountCurrent = word1UniqueCharsCount;
                int word2UniqueCharsCountCurrent = word2UniqueCharsCount;

                if (kv1.Key != kv2.Key)
                {
                    if (kv1.Value == 1)
                        word1UniqueCharsCountCurrent--;
                    if (kv2.Value == 1)
                        word2UniqueCharsCountCurrent--;

                    if (!word2Freq.ContainsKey(kv1.Key))
                        word2UniqueCharsCountCurrent++;
                    if (!word1Freq.ContainsKey(kv2.Key))
                        word1UniqueCharsCountCurrent++;
                }

                if (word1UniqueCharsCountCurrent == word2UniqueCharsCountCurrent)
                    return true;
            }
        }
        return false;
    }
}
