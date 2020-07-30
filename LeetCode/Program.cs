using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            //var root = new Node(1);
            //root.left = new Node(2);
            //root.left.left = new Node(4);
            //root.left.right = new Node(5);

            //root.right = new Node(3);
            //root.right.right = new Node(7);



            var root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);

            root.left.left = new Node(4);
            root.left.right = new Node(5);


            root.right.right = new Node(6);

            root.left.left.left = new Node(7);

            root.right.right.right = new Node(8);

            var ccc = new Program().Connect(root);



            Console.WriteLine("Hello World!");
            var test = new Case_464();
            test.Test();
        }


        public Node Connect(Node root)
        {
            var top = root;
            BFS(ref top);
            DFS(root, 1);
            for (var p = root; p != null;)
            {
                var next = p.next;
                if (next == null || next.val / 6000 != p.val / 6000)
                    p.next = null;

                p.val = (p.val - 100 - (p.val / 6000) * 6000);

                p = next;
            }

            return root;
        }

        public void BFS(ref Node top)
        {
            if (top == null)
                return;

           // Console.WriteLine($"\t{top.val}, ");

            var tail = top;
            for (; tail != null; tail = tail.next)
            {
                if (tail.next == null)
                    break;
            }
            if (top.left != null)
            {
                tail = tail.next = top.left;
            }
            if (top.right != null)
            {
                tail = tail.next = top.right;
            }
            top = top.next;
            BFS(ref top);
            BFS(ref top);
        }

        public void DFS(Node node, int deep)
        {
            if (node == null) return;
            node.val = deep * 6000 + node.val + 100;
            DFS(node.left, deep + 1);
            DFS(node.right, deep + 1);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x) { val = x; }
        public override string ToString()
        {
            return $"{val}  ,L: {left?.val},  R: {right?.val}";
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node(int x) { val = x; }
        public override string ToString()
        {
            return $"{val}  ,L: {left?.val},  R: {right?.val}";
        }
    }
}
