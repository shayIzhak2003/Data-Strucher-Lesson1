﻿using Data_Strucher_Lesson1.Classes.extrecices_for_test;
using Data_Strucher_Lesson1.Classes.Queue;
using Data_Strucher_Lesson1.Classes.stackStrucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
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
            // If q2 is empty or null, it always starts with q1
            if (q2 == null || q2.IsEmpty())
            {
                return true;
            }

            // If q1 is empty or null, it cannot start with q2
            if (q1 == null || q1.IsEmpty())
            {
                return false;
            }

            Queue<int> cloneQ1 = QEx.CloneQueue1(q1);
            Queue<int> cloneQ2 = QEx.CloneQueue1(q2);

            // Compare elements of q2 with the prefix of q1
            while (!cloneQ1.IsEmpty())
            {
                if (cloneQ2.IsEmpty())
                {
                    return true; // All elements of q1 matched in q2
                }

                int currentValue1 = cloneQ1.Remove();
                int currentValue2 = cloneQ2.Remove();

                if (currentValue1 != currentValue2)
                {
                    return false; // Mismatch found
                }
            }

            return cloneQ1.IsEmpty(); // Ensure all elements of q1 were checked
        }


        //EX6 pt.2
        public static bool Duplication(Queue<int> q1, Queue<int> q2)
        {
            // If q1 is null or empty, it cannot be duplicated in q2
            if (q1 == null || q1.IsEmpty())
            {
                return false;
            }

            // If q2 is null or empty, q1 cannot be a subsequence
            if (q2 == null || q2.IsEmpty())
            {
                return false;
            }

            Queue<int> cloneQ2 = QEx.CloneQueue1(q2);
            int matchCount = 0;

            while (!cloneQ2.IsEmpty())
            {
                if (StartWith(q1, cloneQ2))
                {
                    matchCount++;

                    // If q1 is found more than once in q2, return true
                    if (matchCount > 1)
                    {
                        return true;
                    }
                }

                // Progress the search by removing one element from cloneQ2
                cloneQ2.Remove();
            }

            return false; // Return false if q1 is found at most once
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


            Queue<int> intQueue2 = new Queue<int>();
            intQueue2.Insert(1);
            intQueue2.Insert(2);
            intQueue2.Insert(3);
            intQueue2.Insert(4);

            Queue<int> q1 = new Queue<int>();
            q1.Insert(3);
            q1.Insert(12);
            q1.Insert(10);
            q1.Insert(2);

            Queue<int> q2 = new Queue<int>();
            q2.Insert(3);
            q2.Insert(12);
            q2.Insert(10);
            q2.Insert(2);
            q2.Insert(3);
            q2.Insert(12);
            q2.Insert(10);
            q2.Insert(2);
            





            //Queue<int> cloneQueue = QEx.CloneQueue1(q2);
            //Console.WriteLine($"the clone queue: => {cloneQueue}");

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
            Console.WriteLine($"the results are : => {MahatEx1.StartWith(q1, q2)}");
            Console.WriteLine($"are the queues duplicated? :=> {MahatEx1.Duplication(q1,q2)}");
        }
    }
}