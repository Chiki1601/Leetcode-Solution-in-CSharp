public class Solution {
   public IList<int> AddToArrayForm(int[] A, int K) {
    var i = A.Length - 1;
    var result = new List<int>();
    while(i >= 0 || K > 0) {
        K += (i >= 0 ? A[i--] : 0);
        result.Add((K % 10));
        K /= 10;
    }
    result.Reverse();
    return result;
}
}
