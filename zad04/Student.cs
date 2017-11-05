using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad04
{
    /// <summary>
    /// Description of Student.
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }


        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (!(obj is Student)) return false;

            Student s = (Student)obj;

            return s.Jmbag.Equals(this.Jmbag);
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        public static bool operator ==(Student s1, Student s2)
        {
            if (Object.ReferenceEquals(s1, null))
                return object.ReferenceEquals(s2, null);

            return s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
