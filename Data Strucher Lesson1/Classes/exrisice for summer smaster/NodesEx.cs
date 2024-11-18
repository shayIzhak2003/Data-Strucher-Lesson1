using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.exrisice_for_summer_smaster
{
    public class NodesEx
    {
        // EX1
        public static int Sum(IntNode lst)
        {
            int sum = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                sum += pos.GetValue();

                pos = pos.GetNext();
            }
            return sum;
        }
        //EX2
        public static bool IsExist(IntNode lst, int num)
        {
            IntNode pos = lst; // Start at the head of the list
            while (pos != null)
            {
                int currentValue = pos.GetValue();
                if (currentValue == num)
                {
                    return true; // The number is found
                }
                pos = pos.GetNext(); // Move to the next node
            }
            return false; // The number is not in the list
        }
        //EX3
        public static void EnterLast(IntNode lst, int num)
        {
            IntNode pos = lst;
            while (pos.HasNext())
            {
                pos = pos.GetNext();
            }
            pos.SetValue(num);
        }
        //EX4
        public static void EnterSecond(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                if (count == 2)
                {
                    pos.SetValue(num);
                }

                pos = pos.GetNext();
            }
        }
        //EX5
        public static int Size(IntNode lst)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                while (pos != null)
                {
                    pos = pos.GetNext();
                    count++;
                }
            }
            return count;
        }
        //EX6
        public static int HowMany(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                int currentValue = pos.GetValue();
                if (currentValue == num)
                {
                    count++;
                }
                pos = pos.GetNext();
            }
            return count;
        }
        //EX7
        public static bool InOrder(IntNode lst)
        {
            IntNode pos = lst;
            while (pos.HasNext())
            {
                if (pos.GetValue() >= pos.GetNext().GetValue())
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            return true;
        }
        //EX8
        public static int SumOdd(IntNode lst)
        {
            IntNode pos = lst;
            int count = 0;
            int sum = 0;
            while (pos != null)
            {
                count++;
                int currentValue = pos.GetValue();
                if (count % 2 != 0)
                {
                    sum += currentValue;
                }
                pos = pos.GetNext();
            }
            return sum;
        }
        //EX9
        public static void EnterInOrder(IntNode lst, int num)
        {
            IntNode newNode = new IntNode(num);

            if (lst == null || lst.GetValue() >= num)
            {
                newNode.setNext(lst);
                lst = newNode;
                return;
            }


            IntNode current = lst;
            while (current.HasNext() && current.GetNext().GetValue() < num)
            {
                current = current.GetNext();
            }

            newNode.setNext(current.GetNext());
            current.setNext(newNode);
        }
        //EX10
        public static bool IsSerial(IntNode lst)
        {
            IntNode pos = lst;
            int diff = pos.GetValue() - pos.GetNext().GetValue();
            while (pos.HasNext())
            {
                if ((diff != pos.GetValue() - pos.GetNext().GetValue()))
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            return true;
        }
        //EX11
        public static IntNode RemovePos(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                if (count == num)
                {
                    pos.setNext(pos.GetNext().GetNext());
                }
                pos = pos.GetNext();
            }
            return pos;

        }
        //EX12
        public static int ReturnAtPos(IntNode lst, int step)
        {
            IntNode pos = lst;
            int count = 0;
            int valueToReturn = 0;
            while (pos != null)
            {
                count++;
                if (count == step)
                {
                    valueToReturn = pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return valueToReturn;
        }
        //EX13
        public static object ReturnNum(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            object ToReturn = null;
            while (pos != null)
            {
                int currentValue = pos.GetValue();
                if (currentValue == num)
                {
                    ToReturn = currentValue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"this is on index :=> {count}");
                    Console.ResetColor();
                    return ToReturn;
                }
                count++;
                pos = pos.GetNext();
            }
            if (ToReturn == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("value not found!");
                Console.ResetColor();
            }
            return ToReturn;
        }
        //EX14
        public static int Max(IntNode lst)
        {
            IntNode pos = lst;
            int maxNodeValue = 0;
            int index = 0;
            int finalIndex = 0;
            while (pos != null)
            {
                int currentValue = (int)pos.GetValue();
                if (currentValue > maxNodeValue)
                {
                    maxNodeValue = currentValue;
                    finalIndex = index;
                }
                index++;
                pos = pos.GetNext();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"in index :=> {finalIndex}");
            Console.ResetColor();
            return maxNodeValue;
        }
        //EX15
        public static IntNode Prev(IntNode lst, IntNode target)
        {
            if (lst == null || target == null)
            {
                // If the list is empty or the target node is null, there's no previous node.
                return null;
            }

            IntNode pos = lst;
            IntNode prev = null; // Keeps track of the previous node.

            while (pos != null)
            {
                if (pos.Equals(target))
                {
                    // Found the target node; return the previous node.
                    return prev;
                }

                // Update `prev` to the current node before moving to the next.
                prev = pos;
                pos = pos.GetNext();
            }

            // If the loop completes, the target node is not in the list.
            return null;
        }


    }
    public class RunNodesEx
    {
        public static void DemoMain()
        {
            IntNode node1 = new IntNode(1);
            IntNode node2 = new IntNode(2);
            IntNode node3 = new IntNode(3);
            IntNode node4 = new IntNode(4);
            IntNode node5 = new IntNode(5);
            IntNode node6 = new IntNode(6);


            node1.setNext(node2);
            node2.setNext(node3);
            node3.setNext(node4);
            node4.setNext(node5);
            node5.setNext(node6);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Original linked list:");
            IntNode.print(node1);
            Console.ResetColor();
            Console.WriteLine($"the sum of the list is = {NodesEx.Sum(node1)}");
            Console.WriteLine($"is the value 4 in the list? : {NodesEx.IsExist(node1, 4)}");
            //NodesEx.EnterLast(node1, 10);
            //IntNode.print(node1);
            //NodesEx.EnterSecond(node1, 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("the list after 100 was enterd in the second node :");
            IntNode.print(node1);
            Console.ResetColor();
            int count = NodesEx.Size(node1);
            int countNumAppernce = NodesEx.HowMany(node1, 100);
            int sumOdd = NodesEx.Sum(node1);
            Console.WriteLine($"the list length = {count}");
            Console.WriteLine($"is the list in order? {NodesEx.InOrder(node1)}");
            Console.WriteLine($"the sum of the odd indexes = {sumOdd}");
            Console.WriteLine($"is the list serial? {NodesEx.IsSerial(node1)}");
            //Console.WriteLine($"the list after removig the node in index 3:=> {NodesEx.RemovePos(node1, 3)}");
            //IntNode.print(node1);
            Console.WriteLine($"the value in index 3 is {NodesEx.ReturnAtPos(node1, 3)}");
            Console.WriteLine(NodesEx.ReturnNum(node1, 3));
            Console.WriteLine($"the max value node on the list is : {NodesEx.Max(node1)}");
            IntNode prevNode = NodesEx.Prev(node1, node3);
            Console.WriteLine($"the value of the prev third node is {prevNode}");




        }
    }
}
