public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        long[] prefixes = new long[nums.Length + 1];
        long ans = 0;
        int left = 0;
        prefixes[0] = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            prefixes[right + 1] = prefixes[right] + nums[right];
            while (
                left <= right && (prefixes[right + 1] - prefixes[left]) * (right - left + 1) >= k
            )
            {
                left++;
            }

            ans += right - left + 1;
        }
        return ans;
    }
}
