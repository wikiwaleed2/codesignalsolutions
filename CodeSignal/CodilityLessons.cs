using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSignal
{
    class CodilityLessons
    {
        public static void main()
        {
            rungetSmallestNum();
            /// should be 2;
            runConsectiveCounters();
            runFrogRiverOne();
            runTapeEquilibrium();
            runFindMissingElement();
            runFrogJumps();
            runOddOccurencesInArray();
            runBinaryGap();
            runRotateArray();
            Console.ReadKey();
        }
        public static void rungetSmallestNum()
        {
            var result = 0;
            var result2 = 0;
            //while (result == result2)
            ////{
            //    var random = new Random();
            //    var arr = new int[10];
            //    for (int j = 0; j < arr.Length; j++)
            //    {
            //        arr[j] = random.Next(0, 1000);
            //    }
            //    result = getSmallestNum(arr);
            //    result2 = getSmallestNum2(arr);
            //    if (result != result2)
            //    {
            //        for (int j = 0; j < arr.Length; j++)
            //        {
            //            Console.Write(arr[j] + ",");
            //        }
            //        Console.WriteLine();
            //        Console.WriteLine("result: " + result);
            //        Console.WriteLine("result2: " + result2);
            //        Console.WriteLine();
            //    }

            //}
            //Console.WriteLine("Done");
            var arr = new int[] {  5, 4, 8, 3, 7, 3 };
            Console.WriteLine(getSmallestNum(arr));
            Console.WriteLine(getSmallestNum2(arr));
        }
        public static int getSmallestNum(int[] A)
        {
            var minIndex = -1;
            double minAvg = int.MaxValue;
            for (int j = 2; j <= A.Length; j++)
            {
                for (int i = 0; i < A.Length - j + 1; i++)
                {
                    var avg = Math.Round((double)A.Skip(i).Take(j).Sum() / (double)j, 2);
                    if (avg < minAvg) { minAvg = avg; minIndex = i; }
                }
            }
            return minIndex;
        }
        public static int getSmallestNum2(int[] A)
        {
            var minIndex = -1;
            var minIndexRtl = -1;
            var tempMinIndex = -1;
            double minAvg = int.MaxValue;
            double minavgRtl = int.MaxValue;
            var length = A.Length;
            for (int i = 0; i < length - 2 + 1; i++)
            {
                var avg = Math.Round((double)A.Skip(i).Take(2).Sum() / (double)2, 3);
                if (avg < minAvg) { minAvg = avg; minIndex = i; }

                avg = Math.Round((double)A.Skip(length - 2 - i).Take(2).Sum() / (double)2, 3);
                if (avg < minavgRtl)
                {
                    minavgRtl = avg; minIndexRtl = length - 2 - i + 1;
                };
            }
            for (int i = 3; i <= length - minIndex; i++)
            {
                var avg = Math.Round((double)A.Skip(minIndex).Take(i).Sum() / (double)i, 3);
                if (avg < minAvg)
                {
                    minAvg = avg;
                }
                else break;
            }
            for (int i = 3; i <= length; i++)
            {
                var avg = Math.Round((double)A.Skip(minIndexRtl - i + 1).Take(i).Sum() / (double)i, 3);
                if (avg < minavgRtl)
                {
                    minavgRtl = avg;
                    tempMinIndex = minIndexRtl - i + 1;
                }
                else break;
            }
            if (minAvg <= minavgRtl)
            {
                return minIndex;
            }
            else return tempMinIndex;
        }
        public static void runConsectiveCounters()
        {
            for (int k = 0; k < 5; k++)
            {
                var random = new Random();

                var arr = new int[100];
                var a = random.Next(1, 10);
                for (int i = 0; i < 100; i++)
                {
                    arr[i] = random.Next(1, a + 2);
                }
                //arr = new int[] { 4,4,4, 1, 3, 2, 1, 3,3,3,3,4,3,3,3,3,3,4,4,4,4 };
                //a = 3;
                var result = consectiveCounters(a, arr);
                var result2 = consectiveCounters2(a, arr);
                //if (result[0]!=result2[0])
                //{

                //    for (int i = 0; i < arr.Length; i++)
                //    {
                //        Console.Write(arr[i] + ",");
                //    }
                //    Console.WriteLine();
                //    for (int i = 0; i < result.Length; i++)
                //    {
                //        Console.Write(result[i] + ",");
                //    }
                //    Console.WriteLine();
                //    for (int i = 0; i < result2.Length; i++)
                //    {
                //        Console.Write(result2[i] + ",");
                //    }
                //}
                //Console.WriteLine();
                //Console.WriteLine();
            }
        }
        public static int[] consectiveCounters(int N, int[] A)
        {
            var counters = new int[N];
            var maxValue = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var aValue = A[i] - 1;
                if (A[i] <= N)
                {
                    counters[aValue]++;
                    if (maxValue < counters[aValue]) maxValue = counters[aValue];
                }
                else
                {
                    for (int j = 0; j < counters.Length; j++)
                    {
                        counters[j] = maxValue;
                    }
                }
            }
            return counters;
        }

        public static int[] consectiveCounters2(int N, int[] A)
        {
            var counters = new int[N];
            var lastIndex = Array.LastIndexOf(A, N + 1);
            var maxValue = 0;
            var prevmaxValue = 0;

            for (int i = 0; i <= lastIndex; i++)
            {
                var aValue = A[i] - 1;
                if (A[i] <= N)
                {
                    if (counters[aValue] < prevmaxValue) counters[aValue] = prevmaxValue;
                    counters[aValue]++;
                    if (maxValue < counters[aValue])
                        maxValue = counters[aValue];

                }
                if (A[i] == N + 1)
                {
                    prevmaxValue = maxValue;
                }
            }
            for (int j = 0; j < counters.Length; j++)
            {
                counters[j] = maxValue;
            }
            for (int j = lastIndex + 1; j < A.Length; j++)
            {
                var aValue = A[j] - 1;
                if (A[j] <= N)
                {
                    counters[aValue]++;
                }
            }
            return counters;
        }
        public static void runFrogRiverOne()
        {
            var result = frogRiverOne(4, new int[] { 1, 2, 34, 5, 6, 4, 3 });
            //Console.WriteLine(result);
        }
        public static int frogRiverOne(int X, int[] A)
        {
            var hash = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {

                if (A[i] <= X)
                    hash.Add(A[i]);
                if (hash.Count == X)
                    return i;
            }
            return -1;
        }
        public static void runTapeEquilibrium()
        {
            for (int j = 0; j < 100; j++)
            {
                Random _random = new Random();
                var arr = new int[_random.Next(_random.Next(1, 10000))];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = _random.Next(-100000, 10000);
                    //arr[i] = _random.Next(-100000,-1);
                    //arr[i] = _random.Next(1,10000);
                }
                //arr = new int[] { 2,4};
                //arr = new int[] { 2,4,9,19,1};
                var result = tapeEquilibrium(arr);
                var result2 = tapeEquilibrium2(arr);
                //Console.WriteLine(result + "..");
                //Console.WriteLine(result2 + "..");
                if (result != result2)
                    Console.WriteLine(result + "..OK.." + result2 + "...NO......");
            }

        }
        public static int tapeEquilibrium(int[] A)
        {
            if (A.Length == 0) return 0;
            if (A.Length == 1) return Math.Abs(A[0]);
            var minSum = -1;
            for (int i = 1; i < A.Length; i++)
            {
                var diff = Math.Abs(A.Take(i).Sum() - A.Skip(i).Sum());
                if (minSum == -1) minSum = diff;
                else if (diff < minSum) minSum = diff;
            }
            return minSum;
        }

        public static int tapeEquilibrium2(int[] A)
        {
            if (A.Length == 0) return 0;
            if (A.Length == 1) return Math.Abs(A[0]);
            var totalSum = A.Sum();
            var total = 0;
            int? minSum = null;
            for (int i = 0; i < A.Length - 1; i++)
            {
                total += A[i];
                var tempTotalDiff = Math.Abs(2 * total - totalSum);
                if (minSum == null)
                    minSum = tempTotalDiff;
                else if (minSum > tempTotalDiff)
                    minSum = tempTotalDiff;
            }
            return Convert.ToInt32(minSum);
        }
        public static void runFindMissingElement()
        {
            var result = FindMissingElement(new int[] { 2, 3 });
            //Console.WriteLine(result);
        }
        public static int FindMissingElement(int[] A)
        {
            if (A.Length == 0) return 1;
            Array.Sort(A);
            var next = A[0] == 1 ? 2 : 1;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] == next) next++;
                else return next;
            }
            return next;
        }
        public static void runFrogJumps()
        {
            var result = frogJumps(10, 85, 10);
            //Console.WriteLine(result);
        }
        public static int frogJumps(int X, int Y, int D)
        {
            var diff = Y - X;
            var extraJumpFraction = diff % D;
            if (extraJumpFraction == 0) return (Y - X) / D;
            else return ((Y - X) / D) + 1;
        }
        public static void runOddOccurencesInArray()
        {
            var arr = new int[] { 9, 3, 9, 3, 9, 7, 9 };
            var result = oddOccurencesInArray(arr);
            //Console.WriteLine(result);
        }
        public static int oddOccurencesInArray(int[] A)
        {
            int res = 0;
            for (int i = 0; i < A.Length; i++)
            {
                res = res ^ A[i];
            }
            return res;
        }
        public static void runBinaryGap()
        {
            var result = binaryGap(1011);
            //Console.WriteLine(result);
        }
        public static int binaryGap(int N)
        {
            var binary = Convert.ToString(N, 2);
            var maxLength = 0;
            var startIndex = -1;
            var zeroCounter = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (startIndex != -1) zeroCounter++;
                if (binary[i] == '1' && startIndex == -1) startIndex = i;
                if (binary[i] == '1' && startIndex != -1)
                {
                    maxLength = maxLength >= zeroCounter ? maxLength : zeroCounter - 1;
                    zeroCounter = 0;
                }
            }
            return maxLength == -1 ? 0 : maxLength;
        }
        public static void runRotateArray()
        {
            var arr = new int[] { 1, 2 };
            var rotations = 3;
            var result = rotateArray(arr, rotations);
        }
        public static int[] rotateArray(int[] A, int K)
        {
            var length = A.Length;
            var B = new int[length];
            if (length == 0) return A;
            if (length == K) return A;
            if (length < K) K = K % length;
            for (int i = 0; i < length; i++)
            {
                var temp = A[i];
                var nextIndex = i + (length - K);
                nextIndex = nextIndex >= length ? nextIndex - length : nextIndex;
                B[i] = A[nextIndex];
            }
            //for (int i = 0; i < length; i++)
            //    Console.Write(B[i] + ",");
            return B;
        }
    }
}
