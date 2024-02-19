public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        var trie = new Trie();
        var longestArrayInts = arr1.Length >= arr2.Length ? arr1 : arr2;
        var shortestArrayInts = arr1.Length >= arr2.Length ? arr2 : arr1;
        var longestArrayStrings = longestArrayInts.Select(x => x.ToString()).ToArray();
        trie.BuildTree(longestArrayStrings);
        
        var longestPrefix = 0;
        foreach(var i in shortestArrayInts){
            var prefixLength = trie.FindMaxLength(i.ToString());
            if(longestPrefix < prefixLength){
                longestPrefix = prefixLength;
            }
        }
        return longestPrefix;
    }
    
    private class Trie{
        TrieNode[] _roots = new TrieNode[10];
        
        public Trie(){}
        
        public void BuildTree(string[] strs){
            foreach(var s in strs){
                
                if(_roots[s[0]-'0'] == null){
                    _roots[s[0]-'0'] = new TrieNode(){Value = s[0], Children = new TrieNode[10]};
                }
                var current = _roots[s[0]-'0'];
                for(int i = 1; i < s.Length; i++){
                    if(current.Children[s[i]-'0'] == null){
                        current.Children[s[i]-'0'] = new TrieNode(){Value = s[i], Children = new TrieNode[10]};
                    }
                    current = current.Children[s[i]-'0'];
                }
            }
        }
        
        public int FindMaxLength(string str){
            if(_roots[str[0]-'0'] == null){
                return 0;
            }
            var current = _roots[str[0]-'0'];
            for(int i =1; i < str.Length; i++){
                if(current.Children[str[i]-'0'] != null){
                    current = current.Children[str[i]-'0'];
                    continue;
                }
                return i;
            }
            return str.Length;
        }
    }
    
    private class TrieNode{
        public char Value {get;set;}
        public TrieNode[] Children {get;set;}
    }
}
