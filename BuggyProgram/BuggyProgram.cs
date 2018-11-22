using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyProgram
{
    class BuggyProgram
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var numbers = new List<int> { 1, 2 }; //Bug 2: numbers count less than count 
            var smallests = GetSmallests(numbers, 3);
            //var smallests = GetSmallests(null, 3); //Bug 3: list null

            foreach (var num in smallests)
            {
                Console.WriteLine(num);
            }
        }

        public static List<int> GetSmallests(IList<int> list, int count) //Side-effect method on list
        {
            //if (list == null) //Bug 3: Solved
            //    throw new ArgumentNullException(nameof(list));
            //if (count > list.Count /*|| count <= 0*/) //Bug 2 and 2.5: Solve
            //    throw new ArgumentOutOfRangeException(nameof(count), "Count can not be greater than the number of elements of the list.");

            //var buffer = new List<int>(list); //remove side effect
            var smallests = new List<int>();

            while (smallests.Count < count)
            {
                var min = GetSmallest(list);
                //var min = GetSmallest(buffer);
                smallests.Add(min);
                list.Remove(min);
                //buffer.Remove(min);
            }

            return smallests;
        }

        private static int GetSmallest(IList<int> list)
        {
            var min = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > min) //Bug 1
                    min = list[i];
            }
            return min;
        }
    }
}
