public class Solution {
    public int FindJudge(int n, int[][] trust) => trust
    .GroupBy(t => t[1])
    .Where(g => g.Count() == n - 1)
    .Select(g => g.Key)
    .Except(trust.Select(t => t[0]))
    .SingleOrDefault(n == 1 ? 1 : -1);
}
