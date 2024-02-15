public class Solution {
    public long LargestPerimeter(int[] nums) {
        Array.Sort(nums);

        long total = 0;
        long result = -1;
        
        for (int i = 0; i < nums.Length; ++i) 
            if (nums[i] < (total += nums[i]) - nums[i] && i >= 2)
                result = total;

        return result;
    }
}
