using System;

public class Solution
{
    private int[] cnt = new int[10];
    private int mod = (int)1e9 + 7;
    private int?[,,,] dp;
    private long[,] C;

    public int CountBalancedPermutations(string num)
    {
        int totalSum = 0;
        foreach (char ch in num)
        {
            int digit = ch - '0';
            cnt[digit]++;
            totalSum += digit;
        }

        if (totalSum % 2 != 0)
            return 0;

        int n = num.Length;
        int halfSum = totalSum / 2;
        int half1 = n / 2;
        int half2 = (n + 1) / 2;

        dp = new int?[10, halfSum + 1, half1 + 1, half2 + 1];
        PrecomputeCombinations(Math.Max(half1, half2));
        return DFS(0, halfSum, half1, half2);
    }

    private void PrecomputeCombinations(int max)
    {
        C = new long[max + 1, max + 1];
        for (int i = 0; i <= max; i++)
        {
            C[i, 0] = 1;
            for (int j = 1; j <= i; j++)
            {
                C[i, j] = (C[i - 1, j] + C[i - 1, j - 1]) % mod;
            }
        }
    }

    private int DFS(int digit, int sumLeft, int leftCount, int rightCount)
    {
        if (digit == 10)
            return (sumLeft == 0 && leftCount == 0 && rightCount == 0) ? 1 : 0;

        if (leftCount == 0 && sumLeft != 0)
            return 0;

        if (dp[digit, sumLeft, leftCount, rightCount].HasValue)
            return dp[digit, sumLeft, leftCount, rightCount].Value;

        int result = 0;
        for (int l = 0; l <= Math.Min(cnt[digit], leftCount); l++)
        {
            int r = cnt[digit] - l;
            if (r <= rightCount && l * digit <= sumLeft)
            {
                long ways = (C[leftCount, l] * C[rightCount, r]) % mod;
                int res = DFS(digit + 1, sumLeft - l * digit, leftCount - l, rightCount - r);
                result = (int)((result + ways * res) % mod);
            }
        }

        dp[digit, sumLeft, leftCount, rightCount] = result;
        return result;
    }
}
