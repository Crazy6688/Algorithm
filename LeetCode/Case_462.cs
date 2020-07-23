using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{

    /*
    在 "100 game" 这个游戏中，两名玩家轮流选择从 1 到 10 的任意整数，累计整数和，先使得累计整数和达到 100 的玩家，即为胜者。

    如果我们将游戏规则改为 “玩家不能重复使用整数” 呢？

    例如，两个玩家可以轮流从公共整数池中抽取从 1 到 15 的整数（不放回），直到累计整数和 >= 100。

    给定一个整数 maxChoosableInteger （整数池中可选择的最大数）和另一个整数 desiredTotal（累计和），判断先出手的玩家是否能稳赢（假设两位玩家游戏时都表现最佳）？

    你可以假设 maxChoosableInteger 不会大于 20， desiredTotal 不会大于 300。
      
     */

    public class Case_462 : ICase
    {

        public void Test()
        {
            var n0 = MinMoves2(new[] { 1, 2, 99 });
            var n1 = MinMoves2(new[] { 1, 0, 0, 8, 6 });
            var n2 = MinMoves2(new[] { 1, 2, 3 });
            var n3 = MinMoves2(new[] { 1 });
            var n4 = MinMoves2(new[] { 1, 2 });
            var n5 = MinMoves2(new[] { 203125577, -349566234, 230332704, 48321315, 66379082, 386516853, 50986744, -250908656, -425653504, -212123143 });

        }


        public int MinMoves2(int[] nums)
        {
            nums = nums.OrderBy(o1 => o1).ToArray();
            var count = 0;
            var m = nums.Length / 2;
            var k = nums[m];
            count = (int)Move(nums, k);
            return count;
        }

        public long Move(int[] nums, int v)
        {
            long count = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                count += Math.Abs(nums[i] - v);
            }
            return count;
        }

    }
}
