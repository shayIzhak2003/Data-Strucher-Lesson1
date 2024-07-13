using Data_Strucher_Lesson1.Classes.Lesson6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class EX5
    {
        public static Node<int> CircleToLinar(Node<int> head)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head), "Head cannot be null.");
            }

            Node<int> linearHead = new Node<int>(head.GetValue());
            Node<int> linearCurrent = linearHead;

            Node<int> current = head.GetNext();
            while (current != head)
            {

                // Create new node for linear linked list
                Node<int> newNode = new Node<int>(current.GetValue());

                // Link the new node to the linear linked list
                linearCurrent.SetNext(newNode);

                // Move to the next node in both lists
                linearCurrent = newNode;
                current = current.GetNext();
            }
            PrintList(linearHead);
            return linearHead;

        }
        private static void PrintList(Node<int> head)
        {
            Node<int> current = head;
            while (current != null)
            {
                Console.Write(current.GetValue() + " ");
                current = current.GetNext();
            }
            Console.WriteLine();
        }

    }
    public class RunEX5
    {
        public static void DemoMain()
        {
            // Create circular linked list manually
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);
            Node<int> node6 = new Node<int>(6);

            // Circular linking
            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node1);

            // Convert circular linked list to linear linked list and print it
            EX5.CircleToLinar(node1);
        }
    }
}
