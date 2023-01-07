public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var n = gas.Length;
        var totalSum = 0;
        var rangeSum = 0;

        var candidate = 0;

        for (int i = 0; i < n; i++) {
            var diff = gas[i] - cost[i];
            totalSum += diff;
            rangeSum += diff;

            if (rangeSum < 0) {
                candidate = i + 1;
                rangeSum = 0;
            }
        }

        if (totalSum < 0) return -1;

        return candidate;
    }
}
