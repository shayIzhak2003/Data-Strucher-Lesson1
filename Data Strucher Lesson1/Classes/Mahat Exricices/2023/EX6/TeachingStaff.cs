using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2023.EX6
{
    public class TeachingStaff
    {
        private const int MAX_EMPLOYEE_COUNT = 200; // Maximum employees allowed
        private Employee[] arr; // Array to store employees
        private int current; // Number of employees currently added

        public TeachingStaff()
        {
            this.arr = new Employee[MAX_EMPLOYEE_COUNT];
            this.current = 0; // Start with zero employees
        }

        public void AddEmployee(Employee emp)
        {
            if (current >= MAX_EMPLOYEE_COUNT)
                throw new Exception("You've reached the maximum number of employees!");

            arr[current++] = emp; // Add employee and increase count
        }

        public Employee[] GetEmployees()
        {
            Employee[] result = new Employee[current]; // Create a new array with current employees
            Array.Copy(arr, result, current); // Copy only the filled elements
            return result;
        }

        public int GetCurrentCount()
        {
            return current;
        }

        public int NumHeads()
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is Tutor)
                    count++;
            }
            return count;
        }
        public Tutor GetNewTutor(int courseNum)
        {
            for (int i = 0; i < current; i++) 
            {
                if (arr[i] is Tutor tutor && tutor.courseNum == courseNum) 
                {
                    return tutor;
                }
            }
            return null;
        }

    }
}
