using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Guy
{
    public class NodeExGuy
    {
       // count all Nodes in the list 
       public static int countNodes<T>(Node<T> lst)
        {
            int count = 0;
            while (lst != null)
            {
                count++;
                lst = lst.GetNext();
            }
            return count; 
        }

        public static int SumNodes(Node<int> lst)
        {
            Node<int> pos = lst;
            int sum = 0;
            while (pos != null)
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            }
            return sum;
        }

        // find min value node function
        public static Node<int> MinNode(Node<int> lst)
        {
            Node<int> pos = lst;
            int min = pos.GetValue();
            Node<int> minP = pos.GetNext();
            while (pos != null)
            {
                int currentValue = pos.GetValue();
                if(currentValue < min)
                {
                    min = currentValue;
                    minP = pos;
                }
                    

                pos = pos.GetNext();
            }
            return minP;
        }
        // 
        public static Node<int> AfterSteps(Node<int> lst, int steps, int x)
        {
            if (lst == null || steps < 0)
                return lst;

            Node<int> pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                if (count == steps)
                {
                    Node<int> newValue = new Node<int>(x); // זוהי הדרך להוספת חוליה (תמיד!!)
                    newValue.SetNext(pos.GetNext());
                    pos.SetNext(newValue);
                }
                
                pos = pos.GetNext();
            }
            return lst;
        }

        public static void VirtualMain()
        {
            Node<int> node5 = new Node<int>(5);
            Node<int> node4 = new Node<int>(4, node5);
            Node<int> node3 = new Node<int>(3, node4);
            Node<int> node2 = new Node<int>(2, node3);
            Node<int> node1 = new Node<int>(1, node2);
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(MinNode(node1));
            Console.WriteLine(AfterSteps(node1, 2, 14));
            Console.WriteLine(node1.ToPrint());

        }
    }
}
