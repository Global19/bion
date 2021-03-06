// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using BenchmarkDotNet.Running;

using RoughBench;

namespace BSOA.Benchmarks
{
    // Learnings
    // =========
    //  - ForEach enumeration is best for BSOA, because ArraySlice and count can be 'snapped' and used for full loop.
    //  - In StringColumn, IsNull check first is worthwhile (much faster for all null columns, minimal impact on no-null columns).
    //  - DistinctColumn caching is very worthwhile (string form of values kept anyway to look up index on set; keeping another list of references saves all conversions on get).
    //  - StringColumn caching too expensive with "remove oldest from cache" (remove too expensive vs. convert)
    //  - StringColumn caching only worthwhile if the cache hits relatively often; usage pattern will vary.
    //  - StringColumn "cache last read" is often helpful and minimal overhead otherwise.
    //  - Can cache last read key in columns by using a class holding the value and rowIndex; changing the class reference is atomic.
    //  - Optimized ArraySlice enumeration is still faster than ArraySliceEnumerator.
    //  - Dictionary walk of Key/Value pairs is very expensive (UTF-8 converting every value)
    //  - Dictionary sorting by Key is only worthwhile if IComparer is cached in column. (Adding an extra object construction is too expensive).
    //  - Dictionary Binary Search of keys ties linear for 13 string keys (search is fewer comparisons, but CompareTo is slower than Equals, which can return early on GetHashCode non-match)

    // Improvements
    // ============
    //  - ListEnumerator caches length               (65 -> 40 us)
    //  - EnumeratorConverter                        (40 -> 20 us)
    //  - ArraySliceEnumerator; enumerators classes  (20 -> 14 us)
    //  - DistinctColumn caching                     (83 ->  9 us for Message.Length Sum)
    //  - For Loop, no list caching                  (178 -> 70 us)
    //  - Dictionary DistinctColumn key caching      (700 -> 500 us)
    //  - Dictionary walk Keys, not pairs            (500 -> 350 us)
    //  - Dictionary innerRow, not pairIndex         (350 -> 300 us)
    //  - Dictionary optimized key Slice loop        (300 -> 250 us)
    //  - Dictionary 4 -> 13 keys
    //  - Dictionary sort keys, cache Comparer       (275 -> 221 us)
    //  - ListColumn<int> (1000 x 4)                 (277 / 543 / 217) -> (142 / 263 / 166) (foreach, for, for w/cached List+count)
    //    - ColumnList caches NumberList             (277 -> 196)
    //    - ColumnList uses EnumeratorConverter      (196 -> 154)
    //    - ColumnList.Get doesn't get NumList 2x    (154 -> 146)
    //  - GenericNumberListColumn<int> not-nullable  (67 / 263 / 122)
    //  

    /// <summary>
    ///  Run BSOA Benchmarks from the command line.
    ///  Run without arguments for 'RoughBench' quick test; returns exit code zero for "PASS", -1 for "FAIL".
    ///  Run with "--detailed" for Benchmark.NET high precision results.
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0 && args[0].ToLowerInvariant().Contains("detailed"))
            {
                BenchmarkRunner.Run<Basics>();
                BenchmarkRunner.Run<Strings>();
                BenchmarkRunner.Run<List>();
                BenchmarkRunner.Run<Dictionary>();
            }
            else
            {
                Console.WriteLine("Quick benchmarks. Pass --detailed for Benchmark.net numbers.");
                Benchmarker runner = new Benchmarker();

                runner.Run<Basics>();
                runner.Run<Strings>();
                runner.Run<List>();
                runner.Run<Dictionary>();

                runner.WriteSummary();
                return (runner.HasFailures ? -1 : 0);
            }

            return 0;
        }
    }
}
