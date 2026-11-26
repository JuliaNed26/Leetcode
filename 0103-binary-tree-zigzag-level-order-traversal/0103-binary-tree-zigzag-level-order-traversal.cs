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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var queue = new Queue<(TreeNode node, int lvl)>();
        var result = new List<IList<int>>();
        queue.Enqueue((root, 0));
        while(queue.Count > 0)
        {
            (TreeNode curNode, int level) = queue.Dequeue();
            if(curNode == null)
            {
                continue;
            }
            if(level == result.Count)
            {
                result.Add(new List<int>());
            }
            result[level].Add(curNode.val);
            queue.Enqueue((curNode.right, level + 1));
            queue.Enqueue((curNode.left, level + 1));
        }
        
        for(int i = 2; i < result.Count; i += 2)
        {
            ((List<int>)result[i]).Reverse();
        }

        return result;
    }
}