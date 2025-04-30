public class Solution {
    public int FindNumbers(int[] nums) {
         return nums.Count(num => num.ToString().Length % 2 == 0);
    }
}
