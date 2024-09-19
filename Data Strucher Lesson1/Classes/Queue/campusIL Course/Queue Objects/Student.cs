using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue.campusIL_Course.Queue_Objects
{
    public class Student
    {
        private string IDnumber;      // תעודת זהות של התלמיד
        private int psychometric;     // ציון הפסיכומטרי של התלמיד
        private int grade899381;      // ציון במקצוע מסוים (למשל, קורס מסוים)

        // Constructor - קונסטרוקטור
        public Student(string idNumber, int psychometric, int grade899381)
        {
            this.IDnumber = idNumber;
            this.psychometric = psychometric;
            this.grade899381 = grade899381;
        }

        // Getter for IDnumber - פונקציית GET לתעודת זהות
        public string GetIDnumber()
        {
            return this.IDnumber;
        }

        // Setter for IDnumber - פונקציית SET לתעודת זהות
        public void SetIDnumber(string idNumber)
        {
            this.IDnumber = idNumber;
        }

        // Getter for psychometric - פונקציית GET לציון הפסיכומטרי
        public int GetPsychometric()
        {
            return this.psychometric;
        }

        // Setter for psychometric - פונקציית SET לציון הפסיכומטרי
        public void SetPsychometric(int psychometric)
        {
            this.psychometric = psychometric;
        }

        // Getter for grade899381 - פונקציית GET לציון במקצוע מסוים
        public int GetGrade899381()
        {
            return this.grade899381;
        }

        // Setter for grade899381 - פונקציית SET לציון במקצוע מסוים
        public void SetGrade899381(int grade899381)
        {
            this.grade899381 = grade899381;
        }
        // Override ToString to provide a concise description
        public override string ToString()
        {
            return $"ID: {IDnumber}, Psychometric: {psychometric}, Grade: {grade899381}";
        }
    }
    public class StudentFunctions
    {
        public static Queue<Student> WhoIsAccepted(Queue<Student> enrollees)
        {
            Queue<Student> queue = Chep1.CloneQueue(enrollees);
            Queue<Student> resultQueue = new Queue<Student>();
            int count = 0;
            while (!queue.IsEmpty())
            {
                Student value = queue.Remove();
                if (value.GetGrade899381() > 85 && value.GetPsychometric() > 650)
                {
                    resultQueue.Insert(value);
                    count++;
                }
                    
            }
            Console.WriteLine($"the amount of student are : {count}");
            return resultQueue;
        }

        // the main function
        public static void DemoMain()
        {
            Queue<Student> studentQueue = new Queue<Student>();

            // Creating 4 Student objects with sample data
            Student student1 = new Student("S001", 680, 85);
            Student student2 = new Student("S002", 720, 90);
            Student student3 = new Student("S003", 650, 80);
            Student student4 = new Student("S004", 690, 88);
            Student student5 = new Student("S004", 600, 88);

            // Inserting the Student objects into the queue
            studentQueue.Insert(student1);
            studentQueue.Insert(student2);
            studentQueue.Insert(student3);
            studentQueue.Insert(student4);
            studentQueue.Insert(student5);

            Console.WriteLine(StudentFunctions.WhoIsAccepted(studentQueue));
        }
    }

}
