public class Solution
{
    public char KthCharacter(long k, int[] operations)
    {
        int bitIndex = 0;
        int step = 0;
        while (k > 1L << bitIndex)
        {
            bitIndex++;
        }
        while (k > 1)
        {
            long bit = 1L << bitIndex;
            if (k > bit)
            {
                k -= bit;
                step += operations[bitIndex];
            }
            bitIndex--;
        }
        return (char)(97 + (step % 26));
    }
}
