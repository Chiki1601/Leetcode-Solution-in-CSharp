public class Solution {
    public bool CheckIfPangram(string sentence) {
        HashSet<char> set = new HashSet<char>();
        
        foreach(char s in sentence){
            set.Add(s);    
        }
        
        return set.Count == 26;
    }
}
