public class Solution 
{
    enum Marking
    {
        Unvisited = 0,
        Temporary = 1,
        Visited = 2
    }    
    
    public IList<int> EventualSafeNodes(int[][] graph) 
    {
        Marking[] markings = new Marking[graph.Length];
        List<int> result = new List<int>();
        
        for(int i = 0; i < graph.Length; i++)
        {
            if(!detectCycle(graph, i, markings))
            {
                result.Add(i);        
            }
        }
        
        return result;
    }
    
    private bool detectCycle(int[][] graph, int node, Marking[] markings)
    {
        if(markings[node] == Marking.Temporary)
        {
            return true;
        }
        
        if(markings[node] == Marking.Visited)
        {
            return false;
        }
        
        markings[node] = Marking.Temporary;
        
        foreach(int neighbour in graph[node])
        {   
            if(detectCycle(graph, neighbour, markings))
            {
                return true;
            }            
        }       
        
        markings[node] = Marking.Visited;
        return false;        
    }
}
