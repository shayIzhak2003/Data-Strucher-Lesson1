using Data_Strucher_Lesson1.Classes.extrecices_for_test;
using Data_Strucher_Lesson1.Classes.stackStrucher;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Node<int> start = chain;
            Node<int> current = chain;

        }
    }

    public class RunMahatEx1
    {
        public static void DemoMain()
        {

            Stack<int> stack = new Stack<int>();
            stack.Push(100000);
            stack.Push(10000);
            stack.Push(100);
            stack.Push(10);

            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);

            Console.WriteLine(intQueue);
            Console.WriteLine(MahatEx1.RemoveFromQueue(intQueue, 1));
            Console.WriteLine(intQueue);
            Console.WriteLine(MahatEx1.IsUniform(stack));
        }
    }
}
