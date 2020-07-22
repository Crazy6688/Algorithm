using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /*
给定一个二叉树，返回其节点值自底向上的层次遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）

例如：
给定二叉树 [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7
返回其自底向上的层次遍历为：

[
  [15,7],
  [9,20],
  [3]
]
     */
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class Case_107 : ICase
    {
        [TestMethod]
        public void Test()
        {
            var root = new TreeNode(0);
            var list = LevelOrderBottom(root);
        }


        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var lss = new List<IList<int>>();
            G2(lss, 1, root);
            
            //G1(lss, 1, root);
            //lss.Reverse();
            return lss;
        }

        /// <summary>
        /// 方法1,需要转置数组
        /// </summary>
        /// <param name="lss"></param>
        /// <param name="deep"></param>
        /// <param name="node"></param>
        public void G1(List<IList<int>> lss, int deep, TreeNode node)
        {
            if (node == null)
                return;

            if (lss.Count <= deep)
                lss.Add(new List<int>());

            G1(lss, deep + 1, node.left);
            G1(lss, deep + 1, node.right);

            lss[deep].Add(node.val);
        }

        /// <summary>
        /// 方法2,不用转置数组
        /// </summary>
        /// <param name="lss"></param>
        /// <param name="deep"></param>
        /// <param name="node"></param>
        public void G2(List<IList<int>> lss, int deep, TreeNode node)
        {
            if (node == null)
                return;
            if (lss.Count < deep)
            {
                lss.Insert(0, new List<int>());
            }
            G2(lss, deep + 1, node.left);
            G2(lss, deep + 1, node.right);

            lss[lss.Count - deep].Add(node.val);
        }
    }
}
