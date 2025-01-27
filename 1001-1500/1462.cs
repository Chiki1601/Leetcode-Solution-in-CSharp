public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        bool[,] relation = new bool[numCourses, numCourses];
        var ans = new List<bool>();

        // Fill direct prerequisites
        foreach (var d in prerequisites) {
            relation[d[0], d[1]] = true;
        }

        // Perform transitive closure using Floyd-Warshall-like logic
        for (int i = 0; i < numCourses; i++) {
            for (int src = 0; src < numCourses; src++) {
                for (int target = 0; target < numCourses; target++) {
                    relation[src, target] = relation[src, target] || (relation[src, i] && relation[i, target]);
                }
            }
        }

        // Answer the queries
        foreach (var d in queries) {
            ans.Add(relation[d[0], d[1]]);
        }

        return ans;
    }
}
