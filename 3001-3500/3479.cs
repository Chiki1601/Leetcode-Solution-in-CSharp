public class Solution {
    /*
       2 4 5
       3 4 5
    */
    int [] st;
    void update(int id,int l,int r,int u, int val){
           if(l>r) return;
           if(l==r){
              st[id] = val;
              return;
           }
           int mid =(l+r)/2;
           if(u<=mid) update(id*2,l,mid,u,val);
           else update(id*2+1,mid+1,r,u,val);
           st[id]=Math.Max(st[id*2],st[id*2+1]);
    }
    int get(int id,int l,int r,int val){
        if(l>r) return 0;
        if(l==r) return l;
        int mid=(l+r)/2;
        if(st[id*2]>=val) return get(id*2,l,mid,val);
        else return get(id*2+1,mid+1,r,val);
    }
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = fruits.Length;
        st= new int[4*n+1];
       for(int i=0;i<n;i++){
           update(1,0,n-1,i,baskets[i]);
       }
       int ans = 0;
       for(int i=0;i<n;i++){
            if(st[1]<fruits[i]){
                ans++;
            }
            else {
                int index = get(1,0,n-1,fruits[i]);
                update(1,0,n-1,index,0);
            }
       }
        
        return ans;
    }
}
