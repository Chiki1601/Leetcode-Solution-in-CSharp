public class Solution 
{
    public long DistinctNames(string[] ideas) 
    {
        const string ABC = "abcdefghijklmnopqrstuvwxyz";
        var allPairs = ABC.AsEnumerable().Join(ABC, c1 => true, c2 => true, (c1, c2) => (c1, c2));
        
        HashSet<string> hset = ideas.ToHashSet();
        Dictionary<(char, char), int> dict = allPairs.ToDictionary(p => p, p => 0);
        
        foreach ((string s, char c) in ideas.Join(ABC, s => true, c => true, (s, c) => (s, c))) 
            if (!hset.Contains(c + s[1..])) ++dict[(s[0], c)];
        
        return allPairs.Sum(p => (long) dict[p] * dict[(p.c2, p.c1)]);
    }
}
