using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            // the runtime function is O(N) Beacuse ther is N parts in the function
        }

        //EX2
        public static void Balance(Node<int> chain)
        {
            if (chain == null) return;

            int countZeros = 0, countPositives = 0, countNegatives = 0;
            Node<int> pos = chain;

            while (pos != null)
            {
                int currentValue = pos.GetValue();
                if (currentValue < 0)
                    countNegatives++;
                else if (currentValue > 0)
                    countPositives++;
                else
                    countZeros++;

                pos = pos.GetNext();
            }

            if (countPositives > 0 && countNegatives > 0 && countZeros > 0)
            {
                Console.WriteLine("The list is Balanced!");
                return;
            }

            Random rnd = new Random();
            Node<int> current = chain;

            while (current.GetNext() != null)
            {
                current = current.GetNext();
            }

            if (countZeros == 0)
            {
                current.SetNext(new Node<int>(0));
                current = current.GetNext();
            }
            if (countPositives == 0)
            {
                current.SetNext(new Node<int>(rnd.Next(1, 100)));
                current = current.GetNext();
            }
            if (countNegatives == 0)
            {
                current.SetNext(new Node<int>(rnd.Next(-100, 0)));
            }

            // O(N) 
            //O(N) הסבר: במקרה הגרוע ביותר, עלינו לעבור על כל הרשימה כדי להגיע לקשר האחרון ולהוסיף אליו אפס או מספר חיובי או שלילי. לכן, במקרה הגרוע, זמן הריצה הוא 

        }

        //EX5
        public static bool IsSuper(Node<int> n)
        {
            Node<int> prev = n;
            Node<int> current = n.GetNext();
            Node<int> next = n.GetNext().GetNext();

            while (prev.HasNext())
            {
                if (prev.GetValue() + current.GetValue()
                   >= next.GetValue())
                {
                    return false;
                }
                prev = current;
                current = next;
                next = next.GetNext();

            }
            return true;
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

            Node<int> head = new Node<int>(5);
            head.SetNext(new Node<int>(0));
            head.GetNext().SetNext(new Node<int>(2));

            // Call ArrangeData function
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(marks);
            Console.ResetColor();
            Queue<int> tests = MahatSummer2023.ArrangeData(marks);
            Console.WriteLine(tests);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(marks);
            Console.ResetColor();
            Console.WriteLine("==========");
            Console.WriteLine(head.ToPrint());
            MahatSummer2023.Balance(head);
            Console.WriteLine(head.ToPrint());

        }
    }
}