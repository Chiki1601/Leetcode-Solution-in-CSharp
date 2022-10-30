public class Solution {
    public long SumOfDigits(long n)
    {
      long sum = 0;
      while(n > 0)
      {
        sum += (n % 10);
        n /= 10;
      }
      return sum;
    }
    public long MakeIntegerBeautiful(long n, int target) {
        long mul = 1;
        long add = 0;
        while(SumOfDigits(n + add) > target)
        {
          mul = mul * 10;
          add = mul - n % mul;
        }
        return add;
    }
}
