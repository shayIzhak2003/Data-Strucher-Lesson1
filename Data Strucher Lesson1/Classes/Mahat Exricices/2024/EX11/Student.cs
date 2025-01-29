using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.EX11
{
    public class Student
    {

        public int ID { get; set; }
        public Node<Grade> Grades { get; set; }

        public Student(int id, Node<Grade> grades)
        {
            this.ID = id;
            this.Grades = grades;
        }

        public double GetHighestAverage()
        {
            
            double maxAvg = 0;
            Node<Grade> pos = Grades;
            while (pos != null)
            {
                Grade currntStudent = pos.GetValue();
                if (currntStudent.GetAverage() > maxAvg)
                {
                    maxAvg = currntStudent.GetAverage();
                }
                pos = pos.GetNext();
            }
            return maxAvg;
        }
        public override string ToString()
        {
            return $"Student ID: {this.ID}, Grades: {this.Grades.ToPrint()}";
        }

    }
    public class RunStudent
    {
        public static Student GetTopStudent(Node<Student> students)
        {
            Student topStudent = null;
            double highestAvg = 0;

            while (students != null)
            {
                double avg = students.GetValue().GetHighestAverage();
                if (avg > highestAvg)
                {
                    highestAvg = avg;
                    topStudent = students.GetValue();
                }
                students = students.GetNext();
            }

            return topStudent;
        }
        public static void DemoMain()
        {
            Node<Grade> grades1 = new Node<Grade>(new Grade("123",100, 90), new Node<Grade>(new Grade("1238", 100, 98)));
            Node<Grade> grades2 = new Node<Grade>(new Grade("1234", 75, 78), new Node<Grade>(new Grade("1237", 82, 79)));
            Node<Grade> grades3 = new Node<Grade>(new Grade("1235", 95, 94), new Node<Grade>(new Grade("1236", 90, 91)));

            Node<Student> students = new Node<Student>(new Student(101, grades1),
                new Node<Student>(new Student(102, grades2),
                new Node<Student>(new Student(103, grades3))));

            Student topStudent = GetTopStudent(students);
            Console.WriteLine("Top Student: " + topStudent);
        }
    }
}
