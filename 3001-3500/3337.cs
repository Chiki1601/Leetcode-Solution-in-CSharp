public class Solution {
    private const int MOD = 1_000_000_007;
    public int LengthAfterTransformations(string s, int t, IList<int> nums) {
        int[,] transition = new int[26, 26];
        for (int i = 0; i < 26; i++) {
            for (int j = 1; j <= nums[i]; j++) {
                int nextChar = (i + j) % 26;
                transition[i, nextChar]++;
            }
        }
        int[,] resultMatrix = MatrixPower(transition, t);
        int[] finalCounts = new int[26];
        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < 26; j++) {
                finalCounts[i] = (finalCounts[i] + resultMatrix[i, j]) % MOD;
            }
        }
        long total = 0;
        foreach (char ch in s) {
            total = (total + finalCounts[ch - 'a']) % MOD;
        }

        return (int)total;
    }
    private int[,] MatrixPower(int[,] matrix, int power) {
        int[,] result = IdentityMatrix();

        while (power > 0) {
            if ((power & 1) == 1) {
                result = MultiplyMatrices(result, matrix);
            }
            matrix = MultiplyMatrices(matrix, matrix);
            power >>= 1;
        }

        return result;
    }

    private int[,] IdentityMatrix() {
        int[,] identity = new int[26, 26];
        for (int i = 0; i < 26; i++) {
            identity[i, i] = 1;
        }
        return identity;
    }

    private int[,] MultiplyMatrices(int[,] a, int[,] b) {
        int[,] res = new int[26, 26];

        for (int i = 0; i < 26; i++) {
            for (int k = 0; k < 26; k++) {
                for (int j = 0; j < 26; j++) {
                    res[i, j] = (int)((res[i, j] + 1L * a[i, k] * b[k, j]) % MOD);
                }
            }
        }

        return res;
    }
}
