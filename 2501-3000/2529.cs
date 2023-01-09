public class Solution 
{
    public int MaximumCount(int[] nums)
    {
        return Math.Max(nums.Count(n => n < 0), nums.Count(n => n > 0));
    }
}
