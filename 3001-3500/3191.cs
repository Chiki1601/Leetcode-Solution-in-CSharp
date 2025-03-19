public class Solution {
    public int MinOperations(int[] nums) {
        int count = 0;
        int n = nums.Length;
        for (int i = 0; i < n - 2; i++) {
            if (nums[i] == 0) {
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;

                count++;
            } 
        }

        return (nums[n - 2] & nums[n - 1]) == 1 ? count : -1;
    }
}
