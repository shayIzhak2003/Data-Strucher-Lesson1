using Data_Strucher_Lesson1.Classes.extrecices_for_test;
using Data_Strucher_Lesson1.Classes.Queue;
using Data_Strucher_Lesson1.Classes.stackStrucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024
{
    public class MahatEx1
    {
        // Ex1
        public static bool IsUniform(Stack<int> st)
        {
            if (st == null || st.IsEmpty())
                return true; // An empty stack or null stack is considered uniform

            // Clone the stack to avoid modifying the original
            Stack<int> cloneStack = Lesson2.Clone(st);
            bool isEven = cloneStack.Top() % 2 == 0; // Determine the parity of the first element

            while (!cloneStack.IsEmpty())
            {
                int currentValue = cloneStack.Pop();

                // If the parity of the current value doesn't match the first element, it's not uniform
                if ((currentValue % 2 == 0) != isEven)
                    return false;
            }

            return true; // All elements have the same parity
        }

        // the runtime function is O(N * N)

        //EX2
        public static int RemoveFromQueue(Queue<int> st, int valueToRemove)
        {
            Queue<int> tempQueue = new Queue<int>();
            int value = 0;
            while (!st.IsEmpty())
            {
                int currentValue = st.Remove();
                if (currentValue != valueToRemove)
                {
                    tempQueue.Insert(currentValue);
                }
                else
                {
                    value = currentValue;
                }
            }

            while (!tempQueue.IsEmpty())
            {
                int currentValue = tempQueue.Remove();
                st.Insert(currentValue);
            }

            return value;
        }
        // the runtime function is O(N * N)

        //EX3
        public static bool UniqNeg(Node<int> chain)
        {
            Node<int> pos = chain;
            int count = 0;
            while (pos != null)
            {
                count = 0;
                int currentValue = pos.GetValue();

                if (currentValue < 0)
                {
                    Node<int> innerPos = chain;
                    while (innerPos != null)
                    {
                        if (innerPos.GetValue() == currentValue)
                        {
                            count++;
                        }
                        innerPos = innerPos.GetNext();
                    }

                    if (count > 1)
                    {
                        return false;
                    }
                }

                pos = pos.GetNext();
            }
            return true;

            // the runtime function is O(N * N)
        }

        //EX4
        public static void What(Stack<int> s)
        {
            Stack<int> temp1 = new Stack<int>();
            Stack<int> temp2 = new Stack<int>();
            while (!s.IsEmpty())
            {
                int x = s.Pop();
                bool found = false;
                while (!s.IsEmpty())
                {
                    int y = s.Pop();
                    if (x < y)
                        found = true;
                    temp1.Push(y);
                }
                while (!temp1.IsEmpty())
                    s.Push(temp1.Pop());

                if (!found)
                    temp2.Push(x);
            }
            while (!temp2.IsEmpty())
                s.Push(temp2.Pop());
        }

        //EX6 
        public static bool StartWith(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> cloneQ1 = QEx.CloneQueue1(q1);
            Queue<int> cloneQ2 = QEx.CloneQueue1(q2);

            if (QEx.CountQueue(q1) == QEx.CountQueue(q2))
            {
                for (int i = 0; i < QEx.CountQueue(q1); i++)
                {
                    int currentQ1Value = cloneQ1.Remove();
                    int currentQ2Value = cloneQ2.Remove();

                    if (currentQ1Value != currentQ2Value)
                        return false;
                }
                return true;
            }

            else
            {
                while (!cloneQ2.IsEmpty() && !cloneQ1.IsEmpty())
                {
                    int currentQ1Value = cloneQ1.Remove();
                    int currentQ2Value = cloneQ2.Remove();

                    if()
                }
            }
        }
    }



    public class RunMahatEx1
    {
        public static void DemoMain()
        {

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(4);
            stack.Push(1);
            stack.Push(4);
            stack.Push(1);
            stack.Push(3);
            stack.Push(6);
            stack.Push(4);

            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);

            Node<int> chain = new Node<int>(10);
            chain.SetNext(new Node<int>(-3, new Node<int>(10,
                new Node<int>(6, new Node<int>(-2,
                new Node<int>(-8, new Node<int>(7)))))));


            Console.WriteLine(intQueue);
            Console.WriteLine(MahatEx1.RemoveFromQueue(intQueue, 1));
            Console.WriteLine(intQueue);
            Console.WriteLine(MahatEx1.IsUniform(stack));

            Console.WriteLine($"the chain ; => {chain.ToPrint()}");
            Console.WriteLine(MahatEx1.UniqNeg(chain));
            Console.WriteLine(stack);
            MahatEx1.What(stack);
            Console.WriteLine(stack);

        }
    }
}
