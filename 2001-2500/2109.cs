public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        char[] result = new char[s.Length + spaces.Length];
        int writePos = 0;
        int readPos = 0;
        
        foreach (int spacePos in spaces) {
            while (readPos < spacePos) {
                result[writePos++] = s[readPos++];
            }
            result[writePos++] = ' ';
        }
        
        while (readPos < s.Length) {
            result[writePos++] = s[readPos++];
        }
        
        return new string(result);
    }
}
