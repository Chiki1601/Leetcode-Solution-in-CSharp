public class Solution
{
  public int MaxOperations(int[] a)
  {
    var n = a.Length;
    var dp = new int[n][];
    for (var i = 0; i < n; i++)
    {
      dp[i] = new int[n];
      Array.Fill(dp[i], -1);
    }
    var score1 = F(2, n - 1, a[0] + a[1]);
    var score2 = F(0, n - 3, a[^2] + a[^1]);
    var score3 = F(1, n - 2, a[0] + a[^1]);
    return Math.Max(score1, Math.Max(score2, score3)) + 1;

    int F(int l, int r, int score)
    {
      if (l >= r)
        return 0;
      var result = dp[l][r];
      if (result != -1)
        return result;
      result = 0;
      if (a[l] + a[l + 1] == score)
        result = F(l + 2, r, score) + 1;
      if (a[r - 1] + a[r] == score)
        result = Math.Max(result, F(l, r - 2, score) + 1);
      if (a[l] + a[r] == score)
        result = Math.Max(result, F(l + 1, r - 1, score) + 1);
      dp[l][r] = result;
      return result;
    }
  }
}
