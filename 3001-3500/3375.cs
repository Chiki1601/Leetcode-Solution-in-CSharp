public class Solution {
    public int MinOperations(int[] nums, int k) {
        bool[] used=new bool[101];
        int distinct=0;
        for(int i=0; i<nums.Length; i++) {
            int n=nums[i];
            if(n<k) return -1;
            if(n>k && !used[n]) { used[n]=true; distinct++; }
        }
        return distinct;
    }
}
