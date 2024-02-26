public class Solution {
    public bool IsPossibleToSplit(int[] nums) {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], 1);
                else
                    map[nums[i]]++;
            }
            if (map.Values.Any(x => x > 2))
                return false;
            return true;
    }
}
