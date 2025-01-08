using Data_Strucher_Lesson1.Classes.Mahat_Exricices.MtEx3;
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

        //EX2 pt.1
        public static int NumDigits(Node<int> lst)
        {
            int count = 0;
            Node<int> pos = lst;
            while (pos != null)
            {
                pos = pos.GetNext();
                count++;
            }
            return count;
        }

        //EX2 pt.2
        public static int Compare(Node<int> n1, Node<int> n2)
        {
            Node<int> pos1 = n1;
            Node<int> pos2 = n2;

            int length1 = NumDigits(n1);
            int length2 = NumDigits(n2);


            if (length1 > length2)
            {
                return 1;
            }

            if (length1 < length2)
            {
                return 2;
            }

            while (pos1 != null && pos2 != null)
            {
                if(pos1.GetValue() > pos2.GetValue())
                {
                    return 1;
                }

                if(pos1.GetValue() < pos2.GetValue())
                {
                    return 2;
                }

                pos1 = pos1.GetNext();
                pos2 = pos2.GetNext();
            }
            return 0;
        }
        //EX2 Pt.3 : the runtime function is O(N)!

        //EX3
        // the Demi Main function is in the DemoMain below

        //EX4
        //..... do it later 

        //EX5

        
        

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

            Node<int> n1 = new Node<int>(2);
            Node<int> node1_2 = new Node<int>(3);
            Node<int> node1_3 = new Node<int>(2);
            Node<int> node1_4 = new Node<int>(1);
            Node<int> node1_5 = new Node<int>(4);
            Node<int> node1_6 = new Node<int>(1);
            Node<int> node1_7 = new Node<int>(8);

            n1.SetNext(node1_2);
            node1_2.SetNext(node1_3);
            node1_3.SetNext(node1_4);
            node1_4.SetNext(node1_5);
            node1_5.SetNext(node1_6);
            node1_6.SetNext(node1_7);

            // Create the second number: 1 -> 3 -> 9 -> 5
            Node<int> n2 = new Node<int>(1);
            Node<int> node2_2 = new Node<int>(3);
            Node<int> node2_3 = new Node<int>(9);
            Node<int> node2_4 = new Node<int>(5);

            n2.SetNext(node2_2);
            node2_2.SetNext(node2_3);
            node2_3.SetNext(node2_4);


            // Calculate averages
            Queue<int> averages = MtEx2.AverageQueue(marks, tests);
            Console.WriteLine(averages);
            Console.WriteLine(MtEx2.NumDigits(n1));
            Console.WriteLine(MtEx2.Compare(n1,n2));

            //EX3
            RunFruitAndAppleApp.DemoMain();
        }
    }

}
