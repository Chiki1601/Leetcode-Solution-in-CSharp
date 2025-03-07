public class Solution {
    public int[] ClosestPrimes(int left, int right) {
        bool[] sieve = new bool[right + 1];
        Array.Fill(sieve, true);
        sieve[0] = sieve[1] = false;
        
        for (int i = 2; i * i <= right; i++) {
            if (sieve[i]) {
                for (int j = i * i; j <= right; j += i) {
                    sieve[j] = false;
                }
            }
        }
        
        List<int> primes = new List<int>();
        for (int i = left; i <= right; i++) {
            if (sieve[i]) {
                primes.Add(i);
            }
        }
        
        if (primes.Count < 2) {
            return new int[] { -1, -1 };
        }
        
        int minGap = int.MaxValue;
        int[] result = new int[2] { -1, -1 };
        
        for (int i = 1; i < primes.Count; i++) {
            int gap = primes[i] - primes[i - 1];
            if (gap < minGap) {
                minGap = gap;
                result[0] = primes[i - 1];
                result[1] = primes[i];
            }
        }
        
        return result;
    }
}
