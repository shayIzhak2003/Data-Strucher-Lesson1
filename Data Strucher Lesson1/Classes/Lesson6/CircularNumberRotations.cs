using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson6
{
    public class CircularNumberRotations
    {
        public static void PrintAllRotations(Node<int> head)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head), "Head cannot be null.");
            }

            Node<int> start = head;
            Node<int> current = head;
            bool isFirst = true; // Flag to check the first iteration

            while (current != head || isFirst)
            {
                isFirst = false; // Set flag to false after the first iteration
                PrintRotation(start);

                // Move to the next node for the next rotation
                start = start.GetNext();
                current = start;
            }
        }

        public static void PrintRotation(Node<int> start)
        {
            Node<int> current = start;
            while (true)
            {
                Console.Write(current.GetValue());
                current = current.GetNext();
                if (current == start)
                    break;
            }
            Console.WriteLine();
        }
    }

    public class RunCircularNumberRotations
    {
        public static void DemoMain()
        {
            // Create circular linked list manually representing number 1234
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);

            // Circular linking
            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node1);

            // Print all rotations of the number
            CircularNumberRotations.PrintAllRotations(node1);
        }
    }
}

