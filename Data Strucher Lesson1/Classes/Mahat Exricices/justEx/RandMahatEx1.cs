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

        //2011EX pt.1
        public static void Leaves(BinNode<int> root, Stack<int> stack)
        {
            if (root == null)
                return;

            Leaves(root.GetRight(), stack);
            stack.Push(root.GetValue());
            Leaves(root.GetLeft(), stack);
        }

        //2011EX pt.1
        //public static bool AreTreesEquales(BinNode<int> root1, BinNode<int> root2)
        //{
        //    if(root1 == null && root2 == null)
        //        return true;

        //    if ((root1 == null && root2 != null) || (root1 != null && root2 == null))
        //    {
        //        return false; // One tree is empty while the other is not
        //    }

        //    Stack<int> stack1 = new Stack<int>();
        //    Stack<int> stack2 = new Stack<int>();

        //    Leaves(root1, stack1);
        //    Leaves(root2, stack2);

        //}


    }

    public class RunRandMahatEx1
    {
        public static void DemoMain()
        {
            //Binary tree exsample
            var root = new BinNode<int>(10);
            var leftChild = new BinNode<int>(5);
            var rightChild = new BinNode<int>(15);
            root.SetLeft(leftChild);
            root.SetRight(rightChild);
            leftChild.SetLeft(new BinNode<int>(3));
            leftChild.SetRight(new BinNode<int>(7));
            rightChild.SetLeft(new BinNode<int>(12));
            rightChild.SetRight(new BinNode<int>(18));

            // Example usage
            Stack<int> stack = new Stack<int>();
            stack.Push(2);
            stack.Push(5);
            stack.Push(7);
            stack.Push(4);
            stack.Push(2);
            stack.Push(1);
            stack.Push(3);
            Stack<int> testStack = new Stack<int>();
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

            RandMahatEx1.Leaves(root, testStack);

            Console.WriteLine(testStack);


        }
    }
}
