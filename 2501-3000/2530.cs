public class Solution {
    public long MaxKelements(int[] nums, int k) {
        var pq = new PriorityQueue<long, long>();
        long score = 0;

        // Add numbers in priority queue
        for (var i = 0; i < nums.Length; i++)
            pq.Enqueue((long)nums[i], (long)-1 * nums[i]);
        
        while (k != 0 && pq.Count > 0)
        {
            // Pick max number
            var m = pq.Dequeue();
            score += m;

            // Add number again
            pq.Enqueue((long)Math.Ceiling((decimal)m / 3), -1 * (long)Math.Ceiling((decimal)m / 3));
            k--;
        }
        
        return score;
    }
}
