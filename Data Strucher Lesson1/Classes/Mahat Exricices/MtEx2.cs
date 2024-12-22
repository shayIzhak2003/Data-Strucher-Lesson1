using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices
{
    //NOTES
    // the clone queue function in the QEX > EX(Folder)

    public class MtEx2
    {
        //EX1
        public static Queue<int> AverageQueue(Queue<int> marks, Queue<int> tests)
        {
            Queue<int> avarage = new Queue<int>();
            int avg, sum = 0;

            while (!tests.IsEmpty())
            {
                sum = 0;
                int currentTestAmount = tests.Remove();
                for (int i = 0; i < currentTestAmount; i++)
                {
                    int currentMark = marks.Remove();
                    sum += currentMark;
                }
                avg = sum / currentTestAmount;
                avarage.Insert(avg);
            }
            return avarage;

        }

        //EX Pt.2 : the runtime function is O(N)!

        //EX2

    }
    public class RunMtEx2
    {
        public static void DemoMain()
        {
            // Initialize the marks queue
            Queue<int> marks = new Queue<int>();
            marks.Insert(85); // Test 1: 85, 90
            marks.Insert(90);
            marks.Insert(78); // Test 2: 78, 88, 92
            marks.Insert(88);
            marks.Insert(92);

            // Initialize the tests queue
            Queue<int> tests = new Queue<int>();
            tests.Insert(2); // First test group has 2 marks
            tests.Insert(3); // Second test group has 3 marks

            // Calculate averages
            Queue<int> averages = MtEx2.AverageQueue(marks, tests);
            Console.WriteLine(averages);
        }
    }

}
