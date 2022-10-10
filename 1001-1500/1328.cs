public class Solution {
    public string BreakPalindrome(string palindrome) {
        int length = palindrome.Length;
        
        if (length < 2) {
            return "";
        }
        
        int end = (length / 2) - 1;
        for (int i = 0; i <= end; i++) {
            if (palindrome[i] != 'a') {
                return palindrome.Substring(0, i) + "a" + palindrome.Substring(i+1);
            }
        }
        
        //all A's
        return palindrome.Substring(0, length - 1) + "b";
    }
}
