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
    public class Case_464 : ICase
    {

        public void Test()
        {
            var win1 = CanIWin(4, 8);
            var win2 = CanIWin(10, 40);
            System.Diagnostics.Debug.WriteLine($"464:{win2}");
        }


        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            var www = false;
            for (var i = 1; i <= maxChoosableInteger; i++)
            {

                //var bs = new int[maxChoosableInteger];
                //bs[i - 1] = 1;
                //var w = win(bs, i, 1, desiredTotal);
                //if (w)
                //{
                //    www = true;
                //}
            }

            return www;
        }
         
    }
}
