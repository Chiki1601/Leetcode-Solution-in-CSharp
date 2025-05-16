public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        int curGroup = -1;
        var ans = new List<string>();
        for (int i = 0; i < words.Length; i ++) {
            if (curGroup != groups[i]) {
                ans.Add(words[i]);
                curGroup = groups[i];
            }
        }
        return ans;
    }
}
