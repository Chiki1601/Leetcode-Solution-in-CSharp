public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int[] counts = [0, 0, 0];
        var result = 0;
        var i = 0;

        foreach (var c in s)
        {
            ++counts[c - 'a'];

            while (counts[0] > 0 && counts[1] > 0 && counts[2] > 0)
            {
                --counts[s[i++] - 'a'];
            }

            result += i;
        }

        return result;
    }
}
