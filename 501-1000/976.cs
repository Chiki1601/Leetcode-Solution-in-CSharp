public class Solution {
    public int LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length;
        
        for(int i = n - 1; i >= 2; i--)
            if(nums[i] < nums[i - 1] + nums[i - 2])
                return nums[i] + nums[i - 1] + nums[i - 2];
        
        return 0;
    }
}
