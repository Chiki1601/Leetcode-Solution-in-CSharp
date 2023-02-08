public class Solution 
{
    public int Jump(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        var lastReach = 0;
        var reach = 0;
        var step = 0;

        for(int i = 0; i<=reach&&i < nums.Length;i++)
        {   
            if(i>lastReach)
            {
                step++;
                lastReach=reach;
            }
            reach=Math.Max(reach, nums[i]+i);
        }

        if (reach<nums.Length-1) return 0;
        return step;
    }
}
