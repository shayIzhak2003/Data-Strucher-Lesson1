using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class StackExForSummer
    {
        public static Stack<T> CloneStack<T>(Stack<T> stack)
        {
            Stack<T> StackTemp = new Stack<T>();
            Stack<T> ResultTemp = new Stack<T>();


            while (!stack.IsEmpty())
            {
                T currentValue = stack.Pop();
                StackTemp.Push(currentValue);
            }


            while (!StackTemp.IsEmpty())
            {
                T currentValue = StackTemp.Pop();
                stack.Push(currentValue);
                ResultTemp.Push(currentValue);
            }

            return ResultTemp;
        }

        //EX1
        public static int CountStack<T>(Stack<T> stack)
        {
            Stack<T> clonedStack = CloneStack(stack);
            int count = 0;


            while (!clonedStack.IsEmpty())
            {
                clonedStack.Pop();
                count++;
            }

            return count;
        }
        //EX2
        public static Stack<T> RevarsedStack<T>(Stack<T> stack)
        {
            Stack<T> clonedStack = CloneStack(stack);
            Stack<T> revaredStack = new Stack<T>();
            while (!clonedStack.IsEmpty())
            {
                T currentValue = clonedStack.Pop();
                revaredStack.Push(currentValue);
            }
            return revaredStack;
        }
        //EX3
        public static int SumStack(Stack<int> stack)
        {
            Stack<int> clonedStack = CloneStack(stack);
            int sum = 0;
            while (!clonedStack.IsEmpty())
            {
                int currentValue = clonedStack.Pop();
                sum += currentValue;
            }
            return sum;
        }
        //EX4
        public static int MaxValueInStack(Stack<int> stack)
        {
            Stack<int> clonedStack = CloneStack(stack);
            int max = 0;
            while (!clonedStack.IsEmpty())
            {
                int currentValue = clonedStack.Pop();
                if (currentValue > max)
                {
                    max = currentValue;
                }
            }
            return max;
        }
        //EX5
        public static Stack<int> GreaterAvrg(Stack<int> stack)
        {
            Stack<int> clonedStack = CloneStack(stack);
            Stack<int> resultStack = new Stack<int>();
            Stack<int> clonedStack2 = CloneStack(stack);
            int sum = 0;
            int length = 0;
            while (!clonedStack.IsEmpty())
            {
                length++;
                int currentValue = clonedStack.Pop();
                sum += currentValue;
            }
            int avg = sum / length;
            while (!clonedStack2.IsEmpty())
            {
                int currentValue = clonedStack2.Pop();
                if (currentValue > avg)
                {
                    resultStack.Push(currentValue);
                }
            }
            return resultStack;
        }
        //EX6
        public static int FindPlace(Stack<char> stack, char charValue)
        {
            Stack<char> clonedStack = CloneStack(stack);
            int index = 0;
            int nothingToShow = -1;

            while (!clonedStack.IsEmpty())
            {
                char currentValue = clonedStack.Pop();
                if (currentValue == charValue)
                {
                    return index;
                }
                else
                {
                    index++;
                }
            }
            return nothingToShow;
        }
        //EX7
        public static void InsertEnd(Stack<char> stack)
        {
            Stack<char> tempChar = new Stack<char>();

            while (!stack.IsEmpty())
            {
                char currentValue = stack.Pop();
                tempChar.Push(currentValue);
            }
            Console.Write("hello there, please enter a char =>");
            char charValue = char.Parse(Console.ReadLine());
            stack.Push(charValue);
            while (!tempChar.IsEmpty())
            {
                char currentValue = tempChar.Pop();
                stack.Push(currentValue);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"the stack is: {stack}");
            Console.ResetColor();
        }
        //EX8
        public static Stack<char> DeleteItem(Stack<char> stkc, char ch)
        {
            Stack<char> tempChar = new Stack<char>();
            while (!stkc.IsEmpty())
            {
                char currentValue = stkc.Pop();
                if (currentValue != ch)
                {
                    tempChar.Push(currentValue);
                }
            }
            while (!tempChar.IsEmpty())
            {
                char currentValue = tempChar.Pop();
                stkc.Push(currentValue);
            }
            return stkc;
        }
        //EX9
        public static Stack<T> Merge_2_Stacks<T>(Stack<T> stack1, Stack<T> stack2)
        {
            Stack<T> clonedStack1 = CloneStack(stack1);
            Stack<T> clonedStack2 = CloneStack(stack2);
            Stack<T> resultStack = new Stack<T>();

            while (!clonedStack1.IsEmpty())
            {
                T currentValue = clonedStack1.Pop();
                resultStack.Push(currentValue);
            }
            while (!clonedStack2.IsEmpty())
            {
                T currentValue = clonedStack2.Pop();
                resultStack.Push(currentValue);
            }
            return resultStack;
        }
    }
    public class RunStackExForSummer
    {
        public static void DemoMain()
        {
            // Create the first stack
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);

            // Create the second stack
            Stack<int> stack2 = new Stack<int>();
            stack2.Push(10);
            stack2.Push(20);
            stack2.Push(30);
            // Create Char Stack
            Stack<char> charStack = new Stack<char>();
            charStack.Push('a');
            charStack.Push('b');
            charStack.Push('c');
            charStack.Push('d');

            Console.WriteLine($"the original stack {StackExForSummer.CloneStack(stack1)}");
            Console.WriteLine($"the object count in the stack is {StackExForSummer.CountStack(stack1)}");
            Console.WriteLine($"the reversed stack {StackExForSummer.RevarsedStack(stack1)}");
            Console.WriteLine($"the sum of the stack is: {StackExForSummer.SumStack(stack1)}");
            Console.WriteLine($"the max value in the stack is: {StackExForSummer.MaxValueInStack(stack1)}");
            Console.WriteLine($"the stack of the objects that are bigger the the avarge: {StackExForSummer.GreaterAvrg(stack1)}");
            Console.WriteLine($"the char a index is in {StackExForSummer.FindPlace(charStack, 'a')}");
            StackExForSummer.InsertEnd(charStack);
            Console.WriteLine($"he list after deleting c: {StackExForSummer.DeleteItem(charStack, 'c')}");
            Console.WriteLine($"the two stacks combained : {StackExForSummer.Merge_2_Stacks(stack1,stack2)}");

        }
    }

}
