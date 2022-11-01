public class Solution {
        public int[] FindBall(int[][] grid) {
            int[] ans=new int[grid[0].Length];
            for(int i=0;i<grid[0].Length;i++){
                ans[i]=dfs(i,grid);
            }
            return ans;
        }
        private int dfs(int col, int[][] grid){
            int i=0;
            int j=col;

            while (i<grid.Length){
                if(j==0 && grid[i][j]==-1)
                    return -1;
                if(j==grid[i].Length-1 && grid[i][j]==1)
                    return -1;
                if(j<grid[i].Length-1 && grid[i][j]==1 && grid[i][j+1]==-1)
                    return -1;

                if(j>0 && grid[i][j-1]==1 && grid[i][j]==-1)
                    return -1;
                
                j+=grid[i][j]==1?1:-1;
                i++;
            }
            return j;
        }
    }
