public class Solution {
    public long CountGood(int[] nums, int k) {
        long l = 0, r = 0, count = 0, ans = 0;
        var map = new Dictionary<int, int>();
        while (r < nums.Length) {
            if (!map.ContainsKey(nums[r])) map[nums[r]] = 0;
            count += map[nums[r]];
            map[nums[r]]++;
            while (l < nums.Length && count - (map[nums[l]] - 1) >= k) {
                map[nums[l]]--;
                count -= map[nums[l]];
                l++;
            }
            if (count >= k) ans += l + 1;
            r++;
        }
        return ans;
    }
}
