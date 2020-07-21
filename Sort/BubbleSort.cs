using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    /// <summary>
    /// 冒泡排序算法是把较小的元素往前调或者把较大的元素往后调。
    /// </summary>
    class BubbleSort<T> : SortAlgorithm<T>
    {
        public override string AlgName => "冒泡排序";

        public override void Sort(Data<T> sources)
        {
            var c = sources.Count;
            for (var i = 0; i < c; i++)
            {
                for (var j = 0; j < c - i - 1; j++)
                {
                    if (Compare(sources[j], sources[j + 1]) > 0)
                    {
                        Swap(sources, j, j + 1);
                    }
                }
            }
        }
    }
}
