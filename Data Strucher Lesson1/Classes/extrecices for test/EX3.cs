using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class CheckCircle
    {
        public static void Rotate(Node<int> head)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head), "Head cannot be null.");
            }

            Node<int> start = head;
            Node<int> current = head;
            bool flag = true;

            while(current!=head || flag)
            {
                flag = false;
                PrintRotationForEX3(start);

                // Move to the next node for the next rotation
                start = start.GetNext();
                current = start;
            }
            Console.WriteLine("\nend of this quation!");


        }
        public static void PrintRotationForEX3(Node<int> start)
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
    public class ConvertToLinar
    {
        public static Node<int> ConvertCircle(Node<int> head)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head), "Head cannot be null.");
            }
            // Create a new head for the linear list
            Node<int> linearHead = new Node<int>(head.GetValue());
            Node<int> currentLinear = linearHead;
            Node<int> currentCircular = head.GetNext();

            // Traverse the circular list and create new nodes in the linear list
            while (currentCircular != head)
            {
                Node<int> newNode = new Node<int>(currentCircular.GetValue());
                currentLinear.SetNext(newNode);
                currentLinear = newNode;
                currentCircular = currentCircular.GetNext();
            }
            PrintForEX3(linearHead);
            return linearHead;
        }
        public static void PrintForEX3(Node<int> head)
        {
            Node<int> pos = head;
            while(pos != null)
            {
                Console.Write(pos.GetValue());
                pos = pos.GetNext();
            }
            Console.WriteLine("\nend of this quation!");
        }
    }
    public class RemoveFromList 
    { 

    }

    public class EX3
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

            // call the function
            //EX2
            CheckCircle.Rotate(node1);
            //call the convartion To linar
            //EX3
            ConvertToLinar.ConvertCircle(node1);
        }
    }
}
