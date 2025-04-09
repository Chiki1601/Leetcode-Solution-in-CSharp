public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int ans = 0;
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < k)
                return -1;
            if (nums[i] == k || (i != 0 && nums[i] == nums[i - 1]))
                continue;
            ans++;
        }
        return ans;
    }
}
