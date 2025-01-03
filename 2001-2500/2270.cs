public class Solution {
    public int WaysToSplitArray(int[] nums) {
        long leftSideSum = 0, rightSideSum = 0;
        foreach (int num in nums) {
            rightSideSum += num;
        }

        int validSplits = 0;
        for (int i = 0; i < nums.Length - 1; i++) {
            leftSideSum += nums[i];
            rightSideSum -= nums[i];
            if (leftSideSum >= rightSideSum) {
                validSplits++;
            }
        }

        return validSplits;
    }
}
