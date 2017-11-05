using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad04
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            int[] integers = new[] { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };
            //  strings [0] = "Broj 1 ponavlja  se 1 puta"
            //  strings [1] = "Broj 2 ponavlja  se 3 puta"
            //  strings [2] = "Broj 3 ponavlja  se 4 puta"
            //  strings [3] = "Broj 4 ponavlja  se 2 puta"
            //  strings [4] = "Broj 5 ponavlja  se 1 puta"
            string[] strings = HomeworkLinqQueries.Linq1(integers);
        }
    }
}
