public class Solution {
    public string ClearDigits(string s) {
         if (s.Length < 2) return s;
 for (int i = 1; i < s.Length; i++)
 {
     if (Char.IsDigit(s[i]))
     {
         s = s.Remove(i - 1, 2);
         return ClearDigits(s);
     }
 }
 return s;
    }
}
