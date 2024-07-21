using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class CircleSummaryEx
    {
        // printing the circle list!
        public static void PrintCircleList(Node<int> lst)
        {
            Node<int> pos = lst;
            do
            {
                Console.Write(pos.GetValue() + " ");
                pos = pos.GetNext();
            } while (pos != lst);
            Console.WriteLine();
        }
        // adding the sum of two node in the list
        public static void AddingSumToList(Node<int> lst)
        {
            int s;
            Node<int> first = lst;
            Node<int> pos = lst.GetNext();
            while (pos != lst)
            {
                s = first.GetValue() + pos.GetValue();

                first.SetNext(new Node<int>(s, pos));

                first = pos;

                pos = pos.GetNext();
            }
            s = first.GetValue() + pos.GetValue();

            first.SetNext(new Node<int>(s, pos));
        }
    }
    public class RunCircleSummaryEx
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

            CircleSummaryEx.PrintCircleList(node1);
        }
    }
}
