public class Solution {
    public string GcdOfStrings(string s, string t) => Enumerable
    // generate lengths from 1 to the length of the shortest string
    .Range(1, Math.Min(s.Length, t.Length))
    // we are only interested in lengths up to the longest common prefix
    .TakeWhile(l => s[l - 1] == t[l - 1])
    // trim the list to only include lengths that are evenly divisible by both strings
    .Where(l => s.Length % l == 0 && t.Length % l == 0)
    // check the longest lengths first
    .Reverse()
    // repeat the prefix of length l for the length of s and ensure matches
    .Where(l => Enumerable.Range(0, s.Length).All(i => s[i % l] == s[i]))
    // repeat the prefix of length l for the length of t and ensure matches
    .Where(l => Enumerable.Range(0, t.Length).All(i => t[i % l] == t[i]))
    // slice off the prefix    
    .Select(l => s[..l])
    // return the first (longest) prefix or the empty string
    .FirstOrDefault("");
}
