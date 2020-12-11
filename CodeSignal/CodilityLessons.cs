using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSignal
{
    class CodilityLessons
    {
        public static bool isPrime(int x)
        {
            if (x == 2 || x == 3 || x == 5 || x == 7) return true;
            else if (x == 1) return false;
            var xArr = x.ToString().ToCharArray().Select(_ => Convert.ToInt32(_-'0'));
            var checkList = new List<int>() { 0, 2, 4, 6, 8 };
            var xsqrt =(int) Math.Sqrt(x);
            if (checkList.Contains(Convert.ToInt32(xArr.Last()))) return false;
            else if (xArr.Sum() % 3 == 0) return false;
            for (int i = 11; i <= xsqrt;)
            {
                if (x % i == 0)
                    return false;
                if (i.ToString().EndsWith("3")) i += 4;
                else i += 2;
            }
            return true;
        }
        public static int fab(int x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            return fab(x-1)+fab(x-2);
        }
        public static bool isFab(int x)
        {
            for (int i = 0; i <= (x/2)+2; i++)
            {
                if (fab(i) == x) return true;
                if (fab(i) > x) return false;
            }
            return false;
        }

        public static int solution()
        {
            var jumps = 0;
            var A = new int[] { 0,0,0,1,1,0,1,0,0,0,0 };
            var totDis = A.Length + 1;
            var fabList = new List<int>();
            var firstFab = 0;
            var secondFab = 1;
            for (int i = 0; i <= 12; i++)
            {
                fabList.Add(firstFab + secondFab);
                firstFab = firstFab + secondFab;
            }

            if (isFab(totDis)) return ++jumps;
            
            var tempFab = -1;
            for (int i = 0; i < A.Length; i++)
            {
                
            }





            var B = new int[] {75,30,5 };
            var mainCounter = 0;
            for (int i = 0; i < B.Length; i++)
            {
                var first = A[i];
                var second = B[i];
                int divisiorLimit = first > second ? first : second;
                divisiorLimit = (int)Math.Sqrt(divisiorLimit);
                var counterA = 0;
                var counterB = 0;
                for (int j = 2; j <=divisiorLimit; j++)
                {
                    if (first % j == 0 && isPrime(j)) counterA++;
                    if (second % j == 0 && isPrime(j)) counterB++;
                    if (counterA != counterB) break;
                }
                if (counterA == counterB )
                    mainCounter++;
            }
            return mainCounter;
            //var A = new int[] {-1,-2,-3}; // decreasing negative
            //var A = new int[] {-3,-2,-1};  // increasing negative
            //var A = new int[] {1,2,3};  // increasing positvie
            //var A = new int[] {3,2,1};  // decreasing positvie
            //var A = new int[] {-3,-2,-1,0,1,2,3};  // increasing positvie-negative
            //var A = new int[] {0,1,2,3,0,-1,-2,-3};  // decreasing positvie-negative
            //var A = new int[] {0,1,2,3,0,-1,-2,-3,4,3};  // increase-decrease-increase
            //var A = new int[] {-1,-2,-3,0,1,2,3,-4,-3};  // decrease-increase-decrease
            //var A = new int[] {};  // decrease-increase-decrease
            //var A = new int[] {-2};  // single
            //var A = new int[] {1,2};  // decrease-increase-decrease



            A = new int[] {3};  //3
            var temp = new int[A.Length];  
            for (int i = 0; i < A.Length; i++)
            {
                var counter = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (i != j && A[i] % A[j] != 0) counter++;
                }
                temp[i] = counter;
            }
           
            if (A.Length == 0) return 0;
            var startIndex = -1;
            var max = int.MinValue;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > max)max = A[i];
                if (A[i] > 0)
                {
                    startIndex = i;
                    break;
                }
            }
            if (startIndex < 0) return max;
            var total = 0;
            var sum = 0;
            var prevSum = 0;
            for (int i = startIndex; i < A.Length; i++)
            {
                total += A[i];

                if (A[i] + sum > sum) sum = Math.Max(A[i] + sum, A[i]);
                else
                {
                    prevSum = Math.Max(sum, prevSum);
                    sum = A[i] + sum;
                }
            }
            sum = Math.Max(Math.Max(prevSum, sum), total);
            return sum;
    }
        public static string scanEachElemetInListAgainstEach()
        {
            var counter = 0;
            var str = "abdc";
            var pairs = new int[][] 
            {
                new int[]{1,4 },
                new int[]{3,4 },
            };
            var indexLists = new List<HashSet<int>>();
            for (int i = 0; i < pairs.Length; i++)
            {
                counter++;
                var x = pairs[i][0] - 1;
                var y = pairs[i][1] - 1;
                var newLists = new HashSet<int>() { x, y };
                foreach (var list in indexLists.ToList())
                {
                    counter++;
                    if (list.Contains(x) || list.Contains(y))
                    {
                        newLists.UnionWith(list);
                        indexLists.Remove(list);
                    }
                }
                indexLists.Add(newLists);
            }
            StringBuilder strnew = new StringBuilder(str);
            for (int i = 0; i < indexLists.Count; i++)
            {
                var temp = indexLists[i].ToList();
                temp.Sort();
                var list = new List<char>();
                foreach (var chr in temp)
                {
                    list.Add(str[chr]);
                }
                list.Sort();
                list.Reverse();
                foreach (var chr in temp)
                {
                    strnew[chr] = list.First();
                    list.RemoveAt(0);
                }
            }
            return strnew.ToString();
        }
        public static int maxdoubleSlice2(int[] A)
        {
            int i, n;

            n = A.Length;

            if (3 == n) return 0;

            var max_sum_end = new int[n];
            var max_sum_start = new int[n];

            for (i = 1; i < (n - 1); i++) // i=0 and i=n-1 are not used because x=0,z=n-1
            {
                max_sum_end[i] = Math.Max(0, max_sum_end[i - 1] + A[i]);
            }

            for (i = n - 2; i > 0; i--) // i=0 and i=n-1 are not used because x=0,z=n-1
            {
                max_sum_start[i] = Math.Max(0, max_sum_start[i + 1] + A[i]);
            }

            int maxvalue, temp;
            maxvalue = 0;

            for (i = 1; i < (n - 1); i++)
            {
                temp = max_sum_end[i - 1] + max_sum_start[i + 1];
                if (temp > maxvalue) maxvalue = temp;
            }

            return maxvalue;
        }
        public static int maxdoubleSlice(int[] A)
        {
            var max = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length - 1; j++)
                {
                    for (int k = j + 1; k < A.Length; k++)
                    {
                        if (j - i - 1 != 0 || k - j - 1 != 0)
                        {
                            var sum = maxSliceSum(A.Skip(i + 1).Take(j - i - 1).ToArray()) +
                                    maxSliceSum(A.Skip(j + 1).Take(k - j - 1).ToArray());
                            if (sum > max)
                                max = sum;
                        }
                    }
                }
            }
            return max;
        }
        public static int maxSliceSum(int[] A)
        {
            if (A.Length == 0) return 0;
            var previousSliceMax = -10000;
            var max = -10000;
            for (int i = 0; i < A.Length; i++)
            {
                previousSliceMax = A[i] > previousSliceMax + A[i] ? A[i] : previousSliceMax + A[i];
                max = previousSliceMax > max ? previousSliceMax : max;
            }
            return max;
        }
        public static void main()
        {
            CodlilityLessonsMain.main();
            return;
            var a = CodilityLessons.getRandomNumbersArray(10, 0, 10);
            var b = CodilityLessons.getRandomNumbersArray(10, 0, 1);
            {
                countLivingFishes(a, b);
                getRandomSizeArrays(-100, 1100);
                getRandomNumbersArray(100, 1, 2);
                rungetSmallestNum();
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
        }

        public static int countLivingFishes(int[] A, int[] B)
        {
            if (A.Length == 0) return 0;
            if (A.Length == 1) return 1;
            var stack = new List<int>();
            var leftOnes = Array.IndexOf(B, 1);
            if (leftOnes == -1) return A.Length;
            var onesMax = int.MinValue;
            for (int i = leftOnes; i < A.Length; i++)
            {
                if (B[i] == 1)
                {
                    onesMax = A[i] > onesMax ? A[i] : onesMax;
                    stack.Add(A[i]);
                }
                else
                {
                    if (A[i] > onesMax)
                    {
                        stack.Clear();
                        leftOnes++;
                        onesMax = int.MinValue;
                    }
                    else
                    {
                        while (stack.Count != 0 && A[i] > stack.Last())
                        {
                            stack.RemoveAt(stack.Count - 1);
                        }
                    }
                }
            }
            return leftOnes + stack.Count;
        }

        public static void printIntArray(int[] A)
        {
            foreach (var item in A)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
        }
        public static int discintersection(int[] A)
        {
            if (A.Length < 2) return 0;
            var count = 0;
            var count2 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    double radiusSum = (double)A[i] + (double)A[j];
                    var pointsDiff = Math.Abs(i - j);
                    if (radiusSum >= pointsDiff)
                        count++;
                    if (count > 10000000) return -1;
                }
            }
            return count;

        }
        public static int discintersection2(int[] a)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            int result = 0;
            int[] dps = new int[a.Length];
            int[] dpe = new int[a.Length];

            for (int i = 0, tt = a.Length - 1; i < a.Length; i++)
            {
                int s = i > a[i] ? i - a[i] : 0;
                int e = tt - i > a[i] ? i + a[i] : tt;
                dps[s]++;
                dpe[e]++;
            }

            int t = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (dps[i] > 0)
                {
                    result += t * dps[i];
                    result += dps[i] * (dps[i] - 1) / 2;
                    //if (10000000 < result) return -1;
                    t += dps[i];
                }
                t -= dpe[i];
            }
            watch.Stop();
            var ts = watch.Elapsed.TotalMilliseconds / 1000;
            return result;

        }

        public static int countpairs(int[] A)
        {
            if (A.Length == 0 || A.Length == 1) return 0;
            var zc = 0;
            var total = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                    zc++;
                else
                {
                    total += zc;
                    if (total > 1000000000) return -1;
                }
            }
            return total;
        }

        public static int[] getRandomNumbersArray(int length, int min, int max)
        {
            var random = new Random();
            var arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(min, max + 1);
            }
            return arr;
        }

        public static int[][] getRandomSizeArrays(int min, int max)
        {
            int[][] arrays = new int[100][];
            arrays[0] = new int[0];
            arrays[1] = new int[1];
            arrays[2] = new int[2];
            var random = new Random();
            var arr = new int[random.Next(min, max)];
            for (int i = 0; i < arrays.Length; i++)
            {
                arrays[i] = new int[random.Next(0, max)];
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    arrays[i][j] = random.Next(min, max);
                }
            }
            return arrays;
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
            //var arr = new int[] { 5, 4, 8, 3, 7, 3 };
            var arr = new int[] { 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine(getSmallestNum(arr));
            Console.WriteLine(getSmallestNum2(arr));
        }
        public static int getSmallestNum(int[] A)
        {
            var minIndex = -1;
            double minAvg = int.MaxValue;
            for (int j = 2; j <= A.Length; j++)
                for (int i = 0; i < A.Length - j + 1; i++)
                {
                    var avg = Math.Round((double)A.Skip(i).Take(j).Sum() / (double)j, 2);
                    if (avg < minAvg) { minAvg = avg; minIndex = i; }
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
