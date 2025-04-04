/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private int maxDepth = 0;
 private TreeNode result = null;

 public TreeNode LcaDeepestLeaves(TreeNode root)
 {
     Helper(root, 0);
     return result;
 }

 public int Helper(TreeNode node, int level)
 {
     if (node == null)
         return 0;

     int left = Helper(node.left, level + 1);
     int right = Helper(node.right, level + 1);

     if (left == right && level + left >= maxDepth)
     {
         maxDepth = level + left;
         result = node;
     }

     return Math.Max(left, right) + 1;
 }
}
