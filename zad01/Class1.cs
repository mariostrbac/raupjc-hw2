using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad01
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            Case1();
            Case2();
            Case3();

            Console.WriteLine("Press any key to continue.");
        }

        public static void Case1()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };

            var ivan = new Student("Ivan", jmbag: "001234567");

            bool isIvanTopStudent = topStudents.Contains(ivan);
            //false :(
            Console.WriteLine(isIvanTopStudent);
        }

        public static void Case2()
        {
            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Ivan", jmbag: "001234567")
            };

            // 2 :(
            var distinctStudentCount = list.Distinct().Count();

            Console.WriteLine(distinctStudentCount);
        }

        public static void Case3()
        {
            var topStudents = new List<Student>()
            {
                new Student(" Ivan ", jmbag: " 001234567 "),
                new Student(" Luka ", jmbag: " 3274272 "),
                new Student("Ana", jmbag: " 9382832 ")
            };

            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");

            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);

            Console.WriteLine(isIvanTopStudent);
        }
    }


}
