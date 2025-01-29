using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.EX11
{
    public class Grade
    {
        public string CourseCode { get; set; }  // קוד הקורס
        public int SemesterA { get; set; }      // ציון בסמסטר א'
        public int SemesterB { get; set; }      // ציון בסמסטר ב'

        public Grade(string courseCode, int semesterA, int semesterB)
        {
            CourseCode = courseCode;
            SemesterA = semesterA;
            SemesterB = semesterB;
        }

        public double GetAverage() => (SemesterA + SemesterB) / 2.0;

        public override string ToString()
        {
            return $"Semester1: {this.SemesterA}, Semester2: {this.SemesterB}, Average: {this.GetAverage()}";
        }
    }

}
