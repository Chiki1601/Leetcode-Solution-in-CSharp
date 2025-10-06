public class Solution {
    public int LongestSubsequence(int[] nums) {
        int xorSum = 0;
        bool allZero = true;
        foreach (int num in nums) {
            xorSum ^= num;
            if (num != 0) allZero = false;
        }
        if (allZero) return 0;
        return xorSum != 0 ? nums.Length : nums.Length - 1;
    }
}
