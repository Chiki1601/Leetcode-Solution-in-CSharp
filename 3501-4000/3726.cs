public class Solution {
    public long RemoveZeros(long n) {
        long res = 0, mult = 1;
        while (n > 0) {
            long rem = n % 10;
            if (rem != 0) {
                res += rem * mult;
                mult *= 10;
            }
            n /= 10;
        }
        return res;
    }
}
