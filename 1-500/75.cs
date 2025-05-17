public class Solution
{
    public void SortColors(Span<int> nums)
    {
        var red = nums.Count(0);
        var white = nums.Count(1);
        var blue = nums.Count(2);

        nums.Slice(0, red).Fill(0);
        nums.Slice(red, white).Fill(1);
        nums.Slice(red + white).Fill(2);
    }
}
