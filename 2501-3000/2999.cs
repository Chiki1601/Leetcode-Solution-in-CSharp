public class Solution {
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s) {
        string startStr = (start - 1).ToString();
        string finishStr = finish.ToString();
        return Calculate(finishStr, s, limit) - Calculate(startStr, s, limit);
    }
    private long Calculate(string x, string s, int limit) {
        if (x.Length < s.Length)
            return 0;

        if (x.Length == s.Length)
            return String.Compare(x, s) >= 0 ? 1 : 0;

        // Ensure all digits in suffix s are <= limit
        foreach (char c in s) {
            if (c - '0' > limit)
                return 0;
        }

        long count = 0;
        int prefixLen = x.Length - s.Length;
        bool tight = true;

        for (int i = 0; i < prefixLen; i++) {
            int maxDigit = tight ? (x[i] - '0') : limit;

            for (int d = 0; d < maxDigit && d <= limit; d++) {
                count += (long)Math.Pow(limit + 1, prefixLen - 1 - i);
            }

            if ((x[i] - '0') > limit)
                return count;

            if ((x[i] - '0') < maxDigit)
                tight = false;
        }

        string candidate = x.Substring(0, prefixLen) + s;
        if (String.Compare(candidate, x) <= 0) {
            count++;
        }

        return count;
    }
}
