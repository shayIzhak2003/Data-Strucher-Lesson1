using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2023
{
    public class MahatSummer2023
    {
        //EX1
        public static Queue<int> ArrangeData(Queue<int> marks)
        {
            Queue<int> testCount = new Queue<int>();
            Queue<int> tempMarks = new Queue<int>();
            int countMarks = 0;
            while (!marks.IsEmpty())
            {
                int currentMark = marks.Remove();
                if (currentMark != -1)
                {
                    countMarks++;
                    tempMarks.Insert(currentMark);
                }
                else
                {
                    testCount.Insert(countMarks);
                    countMarks = 0;
                }
            }
            while (!tempMarks.IsEmpty())
            {
                marks.Insert(tempMarks.Remove());
            }

            return testCount;
        }
    }

    public class RunMahatSummer2023
    {
        public static void DemoMain()
        {
            Queue<int> marks = new Queue<int>();
            int[] scores = { 80, 90, 100, -1, 75, 96, -1, 100, 100, 97, 96, -1, -1, 88, 94, -1 };

            foreach (int score in scores)
            {
                marks.Insert(score);
            }

            // Call ArrangeData function
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(marks);
            Console.ResetColor();
            Queue<int> tests = MahatSummer2023.ArrangeData(marks);
            Console.WriteLine(tests);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(marks);
            Console.ResetColor();

        }
    }
}