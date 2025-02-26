using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a
{
    public class MohedA2022
    {
        //EX1 pt.1
        public static Node<int> DifferenceList(Node<int> n)
        {
            if (n == null || n.GetNext() == null)
                return null; // No difference can be calculated with 0 or 1 node

            Node<int> head = null; // New list head
            Node<int> tail = null; // Tail pointer for efficient insertion

            Node<int> current = n;
            while (current.GetNext() != null)
            {
                int diff = Math.Abs(current.GetNext().GetValue() - current.GetValue());
                Node<int> newNode = new Node<int>(diff);

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.SetNext(newNode);
                    tail = newNode;
                }

                current = current.GetNext();
            }

            return head;
        }
        //EX1 pt.2
        public static Node<int> TheSurvives(Node<int> lst)
        {
            Node<int> pos = lst;
            Node<int> newListToReturn = null;

            
            
                Node<int> currentList = DifferenceList(pos);

                while(currentList != null)
                {
                    currentList = currentList.GetNext();
                }
            
        }

    }
    public class RunMohedA2022
    {
        public static void DemoMain()
        {
            Node<int> original = new Node<int>(5);
            original.SetNext(new Node<int>(20));
            original.GetNext().SetNext(new Node<int>(9));
            original.GetNext().GetNext().SetNext(new Node<int>(6));
            original.GetNext().GetNext().GetNext().SetNext(new Node<int>(5));
            original.GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(8));
            original.GetNext().GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(2));

            Console.WriteLine(MohedA2022.DifferenceList(original).ToPrint());
            
        }
    }
}
