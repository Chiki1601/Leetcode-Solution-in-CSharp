public class Solution {
    public bool DoesAliceWin(string s) {
        foreach (char c in s) {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                return true;
        }
        return false;
    }
}
