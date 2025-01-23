public class Solution {
    public int CountServers(int[][] grid) {
        int[] Rows = new int[grid.Length];
        int[] Col = new int[grid[0].Length];
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                Rows[i] += grid[i][j];
                Col[j] += grid[i][j];
            }
        }
        int ans = 0;
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == 1 && (Rows[i] > 1 || Col[j] > 1)) {
                    ans++;
                }
            }
        }
        return ans;
    }
}
