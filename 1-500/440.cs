public class Solution {
    public int FindKthNumber(int n, int k) {
        int current = 1;
        k--;

        while (k > 0) {
            int steps = CountSteps(n, current, current + 1);
            if (steps <= k) {
                k -= steps;
                current++;
            } else {
                k--;
                current *= 10;
            }
        }

        return current;
    }

    private int CountSteps(int n, long curr, long next) {
        int steps = 0;
        while (curr <= n) {
            steps += (int)(Math.Min(n + 1, next) - curr);
            curr *= 10;
            next *= 10;
        }
        return steps;
    }
}
