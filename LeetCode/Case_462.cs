using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 给定一个非空整数数组，找到使所有数组元素相等所需的最小移动数，其中每次移动可将选定的一个元素加1或减1。 您可以假设数组的长度最多为10000。
    /// 输入:
    ///[1,2,3]
    ///输出:
    ///2
    ///说明：
    ///只有两个动作是必要的（记得每一步仅可使其中一个元素加1或减1）：
    ///[1,2,3]  =>  [2,2,3]  =>  [2,2,2]
    /// </summary>
    public class Case_462: ICase
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
