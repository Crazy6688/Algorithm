using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    /// <summary>
    /// 工作的原理是将数组分到有限数量的桶里。每个桶再个别排序（有可能再使用别的排序算法或是以递归方式继续使用桶排序进行排序），最后依次把各个桶中的记录列出来记得到有序序列。
    /// 桶排序是鸽巢排序的一种归纳结果。当要被排序的数组内的数值是均匀分配的时候，桶排序使用线性时间（Θ(n)）
    /// </summary>
    class BucketSort<T> : SortAlgorithm<T>
    {
        public override string AlgName => "桶排序";

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
