using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSignal
{
    public class Tree<T>
    {
        public T value { get; set; }
        public Tree<T> left { get; set; }
        public Tree<T> right { get; set; }
    }

    
    class HasPathWithGivenSum
    {

        public static readonly Tree<int> t = new Tree<int>()
        {
            value = 4,
            left = new Tree<int>()
            {
                value = 1,
                left = new Tree<int>()
                {
                    value = -2,
                    left = null,
                    right = new Tree<int>()
                    {
                        value = 3,
                        left = null,
                        right = null
                    }
                },
                right = null
            },
            right = new Tree<int>()
            {
                value = 3,
                left = new Tree<int>()
                {
                    value = 1,
                    left = null,
                    right = null
                },
                right = new Tree<int>()
                {
                    value = 2,
                    left = new Tree<int>()
                    {
                        value = -2,
                        left = null,
                        right = null
                    },
                    right = new Tree<int>()
                    {
                        value = -3,
                        left = null,
                        right = null
                    }
                }
            }
        };

        static void Main(string[] args)
        {
            var tt = new Tree<int>()
            {
                value = 8,
                left = null,
                right = new Tree<int>()
                {
                    value = 3,
                    left = null,
                    right = null
                }
            };

            var a = hasPathWithGivenSum(t, 8);
            Console.ReadKey();
        }

        static bool hasPathWithGivenSum(Tree<int> t, int s)
        {
            var count = 0;
            hasPathWithGivenSumSupportive(t, s, ref count);
            return count > 1;
        }

        static bool hasPathWithGivenSumSupportive(Tree<int> t, int s, ref int count)
        {
            s -= t?.value ?? 0;
            if (t == null)
            {
                if (s == 0)
                {
                    count += 1;
                    return true;
                }
                return false;
            }
            return hasPathWithGivenSumSupportive(t?.left, s, ref count) || hasPathWithGivenSumSupportive(t?.right, s, ref count);
        }
    }
}
