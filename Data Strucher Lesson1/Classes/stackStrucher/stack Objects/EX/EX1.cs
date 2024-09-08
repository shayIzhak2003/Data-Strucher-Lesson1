using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.EX
{
    public class EXOfSummer1
    {
        public static int count_stackf<T>(Stack<T> stck)
        {
            Stack<T> tempStack = new Stack<T>();
            int counter = 0;

            while (!stck.IsEmpty())
            {
                counter++;
                T value = stck.Pop();
                tempStack.Push(value);
            }
            while (!tempStack.IsEmpty())
            {
                T value = tempStack.Pop();
                stck.Push(value);
            }
            return counter;
        }
        public static Stack<T> reverse_stack<T>(Stack<T> stkc)
        {
            Stack<T> tempStack = new Stack<T>();
            while (!stkc.IsEmpty())
            {
                T value = stkc.Pop();
                tempStack.Push(value);
            }
            return tempStack;
        }
        public static int sum_stack(Stack<int> stack)
        {
            int sum = 0;
            Stack<int> tempStack = new Stack<int>();
            while (!stack.IsEmpty())
            {
                int value = stack.Pop();
                sum += value;
                tempStack.Push(value);
            }
            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                stack.Push(value);
            }
            return sum;
        }
        public static int max_stack(Stack<int> stack)
        {
            int max = stack.Pop();
            Stack<int> tempStack = new Stack<int>();
            while (!stack.IsEmpty())
            {
                int value = stack.Pop();
                if (value > max)
                {
                    max = value;
                }
                tempStack.Push(value);
            }
            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                stack.Push(value);
            }
            return max;
        }
        public static Stack<int> greater_avrg(Stack<int> stkc)
        {
            Stack<int> tempStack = new Stack<int>();
            Stack<int> resultStack = new Stack<int>();
            int sum = 0;
            int count = 0;
            while (!stkc.IsEmpty())
            {
                int value = stkc.Pop();
                sum += value;
                count++;
                tempStack.Push(value);
            }
            Console.WriteLine(sum);
            int avg = sum / count;
            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                stkc.Push(value);
                if(value > avg)
                {
                    resultStack.Push(value);
                }
            }
            return resultStack;
        }
        public static int find_place(Stack<char> stkc, char ch)
        {
            int index = -1;
            int count = 0;
            Stack<char> tempStack = new Stack<char>();
            while (!stkc.IsEmpty())
            {
                count++;
                char value = stkc.Pop();
                if(value == ch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("the value is found!");
                    Console.ResetColor();
                    index = count;
                    return count;
                }
                tempStack.Push((char)value);

            }
            while (!tempStack.IsEmpty())
            {
                char value = tempStack.Pop();
                stkc.Push((char)value);
            }
            return index;

        }
    }
    public class RunExOfSummer1
    {
        public static void DemoMain1()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
            stack1.Push(6);
            // char stack
            Stack<char> stack2 = new Stack<char>();
            stack2.Push('a');
            stack2.Push('b');
            stack2.Push('c');
            stack2.Push('d');

            Console.WriteLine("the original stack :");
            Console.WriteLine(stack1.ToString());
            Console.WriteLine($"the stack count is : {EXOfSummer1.count_stackf(stack1)}");
            //Console.WriteLine($"the revarsed stack is : {EXOfSummer1.reverse_stack(stack1)}");
            Console.WriteLine($"the sum of the stack is : {EXOfSummer1.sum_stack(stack1)}");
            Console.WriteLine($"the max value in the stack is : {EXOfSummer1.max_stack(stack1)}");
            Console.WriteLine($"the vslues that are bigger then the stack avarge : {EXOfSummer1.greater_avrg(stack1)}");
            Console.WriteLine($"the char C index is : {EXOfSummer1.find_place(stack2, 'b')}");
        }
    }
}
