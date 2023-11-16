public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        int length = nums.Length;
        StringBuilder number = new StringBuilder();
        for (int i = 0; i < length; i++) {
            number.Append(nums[i][i] == '1' ? '0' : '1');
        }
        return number.ToString();
    }
}
