public class Solution {
    public int NumberOfBeams(string[] bank) {
        int totalBeams = 0;
        int prevDeviceCount = 0;
        
        // Iterate through each row of the bank
        foreach (string row in bank) {
            int currentDeviceCount = 0;
            
            // Count security devices ('1's) in current row
            foreach (char cell in row) {
                currentDeviceCount += cell & 1;  // Bit trick: '1' & 1 = 1, '0' & 1 = 0
            }
            
            // If current row has devices, calculate beams with previous row
            if (currentDeviceCount > 0) {
                totalBeams += prevDeviceCount * currentDeviceCount;
                prevDeviceCount = currentDeviceCount;
            }
        }
        
        return totalBeams;
    }
}
