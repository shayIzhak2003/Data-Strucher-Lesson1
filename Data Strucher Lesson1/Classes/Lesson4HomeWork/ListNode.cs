using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson4HomeWork
{
    //EX2
    public class ListNode
    {
        public int value;
        public ListNode nextZero;

        public ListNode(int value)
        {
            this.value = value;
            this.nextZero = null;
        }
    }
    public class BinaryListOperations
    {
        public ListNode nextZero(ListNode lst, ListNode p)
        {
            ListNode current = p;
            while (current != null && current.value != 0)
            {
                current = current.nextZero;
            }
            return current?.nextZero;
        }

        public ListNode prevZero(ListNode lst, ListNode p)
        {
            ListNode prev = null;
            ListNode current = lst;

            while (current != null && current != p)
            {
                if (current.value == 0)
                {
                    prev = current;
                }
                current = current.nextZero;
            }

            return prev;
        }

        public int countZero(ListNode lst)
        {
            int count = 0;
            ListNode current = lst;

            while (current != null)
            {
                if (current.value == 0)
                {
                    count++;
                }
                current = current.nextZero;
            }

            return count;
        }

        // Example usage
        public static void DemoMain()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(0);
            ListNode node3 = new ListNode(1);
            ListNode node4 = new ListNode(0);
            ListNode node5 = new ListNode(1);

            node1.nextZero = node2;
            node2.nextZero = node3;
            node3.nextZero = null;
            node4.nextZero = node5;
            node5.nextZero = null;

            BinaryListOperations operations = new BinaryListOperations();

            Console.WriteLine("Next zero after node2: " + operations.nextZero(node1, node2)?.value); // Output: 1
            Console.WriteLine("Previous zero before node4: " + operations.prevZero(node1, node4)?.value); // Output: 0
            Console.WriteLine("Count of zeros in the list: " + operations.countZero(node1)); // Output: 2
        }
    }
}
