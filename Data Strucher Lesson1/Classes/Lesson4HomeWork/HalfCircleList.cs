using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson4HomeWork
{
    //EX3
    public class HalfCircleList
    {
        public Node<T> FindLastPointerNode<T>(Node<T> head)
        {
            if (head == null || head.GetNext() == null)
                return null;

            Node<T> tortoise = head.GetNext();
            Node<T> hare = head.GetNext().GetNext();

            // Phase 1: Detecting the cycle
            while (hare != null && hare.GetNext() != null)
            {
                if (tortoise == hare)
                    break;

                tortoise = tortoise.GetNext();
                hare = hare.GetNext().GetNext();
            }

            // If no cycle found
            if (hare == null || hare.GetNext() == null)
                return null;

            // Phase 2: Finding the start of the cycle
            tortoise = head;
            while (tortoise != hare)
            {
                tortoise = tortoise.GetNext();
                hare = hare.GetNext();
            }

            // Now tortoise points to the start of the cycle
            return tortoise;
        }
    }

    // Define the RunHalfCircleList class with DemoMain method
    public class RunHalfCircleList
    {
        public static void DemoMain()
        {
            // Creating a half-circle linked list with integers
            Node<int> head = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);
            Node<int> node6 = new Node<int>(6);

            head.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node3); // Creating the half-circle

            // Create an instance of HalfCircleList
            HalfCircleList halfCircleList = new HalfCircleList();

            // Find the node where the last pointer points to
            Node<int> lastPointerNode = halfCircleList.FindLastPointerNode(head);

            if (lastPointerNode != null)
            {
                Console.WriteLine($"The node where the last pointer points to has value: {lastPointerNode.GetValue()}");
            }
            else
            {
                Console.WriteLine("No cycle found or empty list.");
            }
        }
    }


}
