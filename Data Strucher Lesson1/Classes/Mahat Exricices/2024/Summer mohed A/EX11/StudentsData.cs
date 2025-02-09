using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.Summer_mohed_A.EX11
{
    public class StudentsData
    {
        public Queue<Student> studentsQueue;

        public StudentsData()
        {
            studentsQueue = new Queue<Student>();
        }

        // add student function
        public void AddStudent(Student student)
        {
            studentsQueue.Insert(student);
        }

        // remove student by id
        public void EraseStudent(string id)
        {
            Queue<Student> temp = new Queue<Student>();

            while (!studentsQueue.IsEmpty())
            {
                Student currentStudent = studentsQueue.Remove();

                string currentStudentId = currentStudent.GetId();
                if (currentStudentId != id)
                {
                    temp.Insert(currentStudent);
                }
            }

            while (!temp.IsEmpty())
                studentsQueue.Insert(temp.Remove());
        }

        public void Print(string city, string lang)
        {
            Queue<Student> temp = new Queue<Student>();
            int counter = 0;
            while (!studentsQueue.IsEmpty())
            {
                Student currentStudent = studentsQueue.Remove();
                temp.Insert(currentStudent);
                if (currentStudent.GetCity() == city && currentStudent.GetAdditionalLanguage()
                    == lang)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(currentStudent);
                    Console.ResetColor();
                }
                counter++;
            }
            if (counter == 0)
            {
                while (!temp.IsEmpty())
                {
                    Student currentStudent = temp.Remove();
                    studentsQueue.Insert(currentStudent);

                    if(currentStudent.HasCar() && currentStudent.GetAdditionalLanguage() 
                        == lang)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(currentStudent);
                        Console.ResetColor();
                    }
                }
            }
        }

        public int NumStudents(string city)
        {
            Queue<Student> temp = new Queue<Student>();
            int numOfStudentsInTheCityCounter = 0;

            while (!studentsQueue.IsEmpty())
            {
                Student currentStudent = studentsQueue.Remove();
                temp.Insert(currentStudent);

                if(currentStudent.GetCity() == city) 
                    numOfStudentsInTheCityCounter++;
            }
            while(!temp.IsEmpty())
            {
                studentsQueue.Insert(temp.Remove());
            }
            return numOfStudentsInTheCityCounter;
        }



    }
}
