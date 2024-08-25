using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher
{
    public class Lesson1
    {
        //EX1
        public static int count_stack<T>(Stack<T> stkc)
        {
            int count = 0;
            Stack<T> tempStack = new Stack<T>();

           
            while (!stkc.IsEmpty())
            {
                tempStack.Push(stkc.Pop());
                count++;
            }

            while (!tempStack.IsEmpty())
            {
                stkc.Push(tempStack.Pop());
            }

            return count;
        }
        //EX2
        public static Stack<int> reverse_stack(Stack<int> stkc)
        {
            Stack<int> tempStack = new Stack<int>();

            while (!stkc.IsEmpty())
            {
                tempStack.Push(stkc.Pop());
            }
          
            return tempStack;
        }

        //EX3
        public static int Sum_stack(Stack<int> stkc)
        {
            int sum = 0;
            while (!stkc.IsEmpty())
            {
               
                sum += stkc.Pop();
            }
            return sum;
        }
        //EX4
        public static int Max(Stack<int> stkc)
        {
            if (stkc.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            Stack<int> tempStack = new Stack<int>();
            int max = stkc.Top(); // Initialize max with the top element

            // Iterate through the stack to find the max value
            while (!stkc.IsEmpty())
            {
                int current = stkc.Pop();
                if (current > max)
                {
                    max = current;
                }
                tempStack.Push(current); // Push the element to the temp stack to preserve it
            }

            // Restore the original stack
            while (!tempStack.IsEmpty())
            {
                stkc.Push(tempStack.Pop());
            }

            return max;
        }

        //EX5
        public static Stack<int> greater_avrg(Stack<int> stkc)
        {
            int sum = 0;
            int count = 0;
            Stack<int> tempStack = new Stack<int>();
            Stack<int> resultStack = new Stack<int>();

            // Calculate sum and count
            while (!stkc.IsEmpty())
            {
                int value = stkc.Pop();
                sum += value;
                count++;
                tempStack.Push(value);
            }

            // Calculate the average
            int avg = (count > 0) ? sum / count : 0;

            // Find elements greater than average and restore the original stack
            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                stkc.Push(value); // Restore original stack
                if (value > avg)
                {
                    resultStack.Push(value);
                }
            }

            return resultStack;
        }

        //EX6
        public static int find_place(Stack<char> stkc, char ch)
        {
            Stack<char> tempStack = new Stack<char>(); // Use Stack<char> instead of Stack<int>
            int count = 0;

            while (!stkc.IsEmpty()) // Corrected the condition to !stkc.IsEmpty()
            {
                count++;
                if (stkc.Top() == ch)
                {
                    // Restore the original stack before returning
                    while (!tempStack.IsEmpty())
                    {
                        stkc.Push(tempStack.Pop());
                    }
                    return count;
                }
                tempStack.Push(stkc.Pop());
            }

            // Restore the original stack if the element is not found
            while (!tempStack.IsEmpty())
            {
                stkc.Push(tempStack.Pop());
            }

            return -1; // Return -1 if the character is not found
        }
        //EX7


    }
    public class RunLesson1
    {
        public static void DemoMain()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int count = Lesson1.count_stack(stack);
            Console.WriteLine($"Number of elements in the stack: {count}");
            Console.WriteLine(Lesson1.greater_avrg(stack));
            //Console.WriteLine("Original stack: " + stack.ToString());
            //Console.WriteLine("Revarsed stack:" + Lesson1.reverse_stack(stack));

            //Console.WriteLine($"the sum of the stack is : {Lesson1.Sum_stack(stack)}");
            //Console.WriteLine($"the max value is {Lesson1.Max(stack)}");

            // char stack section

            Stack<char> stack2 = new Stack<char>();
            stack2.Push('a');
            stack2.Push('b');
            stack2.Push('c');
            stack2.Push('d');

            char searchChar = 'c';
            int position = Lesson1.find_place(stack2, searchChar);

            Console.WriteLine($"Position of '{searchChar}' in the stack: {position}");

            // Verify the stack remains unchanged
            Console.WriteLine("Stack after search:");
            while (!stack2.IsEmpty())
            {
                Console.WriteLine(stack2.Pop());
            }


        }
    }
}
