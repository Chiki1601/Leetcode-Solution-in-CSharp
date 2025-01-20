public class Solution {
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
        int rows = mat.Length, cols = mat[0].Length;
        var positionMap = new Dictionary<int, (int, int)>();
        int[] rowCount = new int[rows];
        int[] colCount = new int[cols];
        Array.Fill(rowCount, cols);
        Array.Fill(colCount, rows);
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                positionMap[mat[r][c]] = (r, c);
            }
        }
        for (int idx = 0; idx < arr.Length; idx++) {
            var (row, col) = positionMap[arr[idx]];
            if (--rowCount[row] == 0 || --colCount[col] == 0) {
                return idx;
            }
        }
        return -1;
    }
}
