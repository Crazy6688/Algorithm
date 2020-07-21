using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sort
{
    class Program
    {
        static Random _rand = new Random();
        static void Main(string[] args)
        {
            SortAlgorithm<int>[] algs = new SortAlgorithm<int>[]
            {
                new BubbleSort<int>(),
                new FastSort<int>(),
                new CountingSort(),
                new BucketSort<int>(),
            };
            //随机一组数据
            var count = 10000;
            var numbers = new int[count];
            for (var i = 0; i < count; i++)
            {
                numbers[i] = _rand.Next(count);
            }
            var comparer = new IntComparer();
            Console.WriteLine($"元素总数:{numbers.Count()}");
            foreach (var alg in algs)
            {
                var data = new Data<int>(numbers);

                Console.WriteLine($"正在进行 {alg.AlgName}");

                var w = Stopwatch.StartNew();
                alg.Comparer = comparer;
                alg.Asc = true;         //设置为升序排序方式
                alg.Sort(data);
                w.Stop();

                Console.WriteLine($"已完成\r\n\t\t 比较次数:{alg.CompareCount}\t  交换次数:{alg.SwapCount}\t  历时: {w.ElapsedMilliseconds}ms\t\r\n  结果:{data} \r\n\r\n");
            }

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Data<T> : List<T>
    {
        public Data(IEnumerable<T> datas)
        {
            this.AddRange(datas);
        }

        public override string ToString()
        {
            return string.Join(" , ", this.Take(15));
        }
    }

    /// <summary>
    /// 自定义一个整型数据比较器
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    /// <summary>
    /// 排序算法接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISortAlgorithm<T>
    {
        /// <summary>
        /// 获取算法名称
        /// </summary>
        string AlgName { get; }

        /// <summary>
        /// 升序或者降序
        /// </summary>
        bool Asc { get; set; }

        /// <summary>
        /// 交换次数
        /// </summary>
        int SwapCount { get; }

        /// <summary>
        /// 比较次数
        /// </summary>
        int CompareCount { get; }

        /// <summary>
        /// 排序方法
        /// </summary>
        /// <param name="sources"></param>
        void Sort(Data<T> sources);

        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int Compare(T x, T y);
    }

    /// <summary>
    /// 排序算法抽象类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SortAlgorithm<T> : ISortAlgorithm<T>
    {
        public abstract string AlgName { get; }

        public IComparer<T> Comparer { get; set; }

        public bool Asc { get; set; }

        public int SwapCount { get; set; }

        public int CompareCount { get; set; }

        public int Compare(T x, T y)
        {
            CompareCount++;
            return Asc ? Comparer.Compare(x, y) : -Compare(x, y);
        }

        public abstract void Sort(Data<T> sources);

        protected void Swap(Data<T> ss, int i, int j)
        {
            if (i == j)
                return;
            SwapCount++;
            var tmp = ss[i];
            ss[i] = ss[j];
            ss[j] = tmp;
        }
    }

}
