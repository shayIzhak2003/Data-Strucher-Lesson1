using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Guy
{
    public class IntNodeExGuy
    {
        //EX1 
        public static int Sum(IntNode lst)
        {
            int sum = 0;
            IntNode pos = lst;
            while(pos != null)
            {
                sum += pos.GetValue();
                pos = pos.GetNext(); // 1 --> 2 --> 3 --> 4 --> null 
            }
            return sum;
        }

        //EX2
        public static bool IsExsist(IntNode lst, int num)
        {
            IntNode pos = lst;
            while(pos != null)
            {
                if (pos.GetValue() == num)
                    return true;

                pos = pos.GetNext();
            }
            return false;
        }
        //EX3
        public static void EnterLast(IntNode lst, IntNode num)
        {
            if (lst == null)
            {
                // Optionally handle this case or throw an exception
                throw new ArgumentNullException(nameof(lst));
            }

            IntNode pos = lst;

            // Traverse until the last node (where GetNext() is null)
            while (pos.GetNext() != null)
            {
                pos = pos.GetNext();
            }

            // Set the new node as the next of the last node
            pos.setNext(num);
        }
        public static bool IsSerial(IntNode lst)
        {
            IntNode pos = lst;
            int diff = (pos.GetValue() - pos.GetNext().GetValue());
            while (pos.HasNext())
            {
                if(pos.GetValue() - pos.GetNext().GetValue() != diff)
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            return true;
           
        }

        public static IntNode RemovePos(IntNode lst, int num)
        {
            IntNode pos = lst;
            int index = 1;
            while (pos != null && pos.GetNext() != null)
            {
               
                if (num == index)
                {
                    // זה צורת המחיקה
                    pos.setNext(pos.GetNext().GetNext());
                }
                // 1--->3-->4
                index++;
                pos = pos.GetNext();
            }
            return pos;
        }


        public static void DemoMain()
        {
            IntNode node1 = new IntNode(2);
            IntNode node2 = new IntNode(6);
            IntNode node3 = new IntNode(9);
            IntNode node4 = new IntNode(12);
            IntNode node5 = new IntNode(15);
            IntNode node6 = new IntNode(18);

            IntNode newNode = new IntNode(7);

            node1.setNext(node2);
            node2.setNext(node3);
            node3.setNext(node4);
            node4.setNext(node5);
            node5.setNext(node6);

            IntNode.print(node1);
            int sum = Sum(node1);
            bool IsExistVal = IsExsist(node1, 5);
            Console.WriteLine($"the sum of the list is: {sum}");
            Console.WriteLine($"dos 5 is in the list? {IsExistVal}");
            //EnterLast(node1, newNode);
            //IntNode.print(node1);

            //bool isSerial = IsSerial(node1);
            //Console.WriteLine(isSerial);

            Console.WriteLine(RemovePos(node1, 2));
            IntNode.print(node1);
        }
    }
}
