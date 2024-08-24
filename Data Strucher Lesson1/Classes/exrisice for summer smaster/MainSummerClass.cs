using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.exrisice_for_summer_smaster
{
    public class MainSummerClass
    {
        //EX1
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
            int counter = 0;
            while (pos != null)
            {
                counter++;
                pos = pos.GetNext();
            }
            return counter;
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
            IntNode pos = lst;
            while (pos.GetNext().HasNext())
            {
                int currentValue = pos.GetValue();
                int nextValue = pos.GetNext().GetValue();
                if (currentValue > nextValue)
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
            int index = 0;
            int sum = 0;
            while (pos != null)
            {
                index++;
                if (index % 2 != 0)
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
            IntNode pos = lst;
            while (pos.HasNext())
            {
                int gap = pos.GetValue() - pos.GetNext().GetValue();
                if (pos.GetValue() - pos.GetNext().GetValue() != gap)
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            return true;
        }
        //EX11
        public static IntNode RemovePos(IntNode lst, int n)
        {
            IntNode pos = lst;
            int index = 0;
            while (pos.HasNext())
            {
                index++;
                if (index == n)
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
            int index = 0;
            IntNode pos = lst;
            int valueToReturn = 0;
            while (lst != null)
            {
                if (index == step)
                {
                    valueToReturn = pos.GetValue();
                }
                pos = pos.GetNext();
            }
            return valueToReturn;
        }

        //EX13
        public static int ReturnNum(IntNode lst, int num)
        {
            int index = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                if (num == pos.GetValue())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"in index {index}");
                    Console.ResetColor();
                    return pos.GetValue();
                }
                pos = pos.GetNext();
                index++;
            }
            return -1;
        }

        //EX14
        public static int Max(IntNode lst)
        {
            if (lst == null)
            {
                throw new ArgumentException("The list cannot be null");
            }

            int max = lst.GetValue();
            int min = lst.GetValue();
            int index = 0;
            int finalIndex = 0;
            int minIndex = 0;

            IntNode pos = lst;
            while (pos != null)
            {
                index++;
                if (pos.GetValue() > max)
                {
                    finalIndex = index;
                    max = pos.GetValue();
                }
                if (pos.GetValue() < min)
                {
                    minIndex = index;
                    min = pos.GetValue();
                }
                pos = pos.GetNext();
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"The min value is {min} at index {minIndex}");
            Console.ResetColor();
            Console.WriteLine("===========================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The max value is {max} at index {finalIndex}");
            Console.ResetColor();

            return max;
        }


        //EX15
        public static int Prev(IntNode lst, int num)
        {
            int index = 0;

            if (lst == null)
            {
                throw new ArgumentException("The list cannot be null");
            }

            IntNode pos = lst;
            while (pos.HasNext())
            {
                index++;
                if(pos.GetNext().GetValue() == num)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"the value is in index {index} "+ "is : ");
                    Console.ResetColor();
                    return pos.GetValue();
                    
                }
                pos = pos.GetNext();

            }
            return -1;
        }
    }
    public class RunMainSummerClass
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


            int sum = MainSummerClass.Sum(node1);
            Console.WriteLine("Sum of the linked list: " + sum);

            Console.WriteLine();
            bool isExsist = MainSummerClass.IsExsist(node1, 8);
            Console.WriteLine($"is the number 8 exsist in the list : {isExsist}");

            //MainSummerClass.EnterLast(node1, 50);
            //Console.WriteLine("thw list after the change :");
            //IntNode.print(node1);

            //MainSummerClass.EnterSecond(node1, 50);
            //Console.WriteLine("thw list after the change :");
            //IntNode.print(node1);
            int size = MainSummerClass.Size(node1);
            Console.WriteLine($"the list size is: {size}");

            int num = 1;
            int count = MainSummerClass.HowMany(node1, num);
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"the number {num} is been {count} times on the list.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"the number {num} is on te list {count} times.");
                Console.ResetColor();
            }

            bool isInOrder = MainSummerClass.InOrder(node1);
            Console.WriteLine($"is the list in up order? {isInOrder}");


            Console.Write("the sum of the odd indexes is : ");
            Console.WriteLine(MainSummerClass.SumOdd(node1));

            bool isSSerial = MainSummerClass.IsSerial(node1);
            Console.WriteLine($"is the list Serial ? {isSSerial}");

            //MainSummerClass.RemovePos(node1, 2);
            //IntNode.print(node1);

            //int value = MainSummerClass.ReturnAtPos(node1, 4);

            //Console.WriteLine($"the value in index 4 is : {value}");
            Console.WriteLine(MainSummerClass.ReturnNum(node1, 3));
            Console.WriteLine($"the max value node on the list is {MainSummerClass.Max(node1)}");

            Console.WriteLine($"{MainSummerClass.Prev(node1, 4)}");




        }
    }
}
