using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson8
{
    public class Recorsia
    {
        public static void PrintList(Node<int> lst)
        {
            if(lst == null)
            {
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine(lst.GetValue());
                PrintList(lst.GetNext());
            }
        }
        public static int CountLower(Node<string> lst)
        {
            if( lst == null)
            {
                return 0;
            }
            if (lst.GetValue()[0] >='a' && lst.GetValue()[0] <= 'z')
            {
                return 1 + CountLower(lst.GetNext());
            }
            else
            {
                return CountLower(lst.GetNext());
            }
        }
        //public static void PrintListInDiffretDir(Node<int> lst)
        //{
        //    if (lst == null)
        //    {
        //        Console.WriteLine(" ");
        //    }
        //    else
        //    {
        //        PrintList(lst.GetNext());
        //        Console.WriteLine(lst.GetValue()); 
        //    }
        //}
        public static int CountList(Node<int> lst)
        {
            if(lst == null)
            {
                return 0;
            }
            return CountList(lst.GetNext()) + 1;
        }

        public static int SumList(Node<int> lst)
        {
            if (lst == null)
            {
                return 0;
            }
            return SumList(lst.GetNext()) + lst.GetValue();
        }
    }
    public class RunRecorsia
    {
        public static void DemoMain()
        {
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);

            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);

            // Create nodes for the circular linked list
            Node<string> stringNode1 = new Node<string>("Apple");
            Node<string> stringNode2 = new Node<string>("banana");
            Node<string> stringNode3 = new Node<string>("Cherry");
            Node<string> stringNode4 = new Node<string>("date");
            Node<string> stringNode5 = new Node<string>("Elderberry");

            // Set the next pointers to form a circular linked list
            stringNode1.SetNext(stringNode2);
            stringNode2.SetNext(stringNode3);
            stringNode3.SetNext(stringNode4);
            stringNode4.SetNext(stringNode5);

            Recorsia.PrintList(node1);
            //Recorsia.PrintListInDiffretDir(node1);
            Console.WriteLine($"the amount of nodes in the list is : {Recorsia.CountList(node1)}");
            Console.WriteLine($"the sum of the nodes in the list is : {Recorsia.SumList(node1)}");
            Console.WriteLine($"the amount of lowercase latters are : {Recorsia.CountLower(stringNode1)}");
        }
    }
}
