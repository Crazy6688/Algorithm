using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new Case_464();
            test.Test();
            var p = new Program();

            p.climbStairs(20);

        }




        int[] cache = new int[100];

        public int climbStairs(int n)
        {
            if (n <= 0)
                return 0;
            if (cache == null)
                cache = new int[n + 1];
            if (n <= 2)
                return cache[n] = n;

            if (cache[n] == 0)            
                cache[n] = climbStairs(n - 1) + climbStairs(n - 2); 

            return cache[n];
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
}
