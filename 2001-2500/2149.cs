public class Solution {
    public int[] RearrangeArray(int[] nums) {
        
        if(nums == null || nums.Length < 2)
            throw new ArgumentException("Invaid Inupt");
        
        int[] res = new int[nums.Length];
        int evenPointer = 0, oddPointer = 1;
        foreach(var num in nums)
        {
            if(num > 0)
            {
                res[evenPointer] = num;
                evenPointer += 2;
            }
            else
            {
                res[oddPointer] = num;
                oddPointer += 2;
            }
        }
        
        return res;
    }
}
