using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Sort
{
    /// <summary>
    /// 通过一趟排序将要排序的数列分成两个独立的新数列,其中一个新数列的每个元素都比另一个新数列的任何一个元素要小。之后,对这两个数列再次进行快速排序。
    /// </summary>
    public class FastSort<T> : SortAlgorithm<T>
    {
        public override string AlgName => "快速排序";


        public override void Sort(Data<T> sources)
        {
            if (sources.Count < 2) return;
            qsort(sources, 0, sources.Count - 1);
        }

        void qsort(Data<T> ss, int sIdx, int eIdx)
        {
            int i = sIdx, j = eIdx;
            if (i >= j) return;
            var bval = ss[sIdx];   //基准数
            for (; i < j;)
            {
                for (; i != j; j--)
                {
                    if (Compare(ss[j], bval) < 0)
                        break;
                }
                for (; i != j; i++)
                {
                    if (Compare(ss[i], bval) > 0)
                        break;
                }
                if (i < j)
                    Swap(ss, i, j);
            }

            if (sIdx < i)
                Swap(ss, sIdx, i);

            //递归左右两侧
            qsort(ss, sIdx, i - 1);
            qsort(ss, i + 1, eIdx);
        }

    }
}
