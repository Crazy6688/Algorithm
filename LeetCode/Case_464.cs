using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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

            var win0 = CanIWin(10,11);
         //   var win1 = CanIWin(4, 6);

            //  var wina = CanIWin(4, 7);

         //   var win2 = CanIWin(10, 40);
         //   var win3 = CanIWin(18, 79);
        }


        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (maxChoosableInteger * (maxChoosableInteger - 1) / 2 < desiredTotal)
                return false;

            var w = loop(0, maxChoosableInteger, 0, desiredTotal);
            if (w)
            {
                Console.WriteLine($"{maxChoosableInteger},{desiredTotal},先手稳赢!");
            }
            return w;

        }

        /// <summary>
        /// 返回值: 如果为true,表示当前获取数据的用户稳赢,非常重要的观点,递归的方法返回的是当前用户选择后是否稳赢
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="total"></param>
        /// <param name="desiredTotal"></param>
        bool loop(int bs, int count, int total, int desiredTotal)
        {
            for (var i = 0; i < count; i++)
            {
                if ((bs & (1 << i)) > 0)
                    continue;

                var nbs = bs + (1 << i);
                var newTotal = total + (i + 1);
                if (newTotal >= desiredTotal)
                    return true;
                else
                {
                    //对方开始选
                    var ret = loop(nbs, count, newTotal, desiredTotal);
                    //对方稳赢,那我就输了,这是重点
                    if (ret)//对方稳输,那我稳赢
                        return false;
                    if (bs == 0)
                        return !ret;
                }
            }
            //疑惑,这里返回true
            return true;
        }

    }
}
