public class Solution {
    public int XorAllNums(int[] nums1, int[] nums2) {
        int c1 = nums1.Length;
        int c2 = nums2.Length;
        int x1 = 0, x2 = 0;

        if (c1 % 2 != 0) {
            foreach (int num in nums2) {
                x2 ^= num;
            }
        }
        if (c2 % 2 != 0) {
            foreach (int num in nums1) {
                x1 ^= num;
            }
        }
        return x1 ^ x2;
    }
}
