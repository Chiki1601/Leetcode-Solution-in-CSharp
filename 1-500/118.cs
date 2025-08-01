public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var result = new List<IList<int>>();
        
        if (numRows == 0) {
            return result;
        }

        result.Add(new List<int> { 1 });
        
        for (int i = 1; i < numRows; i++) {
            var oldRow = result[i - 1];
            var currentRow = new List<int> { 1 };
            
            for (int j = 1; j < i; j++) {
                currentRow.Add(oldRow[j - 1] + oldRow[j]);
            }
            
            currentRow.Add(1);
            result.Add(currentRow);
        }
        
        return result;
    }
}
