using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    internal class NodeEx
    {
        //EX1
        public static int Sum(IntNode lst)
        {

            int sum = 0;

                IntNode pos = lst;
                while (pos != null)
                {
                // הדפס את האיבר
                  sum +=pos.GetValue();
                    // עבור לאיבר הבא
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
                    return true;
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
        public static void EnterSecond(IntNode lst, IntNode num)
        {
            if (lst == null)
            {
                lst = num;
            }
            else
            {
                num.setNext(lst.GetNext());
                lst.setNext(num);
            }
        }
        //EX5
        public static int Size(IntNode lst)
        {
            IntNode pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
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
                if(pos.GetValue() == num)
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
            int sum = 0;
            int position = 1; 
            IntNode pos = lst;
            while (pos != null)
            {
                if (position % 2 != 0)
                {
                    sum += pos.GetValue();
                }
                pos = pos.GetNext();
                position++;
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
            int diff = current.GetNext().GetValue() - current.GetValue();

            while (current.HasNext())
            {
                if(current.GetNext().GetValue() - current.GetValue() != diff)
                {
                    return false;
                }
                current = current.GetNext();
            }
            return true;
        }
       
       
         //EX11
        public static IntNode RemovePos(IntNode lst, int pos)
        {
            if (lst == null || pos < 0)
            {
                return lst; 
            }

            if (pos == 0)
            {
                
                return lst.GetNext();
            }

            IntNode current = lst;
            for (int i = 0; i < pos - 1; i++)
            {
                if (current.GetNext() == null)
                {
                    return lst; 
                }
                current = current.GetNext();
            }

            if (current.GetNext() != null)
            {
                current.setNext(current.GetNext().GetNext());
            }

            return lst;
        }

        //EX12
        public static IntNode ReturnAtPos(IntNode lst, int step)
        {
            if (lst == null || step < 0)
            {
                return null;
            }

            IntNode current = lst;
            for (int i = 0; i < step; i++)
            {
                if (current.GetNext() == null)
                {
                    return null;
                }
                current = current.GetNext();
            }

            return current;
        }
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
            if (lst == null)
            {
                throw new ArgumentException("The list cannot be null");
            }

            IntNode current = lst;
            int max = current.GetValue(); 
            int index = 0;
            int place = 0;

            while (current != null)
            {
                if (current.GetValue() > max)
                {
                    max = current.GetValue();
                    place = index;
                }
                index++;
                current = current.GetNext(); 
            }

            Console.WriteLine($"The biggest value is {max} in place: {place}");
            return place;
        }

        //EX15
        public static IntNode Prev(IntNode lst, IntNode num)
        {
            if (lst == null || num == null || lst == num)
            {
                return null;
            }

            IntNode current = lst;
            IntNode previous = null;

            while (current != null)
            {
                if (current.GetNext() == num)
                {
                    return current;
                }
                previous = current;
                current = current.GetNext();
            }

            return null;
        }
    }
}

