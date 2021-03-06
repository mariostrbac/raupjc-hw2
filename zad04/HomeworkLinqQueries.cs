﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad04
{
    /// <summary>
    /// Description of HomeworkLinqQueries.
    /// </summary>
    public class HomeworkLinqQueries
    {
        public static string [] Linq1 (int [] intArray )
        {
            IEnumerable<string> query = intArray.GroupBy(i => i).Select(t => new string[2]
                {
                    t.Key.ToString(),
                    t.Count().ToString() 
                })
                .OrderByDescending(br => br[0]).Select(i => "Broj " + i[0] + " ponavlja se " + i[1] + " puta").Reverse();

            return query.ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            var universityMan = universityArray.Where(uni => uni.Students.All(student => student.Gender == Gender.Male));
            return universityMan.ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {

            float avg = universityArray.Select(t => new object[2]
            {
                t.Name,
                t.Students.Length
            }).Average(x => float.Parse(x[1].ToString()));

            return universityArray.Where(t => t.Students.Length < avg).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(t => t.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            var allManUni = Linq2_1(universityArray);
            var allWomanUni = universityArray.Where(uni => uni.Students.All(student => student.Gender == Gender.Female));

            var all = allManUni.Union(allWomanUni);
            return Linq2_3(all.ToArray());
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            var jmbags = universityArray.SelectMany(t => t.Students).GroupBy(x => x.Jmbag).Select(x => new 
            {
                x.Key,
                Count = x.Count()
            }).Where(t => (int)t.Count > 1).Select(i => i.Key).ToList();

            return Linq2_3(universityArray).Where(s => jmbags.Contains(s.Jmbag)).ToArray();
        }
    }
}
