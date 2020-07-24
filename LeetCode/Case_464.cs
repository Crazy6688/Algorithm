using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    public class Case_464 : ICase
    {

        public void Test()
        {
            var win1 = CanIWin(4, 6);
            var win2 = CanIWin(10, 11);
            var win3 = CanIWin(10, 40);
            var win4 = CanIWin(18, 79);
            //System.Diagnostics.Debug.WriteLine($"464:{win2}");
        }


        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (maxChoosableInteger * (maxChoosableInteger - 1) / 2 < desiredTotal)
                return false;
            if (maxChoosableInteger >= desiredTotal)
                return true;

            var hhh = helper(maxChoosableInteger, desiredTotal, new Boolean[1 << maxChoosableInteger], 0);


            //Console.WriteLine($"CanIWin=>{maxChoosableInteger},{desiredTotal}!");
            //for (var i = 1; i <= maxChoosableInteger; i++)
            //{
            //    var www = win(1 << i, new Dictionary<int, int>() { { 1, i } }, maxChoosableInteger, 0, desiredTotal);
            //    if (!www)
            //        return false;
            //}
            if (hhh)
                Console.WriteLine($"{maxChoosableInteger},{desiredTotal},先手稳赢!");
            return true;
        }


        bool win(int flag, Dictionary<int, int> seq, int max, int total, int desireTotal)
        {
            //A表示先手 
            var loop = BitOperations.PopCount((uint)flag) + 1;
            //  var role = loop % 2 == 0 ? 'A' : 'B';

            for (var i = 1; i <= max; i++)
            {
                if ((flag & (1 << i)) > 0)
                    continue;
                var newflag = flag;
                newflag |= (1 << i);
                seq[loop] = i;
                var newTotal = total + i;

                if (newTotal >= desireTotal ||
                    win(newflag, seq, max, newTotal, desireTotal) == false)
                {
                    return true;
                }
            }

            return false;

        }

        public bool helper(int maxChoosableInteger, int desiredTotal, bool[] dp, int state)
        {
            if (dp[state] != false)
                return dp[state];
            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                int cur = 1 << (i - 1);
                if ((cur & state) != 0)
                    continue;

                // 如果当前选择使得累积和大于等于desiredTotal
                // 又或者当前选择之后，另一个人的选择必输，说明当前必赢
                if (desiredTotal - i <= 0 ||
                    helper(maxChoosableInteger, desiredTotal - i, dp, state | cur) == false)
                {
                    return dp[state] = true;
                }
            }

            // 无论怎么选都无法让对手输，那么就是自己输了
            return dp[state] = false;
        }

    }
}
