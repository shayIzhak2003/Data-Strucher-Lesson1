using Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
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
            if (lst == null || lst.GetNext() == null)
            {
                return lst; // Base case: if there's only one node left, return it
            }

            Node<int> nextDifference = DifferenceList(lst);

            // If the difference list has only one node left, return it
            if (nextDifference == null || nextDifference.GetNext() == null)
            {
                return nextDifference;
            }

            // Recursive call
            return TheSurvives(nextDifference);
        }

        //EX2
        public static bool SumStack(Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            int sum = 0;
            while(!st.IsEmpty())
            {
                int current = st.Pop();
                if(current <= sum)
                    return false;

                sum += current;
                temp.Push(current);
            }

            while (!temp.IsEmpty())
                st.Push(temp.Pop());
            return true;
        }
        // The Runtime Complexity of IsOptimalSuperStack:
        // he function processes each stack element twice (once while checking, once while restoring).
        // Since all operations(push/pop) are O(1), the total remains O(n).

        //EX5
        public static void RunEX5()
        {
            RunClownApp.DemoMain();
        }

        //EX8
        //pt.1
        public static int SumQueue(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int sum = 0;
            while(!q.IsEmpty())
            {
                int currentValue = q.Remove();
                sum += currentValue;
                temp.Insert(currentValue);
            }
            return sum;
        }
        //pt.2
        public static int LastValue(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int lastValue = 0;
            while (!q.IsEmpty())
            {
                lastValue = q.Remove();  
                temp.Insert(lastValue);
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return lastValue;
        }
        //pt.3
        public static Queue<int>CheckQueueNode(Node<Queue<int>> lst)
        {
            Node<Queue<int>> pos = lst;
            Queue<int> queueToReturn = new Queue<int>();
            while (pos != null)
            {
                Queue<int> current = pos.GetValue();
                int currentValue = current.Remove();
                current.Insert(currentValue);
                if (currentValue % 2 != 0)
                    queueToReturn.Insert(SumQueue(current));
                else
                {
                    queueToReturn.Insert(LastValue(current));
                }
                pos = pos.GetNext();
            }
            return queueToReturn;
            
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

            Stack<int> stack = new Stack<int>();
            stack.Push(110000);
            stack.Push(200);
            stack.Push(30);
            stack.Push(5);

            Queue<int> q1 = new Queue<int>();
            q1.Insert(3);
            q1.Insert(5);
            q1.Insert(7);

            Queue<int> q2 = new Queue<int>();
            q2.Insert(4);
            q2.Insert(4);
            q2.Insert(2);

            Node<Queue<int>> node2 = new Node<Queue<int>>(q2);
            Node<Queue<int>> node1 = new Node<Queue<int>>(q1, node2);



            //EX1
            Console.WriteLine(MohedA2022.DifferenceList(original).ToPrint());
            Console.WriteLine(MohedA2022.TheSurvives(original).ToPrint());
            //EX2
            Console.WriteLine(MohedA2022.SumStack(stack));
            //EX5
            MohedA2022.RunEX5();
            //EX8
            Console.WriteLine(MohedA2022.CheckQueueNode(node1));


        }
    }
}
