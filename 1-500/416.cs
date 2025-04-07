public class Solution {
    private bool memo(int[] nums, int[, ] dp, int sum, int idx) {
        if (sum == 0)
            return true;
        
        if (idx >= nums.Length)
            return false;
        
        if (dp[idx, sum] != -1)
            return dp[idx, sum] == 1 ? true : false;

        bool pick = false, no_pick = false;

        if (nums[idx] <= sum)
            pick = memo(nums, dp, sum - nums[idx], idx + 1);
        
        no_pick = memo(nums, dp, sum, idx + 1);

        dp[idx, sum] = (pick || no_pick) ? 1 : 0;
        return dp[idx, sum] == 1 ? true : false;

    }
    public bool CanPartition(int[] nums) {
        int n = nums.Length, sum = 0;
        foreach (var num in nums)
            sum += num;
        if ((sum & 1) != 0)
            return false;

        int[, ] dp = new int[n, (sum >> 1) + 1];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < ((sum >> 1) + 1); j++)
                dp[i, j] = -1;
        
        return memo(nums, dp, sum >> 1, 0);
    }
}
