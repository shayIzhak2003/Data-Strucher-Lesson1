using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2023.EX6
{
    using System;

    namespace Data_Structure_Lesson1.Classes.Mahat_Exercises._2023.EX6
    {
        public class Head : Employee
        {
            private const int MAX_EMPLOYEE_COUNT = 20;
            private Employee[] arr;
            private int current;

            public Head(string name) : base(name)
            {
                this.arr = new Employee[MAX_EMPLOYEE_COUNT];
                this.current = 0; // Start at 0 since no employees are added yet
            }

            public void AddEmployee(Employee emp)
            {
                if (current >= MAX_EMPLOYEE_COUNT)
                    throw new Exception("You've reached max capacity!");

                arr[current++] = emp; // Add employee and increment current count
            }

            public Employee[] GetEmployees()
            {
                // Return only the filled part of the array
                Employee[] result = new Employee[current];
                Array.Copy(arr, result, current);
                return result;
            }

            public int GetCurrentCount()
            {
                return this.current;
            }
        }
    }

}
