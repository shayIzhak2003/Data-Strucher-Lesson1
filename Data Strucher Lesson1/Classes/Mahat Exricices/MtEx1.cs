using Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Lesson2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public static int NodeLength<T>(Node<T> lst)
        {
            Node<T> tempNode = lst;
            int count = 0;
            while (tempNode != null)
            {
                tempNode = tempNode.GetNext();
                count++;
            }
            return count;
        }
        public static bool IsMiracle(Node<int> lst)
        {
            Node<int> tempNode = lst;
            int minValue = tempNode.GetValue();
            int index = 0;
            int count = 0;
            int nodeLength = NodeLength(tempNode);
            int middle = nodeLength / 2;
            int startValue = tempNode.GetValue();
            int endValue = 0;
            while (tempNode != null)
            {
                int currentValue = tempNode.GetValue();
                if (currentValue < minValue)
                {
                    minValue = currentValue;
                    index = count;
                }
                if (!tempNode.HasNext())
                {
                    endValue = tempNode.GetValue();
                }
                tempNode = tempNode.GetNext();
                count++;

            }
            Console.WriteLine($"in place {index}");
            return (endValue == startValue && index == middle && nodeLength % 2 != 0);
        }
        //EX6 pt.1
        public static bool CheckTwoStacks<T>(Stack<T> firstStack, Stack<T> secondStack)
        {
            Stack<T> cloneFisrtStack = MtEx1.CloneStack(firstStack);
            Stack<T> cloneSecondStack = MtEx1.CloneStack(secondStack);
            while (!cloneFisrtStack.IsEmpty() && !cloneSecondStack.IsEmpty())
            {
                T currentValueStack1 = cloneFisrtStack.Pop();
                T currentValueStack2 = cloneSecondStack.Pop();

                if (!(currentValueStack1.Equals(currentValueStack2)))
                {
                    return false;
                }
            }
            return true;
        }
        //EX6 pt.2
        public static Stack<T> CommunBottoms<T>(Stack<T> firstStack, Stack<T> secondStack)
        {
            // Clone the stacks to preserve their original content
            Stack<T> firstStackClone = CloneStack(firstStack);
            Stack<T> secondStackClone = CloneStack(secondStack);

            // Stack to store common elements
            Stack<T> stackToReturn = new Stack<T>();

            // Compare the stacks element by element from the top
            while (!firstStackClone.IsEmpty() && !secondStackClone.IsEmpty())
            {
                T currentFirst = firstStackClone.Pop();
                T currentSecond = secondStackClone.Pop();

                if (currentFirst.Equals(currentSecond))
                {
                    stackToReturn.Push(currentFirst); // Add the common element
                }
                else
                {
                    break; // Stop comparison on the first mismatch
                }
            }

            return stackToReturn;
        }
        //EX7 pt.1
        public static bool IsFibunachi(Node<int> lst)
        {
            if (lst == null || !lst.HasNext())
            {
                // A Fibonacci sequence must have at least 3 numbers
                return false;
            }

            Node<int> first = lst;
            Node<int> second = lst.GetNext();
            Node<int> current = second.GetNext();
            while (current != null)
            {
                if (current.GetValue() != second.GetValue() + first.GetValue())
                {
                    return false;
                }
                first = second;
                second = current;
                current = current.GetNext();
            }
            return true;
        }
        // EX7 pt.2
        public static Node<int> ReturnFibonacciSeries(int num)
        {
            if (num <= 0) return null; // Handle edge case: no Fibonacci series for non-positive numbers.

            // Create the head of the linked list with the first Fibonacci number.
            Node<int> fibunachiList = new Node<int>(0); // First Fibonacci number (0)
            if (num == 1) return fibunachiList; // If only 1 Fibonacci number is needed.

            // Add the second Fibonacci number (1).
            Node<int> current = new Node<int>(1); // Second Fibonacci number (1)
            fibunachiList.SetNext(current);

            int a = 0, b = 1; // First two Fibonacci numbers

            // Generate the rest of the Fibonacci sequence.
            for (int i = 2; i < num; i++) // Start from the third Fibonacci number.
            {
                int nextValue = a + b; // Calculate the next Fibonacci number.
                a = b;
                b = nextValue;

                // Create a new node with the next Fibonacci number and link it.
                Node<int> newNode = new Node<int>(nextValue);
                current.SetNext(newNode);
                current = newNode; // Move to the newly created node.
            }

            return fibunachiList; // Return the head of the linked list.
        }
        //EX8 (this is a bunary tree function i will do it later)

        //EX9
        public static int MaxDiff(Queue<int> originalQueue)
        {
            Queue<int> cloneQueue = CloneQueue(originalQueue); // Assuming CloneQueue creates a deep copy
            int maxDiff = int.MinValue; // Set to smallest possible value to track maximum difference

            // Ensure there are at least two elements to process
            while (!cloneQueue.IsEmpty())
            {
                // Remove the first element
                int currentValue = cloneQueue.Remove();

                // Check if there is another element to form a pair
                if (!cloneQueue.IsEmpty())
                {
                    int nextValue = cloneQueue.Remove();

                    int currentDiff = Math.Abs(currentValue - nextValue); // Use absolute difference

                    if (currentDiff > maxDiff)
                    {
                        maxDiff = currentDiff; // Update maxDiff
                    }
                }
            }

            return maxDiff == int.MinValue ? 0 : maxDiff; // Return 0 if no difference was calculated
        }





    }

    public class RunMtEx1
    {
        public static void DemoMain()
        {
            // stack section
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(9);
            stack1.Push(7);
            stack1.Push(15);
            stack1.Push(2);
            stack1.Push(4);

            Stack<int> stack2 = new Stack<int>();
            stack2.Push(9);
            stack2.Push(7);
            stack2.Push(5);
            stack2.Push(2);
            stack2.Push(4);


            //queue section
            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);

            // Node section
            Node<int> node5 = new Node<int>(8);
            Node<int> node4 = new Node<int>(5, node5);
            Node<int> node3 = new Node<int>(3, node4);
            Node<int> node2 = new Node<int>(2, node3);
            Node<int> node1 = new Node<int>(1, node2);



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE ORIGINAL STACK:");
            Stack<int> cloneStack1 = MtEx1.CloneStack(stack1);
            Console.WriteLine(cloneStack1);
            Console.ResetColor();

            Console.WriteLine("Is stack ordered? " + MtEx1.IsOrderd(stack1));
            MtEx1.CheckQueue(intQueue);

            Console.WriteLine(MtEx1.IsMiracle(node1));
            Console.WriteLine(MtEx1.CheckTwoStacks(stack1, stack2));
            Console.WriteLine(MtEx1.CommunBottoms(stack1, stack2));
            Console.WriteLine($"is the list fibunachi? {MtEx1.IsFibunachi(node1)}");

            Console.WriteLine(MtEx1.ReturnFibonacciSeries(4));
            Console.WriteLine(MtEx1.MaxDiff(intQueue));

        }
    }
}
