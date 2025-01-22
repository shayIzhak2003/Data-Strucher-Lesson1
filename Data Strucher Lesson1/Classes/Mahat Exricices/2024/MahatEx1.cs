using Data_Strucher_Lesson1.Classes.Binray_tree.Lessons;
using Data_Strucher_Lesson1.Classes.extrecices_for_test;
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

        //EX7
        public static bool IsUpDown(Node<int> chain)
        {
            if (chain == null || !chain.HasNext())
                return true; // A single node or empty list is trivially up-down.

            Node<int> current = chain;

            // Phase 1: Check the increasing sequence.
            while (current.HasNext() && current.GetValue() < current.GetNext().GetValue())
            {
                current = current.GetNext();
            }

            // If we never transitioned to a decreasing sequence, it's not "up-down".
            if (!current.HasNext())
                return false;

            // Phase 2: Check the decreasing sequence.
            while (current.HasNext() && current.GetValue() > current.GetNext().GetValue())
            {
                current = current.GetNext();
            }

            // If we've reached the end of the list, it's a valid "up-down" sequence.
            return !current.HasNext();
        }

        //EX8
        public static void PrintSmallerThenTreeAvarge(BinNode<int> root)
        {
            if (root == null)
            {
                return; // Base case: stop if the node is null
            }

            // Calculate the average of the tree values once
            int totalSum = BasicFunctioms.SumOfValuesOfTheTree(root);
            int totalCount = BasicFunctioms.CountBinTree(root);
            double average = (double)totalSum / totalCount;

            // Traverse the tree and print nodes smaller than the average
            TraverseAndPrint(root, average);
        }

        private static void TraverseAndPrint(BinNode<int> node, double average)
        {
            if (node == null)
            {
                return; // Stop if the node is null
            }

            // Check if the current node's value is smaller than the average
            if (node.GetValue() < average)
            {
                Console.WriteLine(node.GetValue());
            }

            // Recursively traverse left and right subtrees
            TraverseAndPrint(node.GetLeft(), average);
            TraverseAndPrint(node.GetRight(), average);
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

            // int tree
            // Build a sample tree
            BinNode<int> root = new BinNode<int>(10);
            root.SetLeft(new BinNode<int>(4));
            root.SetRight(new BinNode<int>(15));
            root.GetLeft().SetLeft(new BinNode<int>(2));
            root.GetLeft().SetRight(new BinNode<int>(5));




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
            Console.WriteLine($"are the queues duplicated? :=> {MahatEx1.Duplication(q1, q2)}");
            MahatEx1.PrintSmallerThenTreeAvarge(root);
        }
    }
}
