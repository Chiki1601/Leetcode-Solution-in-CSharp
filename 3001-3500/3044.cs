public class Solution {
    public int MostFrequentPrime(int[][] mat) 
    {
        int rows = mat.Length;
        int cols = mat[0].Length;
        List<int> nums = [];
        
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                // 8 directions
                (int dx, int dy)[] moves = [(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1)];

                // Start finding numbers for each direction
                foreach(var (dx, dy) in moves)
                {
                    int x = i;
                    int y = j;
                    int num = mat[x][y];

                    // Keep moving till we are not out of bounds
                    while(!IsOutsideGrid(x+dx, y+dy))
                    {
                        num = num*10 + mat[x+dx][y+dy];
                        x = x+dx;
                        y = y+dy;
                        
                        // Check if we can add as per our requirement
                        if(IsPrimeAndGreaterThanTen(num))
                            nums.Add(num);
                    }
                }
            }
        }
        
        // No prime number found
        if(nums.Count == 0)
            return -1;
        
        nums.Sort(new DescendingComparer());

        return MostFrequent(nums);
        
        // Local functions
        bool IsOutsideGrid(int r, int c) => (r < 0 || r >= rows) || (c < 0 || c >= cols);
    }
    
    // Prime number check
    bool IsPrimeAndGreaterThanTen(int num)
    {
        if(num < 10)
            return false;
        
        for(int i = 2; i*i <= num; i++)
        {
            if(num % i == 0)
                return false;
        }
        return true;
    }

    // Finding the most frequent number of the list sorted in desecending order
    int MostFrequent(List<int> nums)
    {
        int freq = 1;
        int max = 1;
        int mostFreq = nums[0];
        
        for(int i = 1; i < nums.Count; i++)
        {
            if(nums[i] == nums[i-1])
                freq++;
            else
                freq = 1;
            
            if(freq > max)
            {
                max = freq;
                mostFreq = nums[i];
            }
        }
        return mostFreq;
    }
    
    // Custom comparer for descending sort
    public class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}
