using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort
{
    /// <summary>
    /// 计数排序
    /// </summary>
    class CountingSort : SortAlgorithm<int>
    {
        public override string AlgName => "计数排序";

        public override void Sort(Data<int> cs)
        {
            var max = cs.Max();
            var min = cs.Min();

            int[] counts = new int[max - min + 1];

            foreach (var v in cs)
            {
                counts[v - min]++;
            }
 
            if (this.Asc)
            {
                var index = 0;
                for (var i = 0; i < counts.Length; i++)
                {
                    while (counts[i] > 0)
                    {
                        cs[index++] = i + min;
                        counts[i]--;
                    }
                }
            }
            else
            {
                var index = cs.Count - 1;
                for (var i = 0; i < counts.Length; i++)
                {
                    while (counts[i] > 0)
                    {
                        cs[index--] = i + min;
                        counts[i]--;
                    }
                }
            }


        }
    }
}
