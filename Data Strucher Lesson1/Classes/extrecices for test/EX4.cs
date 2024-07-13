using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class EX4
    {

        public static void PrintCircularList(Node<int> lst)
        {
            Node<int> current = lst;
            Node<int> start = lst;
            Console.Write("Circular list: ");
            do
            {
                Console.Write(current.GetValue() + " ");
                current = current.GetNext();
            } while (current != start);
            Console.WriteLine();
        }
        // ex1
        public static void AddToCircleChain(Node<int> lst)
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
        //ex2
        public static Node<int> AddFirst(Node<int> lst, int num)
        {
            Node<int> last = lst;
            while(last != lst)
            {
                last = last.GetNext();
            }
            lst = new Node<int>(num, lst);
            last.SetNext(lst);
            return lst;
        }
        //ex3
        public static Node<int> DeleteNodeCircleChain(Node<int> lst, int num)
        {
            Node<int> prev = lst;
            if(lst.GetValue() == num)
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
                    prev.GetNext();
                }
                prev.SetNext(prev.GetNext().GetNext());
            }
            return lst;
        }
    }
    
    public class RunEX4 
    {
        public static void DemoMain()
        {
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);
            Node<int> node6 = new Node<int>(6);

            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node1);

            //quaostion1
            //Console.WriteLine("\nthe list before adding values to the chain:");
            //EX4.PrintCircularList(node1);
            //EX4.AddToCircleChain(node1);

            //Console.WriteLine("\nthe list after adding values to the chain:");
            //EX4.PrintCircularList(node1);

            //quaostion2
            //Console.WriteLine("\nthe list before adding values to the chain:");
            //EX4.PrintCircularList(node1);
            //Console.WriteLine("\nthe list after adding values to the chain:");
            //EX4.AddFirst(node1, 4);
            //EX4.PrintCircularList(node1);

            //quaostion3
            Console.WriteLine("\nthe list before adding values to the chain:");
            EX4.PrintCircularList(node1);
            EX4.DeleteNodeCircleChain(node1, 2);
            Console.WriteLine("\nthe list after adding values to the chain:");
            EX4.PrintCircularList(node1);



        }
    }

}
