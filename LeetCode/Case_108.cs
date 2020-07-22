using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /*
将一个按照升序排列的有序数组，转换为一棵高度平衡二叉搜索树。

本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。

示例:

给定有序数组: [-10,-3,0,5,9],

一个可能的答案是：[0,-3,9,-10,null,5]，它可以表示下面这个高度平衡二叉搜索树：

      0
     / \
   -3   9
   /   /
 -10  5
     
     */
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class Case_108 : ICase
    {
        [TestMethod]
        public void Test()
        {
            int[] nums = new[] { -10, -3, 0, 5, 9 };
            var root = SortedArrayToBST(nums);

        }


        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;
            var mid = nums.Length / 2;
            var val = nums[mid];
            var left = nums.Take(mid).ToArray();
            var right = nums.Skip(mid + 1).ToArray();

            var node = new TreeNode(val);
            node.left = SortedArrayToBST(left);
            node.right = SortedArrayToBST(right);
            return node;

        }
    }
}
