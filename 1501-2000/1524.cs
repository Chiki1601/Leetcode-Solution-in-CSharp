public class Solution
{
    public int NumOfSubarrays(int[] arr)
    {
        var sum = 0L;
        var odd = arr.Sum(n => (sum += n) % 2);
        var res = odd * (arr.Length - odd + 1);
        return (int)(res % 1_000_000_007);
    }
}
