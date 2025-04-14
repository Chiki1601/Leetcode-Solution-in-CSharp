public class Solution {
   public int CountGoodTriplets(int[] arr, int a, int b, int c) =>
    Enumerable.Range(0, arr.Length - 2).Sum(i =>
    Enumerable.Range(i + 1, arr.Length - 2 - i).Sum(j =>
    Enumerable.Range(j + 1, arr.Length - 1 - j).Count(k =>
        Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)));
}
