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

        //EX5 PT.1

        public static bool IsSuper(Node<int> n)
        {
            if (n == null || n.GetNext() == null || n.GetNext().GetNext() == null)
                return true; // Not enough elements to violate the rule

            Node<int> prev = n;
            Node<int> current = n.GetNext();
            Node<int> next = current.GetNext();

            while (next != null) // Ensure next is not null before accessing it
            {
                if (prev.GetValue() + current.GetValue() >= next.GetValue())
                {
                    return false;
                }

                prev = current;
                current = next;
                next = next.GetNext(); // Move to the next node
            }

            return true;
        }


        //EX5 PT.2
        public static bool CanBeAddedToSuper(Node<int> n, int num)
        {
            if (n == null)
                return false; // Can't insert into an empty list

            Node<int> prev = null;
            Node<int> current = n;

            // Find the correct position to insert num while keeping the list sorted
            while (current != null && num > current.GetValue())
            {
                prev = current;
                current = current.GetNext();
            }

            // Create a new node with the given number
            Node<int> newNode = new Node<int>(num);

            // Insert num in the found position
            if (prev != null)
                prev.SetNext(newNode);
            newNode.SetNext(current);

            // Check if the updated list is still a super list
            bool isStillSuper = IsSuper(n);

            // If the list is not super, revert the changes and return false
            if (!isStillSuper)
            {
                if (prev != null)
                    prev.SetNext(current); // Remove newNode from the list
                return false;
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
            head.SetNext(new Node<int>(2));
            head.GetNext().SetNext(new Node<int>(8));
       

            // Call ArrangeData function
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(marks);
            //Console.ResetColor();
            //Queue<int> tests = MahatSummer2023.ArrangeData(marks);
            //Console.WriteLine(tests);
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(marks);
            //Console.ResetColor();
            //Console.WriteLine("==========");
            //Console.WriteLine(head.ToPrint());
            //MahatSummer2023.Balance(head);
            //Console.WriteLine(head.ToPrint());
            Console.WriteLine("======");
            Console.WriteLine(head.ToPrint());
            Console.WriteLine(MahatSummer2023.IsSuper(head));
            Console.WriteLine(MahatSummer2023.CanBeAddedToSuper( head, 13));
            Console.WriteLine(head.ToPrint());

        }
    }
}