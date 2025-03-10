class Solution {
    public int MinimumRecolors(string blocks, int k) {
        int blackCount = 0, ans = int.MaxValue;
    
        for (int i = 0; i < blocks.Length; i++) {
            if (i - k >= 0 && blocks[i - k] == 'B') blackCount--;
            if (blocks[i] == 'B') blackCount++;
            ans = Math.Min(ans, k - blackCount);
        }
        
        return ans;
    }
}
