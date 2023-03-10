public class Solution {

    private Random random;
    private ListNode head;
    
    public Solution(ListNode head) {
    
        random = new Random();
        this.head = head;
    }
    
    public int GetRandom() {
        
        int cnt = 0, res = -1;
        ListNode curr = head;
        while(curr != null)
        {
            cnt++;
            if(random.Next(0,cnt) == 0)
                res = curr.val;
            
            curr = curr.next;
        }
        
        return res;
    }
}
