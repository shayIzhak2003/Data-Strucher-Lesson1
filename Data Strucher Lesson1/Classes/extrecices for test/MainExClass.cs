using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class MainExClass
    {
        // liner lists start
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
                if(pos.GetValue() == num)
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
            while(pos.HasNext())
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
            while(pos != null)
            {
                count++;
                if(count == 2)
                {
                    pos.SetValue(num);
                }
                pos = pos.GetNext();
            }
        }
        //EX5
        public static int Size(IntNode lst)
        {
            int count = 0;
            IntNode pos = lst;
            while(pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
        //EX6
        public static int HowMany(IntNode lst, int num)
        {
            int count = 0;
            IntNode pos = lst;
            while(pos != null)
            {
                if (pos.GetValue() == num)
                    count++;

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
                if(pos.GetValue() > pos.GetNext().GetValue())
                    return false;

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
            while(pos != null)
            {
                count++;
                if (count % 2 != 0)
                    sum += pos.GetValue();

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
            if(lst == null || !lst.HasNext())
                return true;

            IntNode current = lst;
            int diff = current.GetNext().GetValue() - current.GetValue();
            while (current.HasNext())
            {
                if (current.GetNext().GetValue() - current.GetValue() != diff)
                    return false;

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
        public static int ReturnAtPos(IntNode lst, int step)
        {
            IntNode pos = lst;
            int count = 0;
            int val = 0; ;
            while (pos != null)
            {
                count++;
                if(count == step)
                {
                    val = pos.GetValue();
                }
            }
            return val;
        }
    }
    public class RunMainExClass
    {
        public static void DemoMain()
        {
            IntNode n1 = new IntNode(14);
            IntNode n2 = new IntNode(24);
            IntNode n3 = new IntNode(34);
            IntNode n4 = new IntNode(44);
            IntNode n5 = new IntNode(54);
            n1.setNext(n2);
            n2.setNext(n3);
            n3.setNext(n4);
            n4.setNext(n5);
            int sum = MainExClass.Sum(n1);
            Console.WriteLine($"the sum of the list is : {sum}");
            int num = 1;
            Console.WriteLine($"is the number {num} in the list? {MainExClass.IsExsist(n1,num)}");
            Console.WriteLine("\nthe original list :");
            IntNode.print(n1);
            //Console.WriteLine("the list after entering 30 in the second place!");
            //MainExClass.EnterSecond(n1, 30);
            //IntNode.print(n1);
            Console.WriteLine($"the size of the list is : {MainExClass.Size(n1)}");
            Console.WriteLine($"the amount of times the the number 14 is of the list is {MainExClass.HowMany(n1,14)}");
            Console.WriteLine($"is the list in order ? {MainExClass.InOrder(n1)}");
            Console.WriteLine($"the sum in the odd indexs is {MainExClass.SumOdd(n1)}");
            //MainExClass.EnterInOrder(n1, 45);
            //IntNode.print(n1);
            Console.WriteLine($"is the list serial? {MainExClass.IsSerial(n1)}");
            Console.WriteLine("the list after deleteing 54 :");
            //MainExClass.RemovePos(n1,5);
            //IntNode.print(n1);


        }
    }
}
