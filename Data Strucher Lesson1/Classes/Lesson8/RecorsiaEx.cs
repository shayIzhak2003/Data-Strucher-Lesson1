using Data_Strucher_Lesson1.Classes.extrecices_for_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_Strucher_Lesson1.Classes.Lesson8
{
    public class RecorsiaEx
    {
        public static int sod1(Node<int> pos)
        {
            // If this is the last node, the length of the sequence is 1
            if (pos.GetNext() == null)
                return 1;

            // If the next value is greater than or equal to the current value,
            // continue to the next node and add 1 to the sequence length
            if (pos.GetNext().GetValue() >= pos.GetValue())
                return sod1(pos.GetNext()) + 1;
            else
                // Otherwise, the sequence length is 1
                return 1;
        }

        public static int sod(int num)
        {
            // Base case: if the number is a single digit, return it
            if (num < 10)
                return num;

            // Recursive case
            int temp = sod(num / 10); // Recursively find the smallest digit in the quotient
            int digit = num % 10;     // Get the current last digit

            // Return the smaller of the last digit and the smallest digit found so far
            if (digit < temp)
                return digit;
            else
                return temp;
        }



        public bool Mystery(Node<int> lst1, Node<int> lst2)
        {
            Node<int> p1 = lst1;
            Node<int> p2;
            bool flag = true;

            while (p1 != null && flag)
            {
                p2 = lst2;

                while (p2 != null && flag)
                {
                    int x = p1.GetValue();
                    int y = p2.GetValue();

                    if (x == y)
                    {
                        flag = false;
                    }

                    p2 = p2.GetNext();
                }

                p1 = p1.GetNext();
            }

            return flag;
        }
    }
    public class RunRecorsiaEx
    {
        public static void DemoMain()
        {
            // Original test case
            Node<int> originalNode1 = new Node<int>(3);
            Node<int> originalNode2 = new Node<int>(5);
            Node<int> originalNode3 = new Node<int>(2);

            originalNode1.SetNext(originalNode2);
            originalNode2.SetNext(originalNode3);

            Node<int> originalNode4 = new Node<int>(1);
            Node<int> originalNode5 = new Node<int>(2);
            Node<int> originalNode6 = new Node<int>(4);

            originalNode4.SetNext(originalNode5);
            originalNode5.SetNext(originalNode6);

            RecorsiaEx recorsiaEx = new RecorsiaEx();
            Console.WriteLine("Original Test Case:");
            Console.WriteLine(recorsiaEx.Mystery(originalNode1, originalNode4)); // Expected output: False

            // New test case
            Node<int> newNode1 = new Node<int>(7);
            Node<int> newNode2 = new Node<int>(4);
            Node<int> newNode3 = new Node<int>(8);

            newNode1.SetNext(newNode2);
            newNode2.SetNext(newNode3);

            Node<int> newNode4 = new Node<int>(1);
            Node<int> newNode5 = new Node<int>(3);
            Node<int> newNode6 = new Node<int>(9);
            Node<int> newNode7 = new Node<int>(5);

            newNode4.SetNext(newNode5);
            newNode5.SetNext(newNode6);
            newNode6.SetNext(newNode7);

            Console.WriteLine("New Test Case:");
            Console.WriteLine(recorsiaEx.Mystery(newNode1, newNode4)); // Expected output: False



            Node<int> node1 = new Node<int>(5);
            Node<int> node2 = new Node<int>(1);
            Node<int> node3 = new Node<int>(10);
            Node<int> node4 = new Node<int>(11);
            Node<int> node5 = new Node<int>(13);
            Node<int> node6 = new Node<int>(7);
            Node<int> node7 = new Node<int>(8);
            Node<int> node8 = new Node<int>(12);

            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node7);
            node7.SetNext(node8);
            Console.WriteLine(RecorsiaEx.sod1(node1.GetNext()));
            Console.WriteLine(RecorsiaEx.sod(19));
        }
    }
}
