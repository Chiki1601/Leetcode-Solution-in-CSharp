public class Solution {
   	public int TotalFruit(int[] tree) {
        if(tree.Length == 0) return 0;
        int fruit1 = tree[0];
        int fruit2 = -1;
        int res = 1;
        int cur = 1;
        int start = 0;
        for(int i = 1; i < tree.Length; i++) {
            if(tree[i] == fruit1 || tree[i] == fruit2) cur++;
            else {
                res = Math.Max(res, cur);
                fruit1 = tree[i - 1];
                fruit2 = tree[i];
                cur = i - start + 1;
            }
            if(tree[i] != tree[i - 1]) start = i;
        }
        return Math.Max(res, cur);
    }
}
