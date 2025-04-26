public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        long res = 0;
        int bad = -1, left = -1, right = -1;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] < minK || nums[i] > maxK) bad = i;
            if (nums[i] == minK) left = i;
            if (nums[i] == maxK) right = i;
            res += Math.Max(0, Math.Min(left, right) - bad);
        }

        return res;
    }
}
