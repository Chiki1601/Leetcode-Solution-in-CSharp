public class Solution {
    public string LastNonEmptyString(string s) 
    {
        int maxFrequ=int.MinValue;
        Dictionary<char,int> map=new Dictionary<char,int>();
        string result="";
        int[] last=new int[26];
     
        for(int i=0;i<s.Length;i++)
        {
            if(map.ContainsKey(s[i]))
            {
                map[s[i]]++;
            }
            else
            {
                map.Add(s[i],1);
            }
            maxFrequ=Math.Max(maxFrequ,map[s[i]]);
            last[s[i]-'a']=i;
        }
        
        for(int i=0;i<s.Length;i++)
        {
            if(map[s[i]]==maxFrequ && i>=last[s[i]-'a'] && !result.Contains(s[i]))
            {
                result+=s[i];
            }
        }
        return result;
    }
}
