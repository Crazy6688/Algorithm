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
            //    var test = new Case_464();
            //   test.Test();
            //var p = new Program();

            //p.climbStairs(20);

            var a = 12345;
            var b = a % -10;


 
            Rotate3(new int[3][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } });
            reverseBits(1);
        }

        public static void Rotate3(int[][] matrix)
        {
            //首先计算中心坐标系
            for (var i = 0; i < matrix.Length; i++)
                for (var j = 0; j < matrix.Length; j++)
                {
                    var p1 = getPos(i, j, matrix.Length);
                    Console.WriteLine($"        ={p1.Item1},{p1.Item2}");
                }





        }

        public static (double, double) getPos(int row, int col, int len)
        {


            var x1 = (double)(col);
            var y1 = (double)(len - row - 1);

            Console.Write($" row:{row},col:{col} =>  {x1},{y1}");
            if (x1 == 0)
                return (row, 0 + len - 1);
            var k = y1 / x1;

            var dis2 = x1 * x1 + y1 * y1;

            var y2a = Math.Sqrt((dis2) / (k * k + 1));
            var x2a = -k * y2a;

            var y2b = -y2a;
            var x2b = -k * y2b;

            var use = x1 * y2a - y1 * x2a < 0;
            var x2 = use ? x2a : x2b;
            var y2 = use ? y2a : y2b;

            return (x2, len - (y2 + len - 1) - 1);

        }

        public static uint reverseBits(uint n)
        {
            return M1(n);
        }

        //方法1,按位交换
        public static uint M1(uint n)
        {

            //  Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            uint ans = 0;
            for (var i = 0; i < 16; i++)
            {
                var l = (n & (1 << (31 - i))) > 0 ? 1 : 0;
                var r = (n & (1 << (i))) > 0 ? 1 : 0;
                ans |= (uint)(l << i);
                ans |= (uint)(r << (31 - i));
            }
            //   Console.WriteLine(Convert.ToString(ans, 2).PadLeft(32, '0'));
            return ans;
        }

        public static void Rotate(int[] nums, int k)
        {
            Console.WriteLine($"{string.Join(',', nums)}");

            k = k % nums.Length;
            if (nums == null || nums.Length < 1 || k == 0)
            {
                return;
            }
            var len = nums.Length;
            var val = nums[0];
            var start = 0;              //从此索引开始
            var cur = 0;                //当前要被被替换的位置

            for (var i = 0; i < nums.Length; i++)
            {
                var prev = (cur - k + len) % len;       //找到替换者的位置

                if (start == prev)                      //转完了一圈,再继续就重复替换
                {
                    nums[cur] = val;
                    //跳转到下一个
                    cur = start = (start + 1) % len;
                    val = nums[cur];
                }
                else
                {
                    nums[cur] = nums[prev];
                    cur = prev;
                }

            }

            Console.WriteLine($"{string.Join(',', nums)}");
        }

        public static void Rotate2(int[] nums, int k)
        {
            Console.WriteLine($"{string.Join(',', nums)}");

            k = k % nums.Length;
            if (nums == null || nums.Length < 1 || k == 0)
            {
                return;
            }
            var len = nums.Length;

            for (var i = 0; i < nums.Length;)
            {
                var val = nums[i];
                var start = i;
                for (var j = i; ;)
                {
                    var temp = (j - k + len) % len;
                    i++;
                    if (temp == start)
                    {
                        nums[j] = val;
                        Console.WriteLine($"{string.Join(',', nums)}");
                        break;
                    }

                    nums[j] = nums[temp];
                    j = temp;
                }
            }

            //    Console.WriteLine($"{string.Join(',', nums)}");
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
