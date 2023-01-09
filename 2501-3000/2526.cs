public class DataStream {
    int prev = 0;
    int val = 0;
    int len = 0;
    int K;

    public DataStream(int value, int k) {
        prev = value;
        val = value;
        K = k;
    }
    
    public bool Consec(int num) {
        if(prev == num && val == num)
        {
            ++len;
            if(len >= K)
                return true;
        }
        else
        {
            len = 1;
            prev = num;
            if(len >= K && val == num)
                return true;
        }
        return false;
    }
}

/**
 * Your DataStream object will be instantiated and called as such:
 * DataStream obj = new DataStream(value, k);
 * bool param_1 = obj.Consec(num);
 */
