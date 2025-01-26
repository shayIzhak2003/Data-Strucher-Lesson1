using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices.justEx
{
    public class RandMahatEx1
    {
        //2008EX
        public static void InsertDirectionChangingElements(Stack<int> stack)
        {
            if (stack == null || stack.IsEmpty())
                return;

            Stack<int> tempStack = new Stack<int>();

           
            while (!stack.IsEmpty())
            {
                tempStack.Push(stack.Pop());
            }

           
            Stack<int> resultStack = new Stack<int>();
            int prev = tempStack.Pop(); 
            resultStack.Push(prev);

            while (!tempStack.IsEmpty())
            {
                int current = tempStack.Pop();
                resultStack.Push(current);

                if (!tempStack.IsEmpty())
                {
                    int next = tempStack.Top();
                    
                    if ((prev < current && current > next) || (prev > current && current < next))
                    {
                        resultStack.Push(current);
                    }
                }

                prev = current; 
            }


            while (!resultStack.IsEmpty())
            {
                stack.Push(resultStack.Pop());
            }
        }
        //2010EX
        public static int GetBiggerSumOfStacks(Stack<int> st1, Stack<int> st2)
        {
            int sum1 = 0, sum2 = 0;

            // Helper function to calculate the sum of the two elements below the head of a stack
            int CalculateBelowHeadSum(Stack<int> stack)
            {
                if (stack.IsEmpty()) return 0; // If the stack is empty, return 0

                // Pop the head element
                stack.Pop();

                // Check if there are enough elements to sum
                int sum = 0;
                if (!stack.IsEmpty()) sum += stack.Pop(); // Add second element
                if (!stack.IsEmpty()) sum += stack.Pop(); // Add third element

                return sum;
            }

            // Calculate sums for both stacks
            sum1 = CalculateBelowHeadSum(st1);
            sum2 = CalculateBelowHeadSum(st2);

            // Return the greater sum
            return (sum1 > sum2) ? sum1 : sum2;
        }



    }

    public class RunRandMahatEx1
    {
        public static void DemoMain()
        {
            // Example usage
            Stack<int> stack = new Stack<int>();
            stack.Push(2);
            stack.Push(5);
            stack.Push(7);
            stack.Push(4);
            stack.Push(2);
            stack.Push(1);
            stack.Push(3);

            Console.WriteLine("Original stack: " + stack);

            RandMahatEx1.InsertDirectionChangingElements(stack);

            Console.WriteLine("Modified stack: " + stack);
            
            Console.WriteLine("==============");
            // Initialize two stacks
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            // Add elements to stack1
            stack1.Push(10);
            stack1.Push(20);
            stack1.Push(30); // Head
            stack1.Push(30);
            stack1.Push(40);
            Console.WriteLine("Stack 1: " + stack1);

            // Add elements to stack2
            stack2.Push(50);
            stack2.Push(15);
            stack2.Push(25); // Head
            Console.WriteLine("Stack 2: " + stack2);

            // Get the bigger sum of the two values below the head
            int biggerSum = RandMahatEx1.GetBiggerSumOfStacks(stack1, stack2);
            Console.WriteLine($"The bigger sum of the two values below the head is: {biggerSum}");

            // Print stacks after the operation to confirm they're restored
            Console.WriteLine("Stack 1 after operation: " + stack1);
            Console.WriteLine("Stack 2 after operation: " + stack2);
        }
    }
}
