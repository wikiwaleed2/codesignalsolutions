using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSignal
{
    class CodlilityLessonsMain
    {
        public static void main()
        {
            CodilityLessons.solution();
            var a = CodilityLessons.getRandomNumbersArray(10, 0, 10);
            var b = CodilityLessons.getRandomNumbersArray(10, 0, 1);
            a = new int[] { 5, 17, 0, 3 };
            //b = new int[] { 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, };
            CodilityLessons.printIntArray(a);
            //CodilityLessons.printIntArray(b);
            var result = CodilityLessons.maxdoubleSlice2(a);

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.Clear();
                a = CodilityLessons.getRandomNumbersArray(10, 0, 10);
                b = CodilityLessons.getRandomNumbersArray(10, 0, 1);
                a = new int[] { 5, 5, 5 };
                //b = new int[] { 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, };
                CodilityLessons.printIntArray(a);
                //CodilityLessons.printIntArray(b);
                result = CodilityLessons.maxdoubleSlice2(a);
                Console.WriteLine(result);
            }
            return;
        }
    }
}
