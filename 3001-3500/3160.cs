    public class Solution
    {
        public int[] QueryResults(int limit, int[][] queries)
        {
            var n = queries.Length;
            var results = new int[n];

            var dictBalls = new Dictionary<int, int>();
            var dictColors = new Dictionary<int, int>();

            for (var i = 0; i < queries.Length; i++)
            {
                if (dictBalls.ContainsKey(queries[i][0]))
                {
                    dictColors[dictBalls[queries[i][0]]]--;
                    if (dictColors[dictBalls[queries[i][0]]] == 0)
                    {
                        dictColors.Remove(dictBalls[queries[i][0]]);
                    }

                    dictBalls[queries[i][0]] = queries[i][1];
                }
                else
                {
                    dictBalls.Add(queries[i][0], queries[i][1]);
                }

                if (!dictColors.ContainsKey(queries[i][1]))
                {
                    dictColors.Add(queries[i][1], 0);
                }

                dictColors[queries[i][1]]++;

                results[i] = dictColors.Count;
            }

            return results;
        }
    }
