using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class Ex1
    {
        //EX1
        public static int Sum(IntNode lst)
        {
            int sum = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                sum += pos.GetValue();

                pos.GetNext();
            }
            return sum;
        }
        //EX2
        public static bool IsExsist(IntNode lst, int num)
        {
            IntNode pos = lst;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                {
                    return true;
                }
                pos = pos.GetNext();
            }
            return false;
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
            int count = 0;
            IntNode pos = lst;
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
            int size = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                size++;

                pos = pos.GetNext();
            }
            return size;

        }
        //EX6
        public static int HowMany(IntNode lst, int num)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                if (pos.GetValue() == num)
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
            if (lst == null || !lst.HasNext())
            {
                return true;
            }

            IntNode pos = lst;
            while (pos.GetNext().HasNext())
            {
                if (pos.GetValue() > pos.GetNext().GetValue())
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
            int count = 0;
            int sum = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                count++;
                if (count % 2 != 0)
                {
                    sum += pos.GetValue();
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
            if (lst == null || !lst.HasNext())
            {
                return true;
            }

            IntNode current = lst;
            while (current.HasNext())
            {
                int diff = current.GetNext().GetValue() - current.GetValue();
                if (current.GetNext().GetValue() - current.GetValue() != diff)
                {
                    return false;
                }
                current = current.GetNext();
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
        //public static IntNode ReturnAtPos(IntNode lst, int step)
        //{
        //    int count = 0;
        //    int val = 0;
        //    IntNode pos = lst;
        //    while (lst != null)
        //    {
        //        count++;
        //        if(count == step)
        //        {
        //             val = pos.GetValue();

        //        }
        //    }
        //    return val;
        //}

        //EX13
        public static int ReturnNum(IntNode lst, int num)
        {
            IntNode pos = lst;
            int index = 0;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                {
                    return index;
                }
                pos = pos.GetNext();
                index++;
            }
            return -1;
        }

        //EX14
        public static int Max(IntNode lst)
        {
            IntNode pos = lst;
            int max = pos.GetValue();
            while (pos != null)
            {
                if(pos.GetValue() > max)
                {
                    max = pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return max;
        }
        //EX15
        public static int Prev(IntNode lst, int num)
        {
            IntNode pos = lst;
            int prev = 0;
            while (pos != null)
            {
                if(pos.GetNext().GetValue() == num)
                {
                    return pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return -1;
        }
    }

    public class RunEx1
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


            Console.WriteLine("Original linked list:");
            IntNode.print(node1);


            int sum = NodeEx.Sum(node1);
            Console.WriteLine("Sum of the linked list: " + sum);
            Console.WriteLine();
            Console.Write("enter a number =>");
            int num = int.Parse(Console.ReadLine());
            bool res = NodeEx.IsExsist(node1, num);
            Console.WriteLine($"is the enumber {num} in the list? :");
            IntNode.print(node1);
            Console.WriteLine(res);
            Console.WriteLine();
            int num2 = 40;
            Console.WriteLine("\nOriginal linked list:");
            IntNode.print(node1);
            Console.WriteLine("\nthe new list :");
            Ex1.EnterLast(node1, num2);
            IntNode.print(node1);
            int num3 = 30;
            Console.WriteLine("\nOriginal linked list:");
            IntNode.print(node1);
            Console.WriteLine("\nthe new list :");
            Ex1.EnterSecond(node1, num3);
            IntNode.print(node1);
            Console.WriteLine();
            Console.WriteLine("the list size is :");
            Console.WriteLine(Ex1.Size(node1));
            Console.WriteLine("the list : ");
            IntNode.print(node1);
            Console.WriteLine("the amount of times that 4 is on the list is :");
            Console.WriteLine(Ex1.HowMany(node1, 4));

            Console.WriteLine("is the list :");
            IntNode.print(node1);
            Console.WriteLine("going up?");
            Console.WriteLine(Ex1.InOrder(node1));
            Console.WriteLine($"the sum just in the odd indexs is : {Ex1.SumOdd(node1)}");

            Console.WriteLine();
            Ex1.EnterInOrder(node1, 6);
            IntNode.print(node1);
            Console.WriteLine("================");
            Console.WriteLine("the list :");
            IntNode.print(node1);
            Ex1.RemovePos(node1, 6);
            IntNode.print(node1);
            //Console.WriteLine(Ex1.ReturnAtPos(node1,3));
            Console.WriteLine(Ex1.ReturnNum(node1, 30));
            Console.WriteLine($"the biggest num is {Ex1.Max(node1)}");
            Console.WriteLine(Ex1.Prev(node1,5));

        }
    }

}
