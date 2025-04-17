public class Solution {
  public int CountPairs(int[] nums, int k) =>
    Enumerable.Range(0, nums.Length)
        .Sum(i => Enumerable.Range(i + 1, nums.Length - i - 1)
            .Count(j => nums[i] == nums[j] && (i * j) % k == 0));
}
