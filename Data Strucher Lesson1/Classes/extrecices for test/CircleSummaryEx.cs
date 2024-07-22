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
        //adding the sum of the to nodes in the bigginning of the list (in the first node)
        public static void AddSumInOfTheFirstNodes(Node<int> lst)
        {
            int s;
            Node<int> first = lst;
            Node<int> pos = lst;
            while (pos.GetNext() != lst)
            {
                pos = pos.GetNext();
            }
            s = pos.GetValue() + lst.GetValue();

            Node<int> newNode = new Node<int>(s, lst.GetNext());
            first.SetNext(newNode);
        }

        // making a function that gets a number and a list and put that number in the first place of the list (making hime the lst insted of pos)
        public static void AddNumberToTheList(Node<int> lst, int num)
        {
            Node<int> first = lst;
            Node<int> pos = lst;
            while (pos.GetNext() != lst)
            {
                pos = pos.GetNext();
            }

            Node<int> newNode = new Node<int>(num, lst.GetNext());
            first.SetNext(newNode);
        }

        public static void AddNumberToTheLast(Node<int> lst, int num)
        {
            if (lst == null)
            {
                throw new ArgumentException("The list cannot be null!");
            }

            Node<int> first = lst;
            Node<int> pos = lst;

            // Find the last node
            while (pos.GetNext() != lst)
            {
                pos = pos.GetNext();
            }

            // Create the new node
            Node<int> newNode = new Node<int>(num, first);

            // Make the last node point to the new node
            pos.SetNext(newNode);

            // Optionally, update the reference of the first node if needed
            // This is not strictly necessary for the list itself, but if you are keeping track of the first node outside this method, you might need to update it.
        }

        // making a function thats deleting a specipic node
        public static Node<int> DeleteNodeCircleChain(Node<int> lst, int num)
        {
            Node<int> prev = lst;

            if (lst.GetValue() == num)
            {
                while (prev.GetNext() != lst)
                {
                    prev = prev.GetNext();
                }

                prev.SetNext(lst.GetNext());
                lst.SetNext(null);
                lst = prev;
            }
            else
            {
                while (prev.GetNext().GetValue() != num)
                {
                    prev = prev.GetNext();
                }

                prev.SetNext(prev.GetNext().GetNext());
            }
            return lst;
        }
        //Sum of circle list function
        public static int SumOfList(Node<int> lst)
        {
            if (lst == null)
            {
                throw new ArgumentException("the list cannot be null it as to contain sunm value even 0!");
            }
            int sum = 0;
            Node<int> pos = lst;
            do
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            } while (pos != lst);
            return sum;
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
            //CircleSummaryEx.AddNumberToTheList(node1, 10);
            //CircleSummaryEx.DeleteNodeCircleChain(node1, 5);
            CircleSummaryEx.PrintCircleList(node1);
            int sum = CircleSummaryEx.SumOfList(node1);
            Console.WriteLine($"the sum of the list is {sum}");
        }
    }
}
