using Data_Strucher_Lesson1.Classes.Lesson5;
using Data_Structure_Lesson1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson6
{
    public class CircularLinkedList
    {
        public static void SelectAndRemove(Node<int> list, int num)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List cannot be null.");
            }

            Node<int> current = list;
            Node<int> previous = null;

            while (true)
            {
                // Traverse to the node at the specified step
                for (int i = 0; i < num; i++)
                {
                    previous = current;
                    current = current.GetNext();
                }

                // Remove the current node
                if (current == previous) // If there is only one node left
                {
                    Console.WriteLine($"Removed value: {current.GetValue()}");
                    break;
                }

                previous.SetNext(current.GetNext());
                Console.WriteLine($"Removed value: {current.GetValue()}");

                // Use the value of the removed node as the next step count
                num = current.GetValue();

                // Update current to the next node
                current = current.GetNext();
            }
        }
    }

    public class RunCircularLinkedList
    {
        public static void DemoMain()
        {
            // Create nodes manually
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

            // Call SelectAndRemove method
            CircularLinkedList.SelectAndRemove(node1, 1);
        }
    }
}
