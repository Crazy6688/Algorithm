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
            //10,11,false
            //4,6,true
            //10,40,false
            //18.79,true
            //6,16,true
            //var win1 = CanIWin(4, 6);
            //var win2 = CanIWin(10, 11);
            //var win3 = CanIWin(10, 40);
            //var win4 = CanIWin(18, 79);
            var win5= CanIWin(6, 16);
            //System.Diagnostics.Debug.WriteLine($"464:{win2}");
        }


        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (maxChoosableInteger * (maxChoosableInteger + 1) / 2 < desiredTotal)
                return false;
            if (maxChoosableInteger >= desiredTotal)
                return true;
            var map1 = new Boolean[1 << maxChoosableInteger];
            var hhh1 = win1(maxChoosableInteger, desiredTotal, map1, 0);

            var map2 = new Dictionary<int, bool>(1 << maxChoosableInteger);
            var hhh2 = win2(maxChoosableInteger, desiredTotal, map2, 0);


            var hhh3 = win3(0, maxChoosableInteger, desiredTotal);


            if (hhh1 && hhh2)
                Console.WriteLine($"{maxChoosableInteger},{desiredTotal},先手稳赢!");
            if (hhh1 != hhh3)
                Console.WriteLine($"{maxChoosableInteger},{desiredTotal},ERROR!");
            return true;
        }


        /// <summary>
        /// 该方法用于判定在已经各自取值的state状态后,是否在经过一次取数据就赢
        /// 返回true,表示可以,返回false表示不可以
        /// 因为每一个state值对应了一个当前各自取值的累加,所以只需要判定是否能再取一次值就胜利,如果能,表示稳赢
        /// </summary>
        /// <param name="maxChoosableInteger"></param>
        /// <param name="desiredTotal"></param>
        /// <param name="dp"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool win1(int maxChoosableInteger, int desiredTotal, bool[] dp, int state)
        {
            if (dp[state] != false)
                return dp[state];
            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                int cur = 1 << (i - 1);
                if ((cur & state) != 0)
                    continue;
 
                if (desiredTotal - i <= 0 ||
                    win1(maxChoosableInteger, desiredTotal - i, dp, state | cur) == false)
                {
                    return dp[state] = true;
                }
            }

            // 无论怎么选都无法让对手输，那么就是自己输了
            return dp[state] = false;
        }

        /// <summary>
        /// 和win1方法一样,用字典存放状态,效率比数组低
        /// </summary>
        /// <param name="maxChoosableInteger"></param>
        /// <param name="desiredTotal"></param>
        /// <param name="dp"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool win2(int maxChoosableInteger, int desiredTotal, Dictionary<int, bool> dp, int state)
        {
            if (dp.TryGetValue(state, out var has))
                return has;

            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                int cur = 1 << (i - 1);
                if ((cur & state) != 0)
                    continue;

                if (desiredTotal <= i ||
                    win2(maxChoosableInteger, desiredTotal - i, dp, state | cur) == false)
                {
                    return dp[state] = true;
                }
            }

            return dp[state] = false;
        }

        /// <summary>
        /// 不采用记忆缓存,每次都累加,效率最低,但减少了空间
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="max"></param>
        /// <param name="desireTotal"></param>
        /// <returns></returns>
        bool win3(int flag, int max, int desireTotal)
        {
            for (var i = 1; i <= max; i++)
            {
                if ((flag & (1 << i)) > 0)
                    continue;
                var newflag = flag;
                newflag |= (1 << i);

                if (desireTotal <= i || win3(newflag, max, desireTotal - i) == false)
                {
                    return true;
                }
            }

            return false;

        }

    }
}
