public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        int n = grid.Length * grid.Length;
int sum = (1 + n) * n / 2;

int a = -1;
var counts = new int[n];
foreach (var arr in grid)
{
    foreach (var num in arr)
    {
        counts[num - 1]++;

        if (counts[num - 1] == 2)
        {
            a = num;
        }
        else
        {
            sum -= num;
        }
    }
}
return new int[] { a, sum };
    }
}
