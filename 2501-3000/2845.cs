public class Solution {
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k) {
        var cnt = new Dictionary<int, int> { [0] = 1 };
        long res = 0;
        int prefix = 0;
        foreach (var num in nums) {
            if (num % modulo == k) prefix++;
            int target = (prefix - k + modulo) % modulo;
            if (cnt.TryGetValue(target, out int val)) res += val;
            cnt[prefix % modulo] = cnt.GetValueOrDefault(prefix % modulo, 0) + 1;
        }
        return res;
    }
}
