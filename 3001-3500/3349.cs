public class Solution {
    public bool HasIncreasingSubarrays(IList<int> nums, int k) {
        int n = nums.Count, inc = 1, prevInc = 0, maxLen = 0;
        for (int i = 1; i < n; i++) {
            if (nums[i] > nums[i - 1]) inc++;
            else {
                prevInc = inc;
                inc = 1;
            }
            maxLen = Math.Max(maxLen, Math.Max(inc >> 1, Math.Min(prevInc, inc)));
            if (maxLen >= k) return true;
        }
        return false;
    }
}
