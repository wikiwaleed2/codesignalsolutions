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

            Console.ReadKey();
        }

        public static void runRotateArray()
        {
            var arr = new int[] { 1,2 };
            var rotations = 3;
            arr = rotateArray(arr, rotations);
        }
        public static int[] rotateArray(int[] A, int K)
        {
            var length = A.Length;
            var B = new int[length];
            if (length == K) return A;
            if (length < K) K = K%length;
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
