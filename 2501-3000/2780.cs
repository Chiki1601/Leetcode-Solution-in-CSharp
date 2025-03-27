public class Solution {
    public int MinimumIndex(IList<int> nums) {
        int FindDominantElement(IList<int> arr) {
            int candidate = -1, count = 0;

            // Boyer-Moore Majority Vote algorithm
            foreach (int num in arr) {
                if (count == 0) {
                    candidate = num;
                    count = 1;
                } else if (num == candidate) {
                    count++;
                } else {
                    count--;
                }
            }

            int totalCount = arr.Count(num => num == candidate);
            return totalCount > arr.Count / 2 ? candidate : -1;
        }

        int dominant = FindDominantElement(nums);
        if (dominant == -1) return -1;

        int leftCount = 0, totalDominantCount = nums.Count(num => num == dominant);

        for (int i = 0; i < nums.Count - 1; i++) {
            if (nums[i] == dominant) {
                leftCount++;
            }

            int leftSubarrayCount = leftCount;
            int rightSubarrayCount = totalDominantCount - leftCount;

            if (leftSubarrayCount > (i + 1) / 2 &&
                rightSubarrayCount > (nums.Count - i - 1) / 2) {
                return i;
            }
        }

        return -1;
    }
}
