public class Solution {

    public static bool CanDo(int[] data, int r, long avail, long min) {
        long[] stations = new long[data.Length + r];

        for (int i = 0; i < data.Length; ++i)
            stations[i] = data[i];

        long total = 0;

        for (int i = 0; i < stations.Length; ++i) {
            total += stations[i];

            if (i < r)
                continue;

            if (i >= 2 * r + 1)
                total -= stations[i - (2 * r + 1)];

            if (total >= min)
                continue;   

            long delta = (min - total);

            stations[i] += delta;
            avail -= delta;
            total = min;

            if (avail < 0)
                return false;      
        }

        if (total < min) 
            avail -= (min - total);

        return avail >= 0;
    }

    public long MaxPower(int[] stations, int r, int k) {
        long ever = stations.Min();
        long never = stations.Sum(x => (long) x) + k + 1;

        while (never - ever > 1) {
            long middle = (never + ever) / 2;

            if (CanDo(stations, r, k, middle))
                ever = middle;
            else 
                never = middle;
        }    

        return ever;
    }
}
