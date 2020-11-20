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
            runTapeEquilibrium();
            runFindMissingElement();
            runFrogJumps();
            runOddOccurencesInArray();
            runBinaryGap();
            runRotateArray();
            Console.ReadKey();
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
                if(result!=result2)
                Console.WriteLine(result+"..OK.."+result2 + "...NO......");
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
            for (int i = 0; i < A.Length-1; i++)
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
