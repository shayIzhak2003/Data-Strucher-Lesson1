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
        }
    }
}
