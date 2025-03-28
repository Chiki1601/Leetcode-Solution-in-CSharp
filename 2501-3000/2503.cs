public class Solution {
    public int[] MaxPoints(int[][] grid, int[] queries) {
        int rows = grid.Length, cols = grid[0].Length;
        int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

        int[] result = new int[queries.Length];
        var sortedQueries = queries
            .Select((val, idx) => new Tuple<int, int>(val, idx))
            .OrderBy(q => q.Item1)
            .ToList();

        var minHeap = new SortedSet<(int val, int row, int col)>(Comparer<(int, int, int)>.Create((a, b) => a.Item1 == b.Item1 ? (a.Item2 == b.Item2 ? a.Item3 - b.Item3 : a.Item2 - b.Item2) : a.Item1 - b.Item1));
        bool[,] visited = new bool[rows, cols];

        minHeap.Add((grid[0][0], 0, 0));
        visited[0, 0] = true;
        int points = 0;

        foreach (var (queryVal, queryIdx) in sortedQueries) {
            while (minHeap.Count > 0 && minHeap.Min.val < queryVal) {
                var (val, row, col) = minHeap.Min;
                minHeap.Remove(minHeap.Min);
                points++;

                foreach (var dir in directions) {
                    int nr = row + dir[0], nc = col + dir[1];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && !visited[nr, nc]) {
                        minHeap.Add((grid[nr][nc], nr, nc));
                        visited[nr, nc] = true;
                    }
                }
            }
            result[queryIdx] = points;
        }

        return result;
    }
}
