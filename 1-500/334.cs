public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int len = nums.Length;
        if(len < 3)
            return false;
        
        int[] dp = new int[len];
        int count = 0;
        
        for(int i = 0; i < len; i++)
        {
            int idx = Array.BinarySearch(dp, 0, count, nums[i]);
            if(idx < 0)
                idx = ~idx;
            dp[idx] = nums[i];
            if(idx == count)
                ++count;
            if(count >= 3)
                return true;
        }
        
        return count >= 3;
    }
}
