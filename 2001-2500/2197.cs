public class Solution {
    public IList<int> ReplaceNonCoprimes(int[] nums) {
        var stack = new List<int>();
        
        foreach (int num0 in nums) {
            int num = num0;
            while (stack.Count > 0) {
                int top = stack[stack.Count - 1];
                int g = Gcd(top, num);
                if (g == 1) {
                    break;
                }
                stack.RemoveAt(stack.Count - 1);
                // LCM merge
                num = (top / g) * num;
            }
            stack.Add(num);
        }
        
        return stack;
    }
    
    private int Gcd(int a, int b) {
        while (b != 0) {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}
