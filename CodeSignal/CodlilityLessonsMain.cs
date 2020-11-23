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
            var a = CodilityLessons.getRandomNumbersArray(10, 0, 10);
            var b = CodilityLessons.getRandomNumbersArray(10, 0, 1);
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.Clear();
                a = CodilityLessons.getRandomNumbersArray(10, 0, 10);
                b = CodilityLessons.getRandomNumbersArray(10, 0, 1);
                //a = new int[] { 7, 5, 8, 9, 0, 2, 1, 0, 4, 7, };
                //b = new int[] { 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, };
                CodilityLessons.printIntArray(a);
                CodilityLessons.printIntArray(b);
                var result = CodilityLessons.sample2(a);
                Console.WriteLine(result);
            }
            return;
        }
    }
}
