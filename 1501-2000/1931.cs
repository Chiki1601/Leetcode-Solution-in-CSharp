public class Solution {
    public int ColorTheGrid(int m, int n) {
        const int MOD = 1_000_000_007;
        var states = new List<int>();
        void dfs(int pos, int prev_color, int mask) {
            if (pos == m) {
                states.Add(mask);
                return;
            }
            for (int color = 0; color < 3; color++) {
                if (color != prev_color) {
                    dfs(pos + 1, color, mask * 3 + color);
                }
            }
        }
        dfs(0, -1, 0);
        int S = states.Count;
        var compat = new List<int>[S];
        for (int i = 0; i < S; i++) compat[i] = new List<int>();
        for (int i = 0; i < S; i++) {
            for (int j = 0; j < S; j++) {
                int x = states[i], y = states[j];
                bool ok = true;
                for (int k = 0; k < m; k++) {
                    if (x % 3 == y % 3) { ok = false; break; }
                    x /= 3; y /= 3;
                }
                if (ok) compat[i].Add(j);
            }
        }
        var dp = Enumerable.Repeat(1, S).ToArray();
        var new_dp = new int[S];
        for (int t = 0; t < n - 1; t++) {
            Array.Clear(new_dp, 0, S);
            for (int i = 0; i < S; i++) {
                int di = dp[i];
                if (di != 0) {
                    foreach (int j in compat[i]) {
                        new_dp[j] = (new_dp[j] + di) % MOD;
                    }
                }
            }
            var tmp = dp; dp = new_dp; new_dp = tmp;
        }
        long ans = 0;
        foreach (int v in dp) ans = (ans + v) % MOD;
        return (int)ans;
    }
}
