using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /*
根据一棵树的中序遍历与后序遍历构造二叉树。

注意:你可以假设树中没有重复的元素。
例如，给出
中序遍历 inorder = [9,3,15,20,7]
后序遍历 postorder = [9,15,7,20,3]
返回如下的二叉树：

    3
   / \
  9  20
    /  \
   15   7
 
     */


    /// <summary>
    /// 
    /// </summary>

    public class Case_106: ICase
    {
        public void Test()
        {
            //var inorder = new[] { 2, 3, 1 };
            //var postorder = new[] { 3, 2, 1 };

            //var inorder = new[] { 9, 3, 15, 20, 7 }; 
            //var postorder = new[] { 9, 15, 7, 20, 3 };

            var inorder = new int[] { 2, 1 };
            var postorder = new int[] { 2, 1 };

            TreeNode root = BuildTree(inorder, postorder);
        }

        public   TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            //1.首先后续遍历的最后一个数据是当前的树根
            //2.找到中序遍历中的树根元素,这个元素将数组分为左右两个数组集合,这两个集合分别是左右子树中序遍历的结果
            //3.左侧的集合是当前节点的左侧数据部分, 将当前后续集合中的数据排除右侧集合的数据,剩下的就是左子树的后续遍历结果


            if (postorder.Length == 0)
                return null;
            var val = postorder.Last();

            var node = new TreeNode(val);
            var idx_l = Array.IndexOf(inorder, val);


            var new_inorder_l = inorder.Take(idx_l + 1).ToArray();
            var new_inorder_r = inorder.Skip(idx_l).ToArray();

            var new_postorder = postorder.Except(new_inorder_r).ToArray();
            node.left = BuildTree(new_inorder_l, new_postorder);

            var new_postorder2 = postorder.Except(new_inorder_l).ToArray();

            node.right = BuildTree(new_inorder_r, new_postorder2);

            return node;
        }


    }
}
