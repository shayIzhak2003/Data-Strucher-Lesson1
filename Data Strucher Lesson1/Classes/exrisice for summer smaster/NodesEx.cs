﻿using System;
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
                if(currentValue == num)
                {
                    count++;
                }
                pos = pos.GetNext();
            }
            return count;
        }
        //EX7

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
            NodesEx.EnterLast(node1, 10);
            IntNode.print(node1);
            NodesEx.EnterSecond(node1, 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("the list after 100 was enterd in the second node :");
            IntNode.print(node1);
            Console.ResetColor();
            int count = NodesEx.Size(node1);
            int countNumAppernce = NodesEx.HowMany(node1, 100);
            Console.WriteLine($"the list length = {count}");
            Console.WriteLine($"the amount of ");
        }
    }
}