using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson4HomeWork
{
 // ZeroLinkedList operations
    public class ZeroLinkedList
    {
        // Returns the first node after 'p' where the value is 0, or null if no such node exists
        public Node<int> NextZero(Node<int> head, Node<int> p)
        {
            if (head == null || p == null)
                return null;

            Node<int> current = p.GetNext();
            while (current != null)
            {
                if (current.GetValue() == 0)
                    return current;
                current = current.GetNext();
            }
            return null;
        }

        // Returns the first node before 'p' where the value is 0, or null if no such node exists
        public Node<int> PrevZero(Node<int> head, Node<int> p)
        {
            if (head == null || p == null)
                return null;

            Node<int> current = head;
            Node<int> prevZero = null;

            while (current != p)
            {
                if (current.GetValue() == 0)
                    prevZero = current;
                current = current.GetNext();
            }

            return prevZero;
        }

        // Counts the number of nodes with the value 0 in the list
        public int CountZero(Node<int> head)
        {
            int count = 0;
            Node<int> current = head;

            while (current != null)
            {
                if (current.GetValue() == 0)
                    count++;
                current = current.GetNext();
            }
            return count;
        }
    }

    // RunZeroLinkedList class to demonstrate the functions
    public class RunZeroLinkedList
    {
        public static void DemoMain()
        {
            // Create a linked list: 1 -> 0 -> 1 -> 0 -> 0 -> 1 -> null
            Node<int> head = new Node<int>(1);
            Node<int> node2 = new Node<int>(0);
            Node<int> node3 = new Node<int>(1);
            Node<int> node4 = new Node<int>(0);
            Node<int> node5 = new Node<int>(0);
            Node<int> node6 = new Node<int>(1);

            head.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);

            // Create an instance of ZeroLinkedList
            ZeroLinkedList zeroLinkedList = new ZeroLinkedList();

            // Demonstrate the NextZero function
            Node<int> nextZero = zeroLinkedList.NextZero(head, node2);
            Console.WriteLine($"The next zero after node2 is: {nextZero?.GetValue()}");

            // Demonstrate the PrevZero function
            Node<int> prevZero = zeroLinkedList.PrevZero(head, node4);
            Console.WriteLine($"The previous zero before node4 is: {prevZero?.GetValue()}");

            // Demonstrate the CountZero function
            int zeroCount = zeroLinkedList.CountZero(head);
            Console.WriteLine($"The number of zeros in the list is: {zeroCount}");
        }
    }

}
