using Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Lesson2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices
{
    public class MtEx1
    {
        // stack clone and count function
        public static Stack<T> CloneStack<T>(Stack<T> originalStack)
        {
            Stack<T> stackClone = new Stack<T>();
            Stack<T> stackResult = new Stack<T>();
            while (!originalStack.IsEmpty())
            {
                T currentValue = originalStack.Pop();
                stackClone.Push(currentValue);
            }
            while (!stackClone.IsEmpty())
            {
                T currentValue = stackClone.Pop();
                stackResult.Push(currentValue);
                originalStack.Push(currentValue);
            }
            return stackResult;
        }

        public static int StackCount<T>(Stack<T> stack)
        {
            Stack<T> cloneStack = CloneStack(stack);
            int count = 0;
            while (!cloneStack.IsEmpty())
            {
                cloneStack.Pop();
                count++;
            }
            return count;
        }

        // queue clone and count function
        public static Queue<T> CloneQueue<T>(Queue<T> originalQueue)
        {
            Queue<T> cloneQueue = new Queue<T>();
            Queue<T> queueToReturn = new Queue<T>();

            while (!originalQueue.IsEmpty())
            {
                T currentValue = originalQueue.Remove();
                cloneQueue.Insert(currentValue);
            }
            while (!cloneQueue.IsEmpty())
            {
                T currentValue = cloneQueue.Remove();
                queueToReturn.Insert(currentValue);
                originalQueue.Insert(currentValue);
            }
            return queueToReturn;
        }

        public static int CountQueue<T>(Queue<T> queue)
        {
            Queue<T> cloneQueue = CloneQueue(queue);
            int count = 0;
            while (!cloneQueue.IsEmpty())
            {
                cloneQueue.Remove();
                count++;
            }
            return count;
        }

        // EX1
        public static bool IsOrderd(Stack<int> stack)
        {
            Stack<int> cloneStack = CloneStack(stack);
            int stackLength = StackCount(cloneStack);
            int middle = stackLength / 2;
            int count = 0;

            while (!cloneStack.IsEmpty())
            {
                int currentValue = cloneStack.Pop();
                if (currentValue > 0)
                {
                    if (currentValue % 2 == 0) // Even number
                    {
                        if (count > middle)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (count < middle)
                        {
                            return false;
                        }
                    }
                }
                count++;
            }
            return true;
        }
        //EX2
        public static void CheckQueue(Queue<int> queue)
        {
            Queue<int> cloneQueue = CloneQueue(queue);
            Queue<int> receiverQueue = new Queue<int>();

            int queueLength = CountQueue(cloneQueue);
            int middle = queueLength / 2;

            if (queueLength % 2 != 0) // Odd-length queue
            {
                int count = 0;
                while (!cloneQueue.IsEmpty())
                {
                    int currentValue = cloneQueue.Remove();
                    if (count != middle) // Skip the middle element
                    {
                        receiverQueue.Insert(currentValue);
                    }
                    count++;
                }
            }
            else // Even-length queue
            {
                int count = 0;
                while (!cloneQueue.IsEmpty())
                {
                    int currentValue = cloneQueue.Remove();
                    if (count != middle && count != middle - 1) // Skip two middle elements
                    {
                        receiverQueue.Insert(currentValue);
                    }
                    count++;
                }
            }

            // Refill the cloneQueue with remaining elements
            while (!receiverQueue.IsEmpty())
            {
                cloneQueue.Insert(receiverQueue.Remove());
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(cloneQueue);
            Console.ResetColor();
        }
        //EX3
    

    }

    public class RunMtEx1
    {
        public static void DemoMain()
        {
            // stack section
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(9);
            stack1.Push(7);
            stack1.Push(5);
            stack1.Push(2);
            stack1.Push(4);

            //queue section
            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE ORIGINAL STACK:");
            Stack<int> cloneStack1 = MtEx1.CloneStack(stack1);
            Console.WriteLine(cloneStack1);
            Console.ResetColor();

            Console.WriteLine("Is stack ordered? " + MtEx1.IsOrderd(stack1));
            MtEx1.CheckQueue(intQueue);
        }
    }
}
