using Data_Strucher_Lesson1.Classes.stackStrucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.exrisice_for_summer_smaster
{
    public class StackEx
    {
        //EX1
        public static int Count_Stack<T>(Stack<T> stack)
        {
            Stack<T> tempStack = new Stack<T>();
            int count = 0;
            while (!stack.IsEmpty())
            {
                tempStack.Push(stack.Pop());
                count++;
            }
            while (!tempStack.IsEmpty())
            {
                stack.Push(tempStack.Pop());
            }
            return count;
        }
        //EX2
        public static Stack<T> reverse_stack<T>(Stack<T> stack)
        {
            Stack<T> tempStack = new Stack<T>();
            while (!stack.IsEmpty())
            {
                tempStack.Push(stack.Pop());
            }
            return tempStack;
        }
        //EX3
        public static int Sum_Stack(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();
            int sum = 0;
            int value = 0;
            while (!stack.IsEmpty())
            {
                value = stack.Pop();
                sum += value;
                tempStack.Push((int)value);
            }
            while (!tempStack.IsEmpty())
            {
                stack.Push((int)tempStack.Pop());
            }
            return sum;
        }
        //EX4
        public static int Max_Stack(Stack<int> stack)
        {
            int max = stack.Top();
            int value = 0;
            Stack<int> tempStack = new Stack<int>();
            while (!stack.IsEmpty())
            {
                value = stack.Pop();
                tempStack.Push((int)value);
                if (value > max)
                {
                    max = value;
                }
            }
            while (!tempStack.IsEmpty())
            {
                stack.Push(tempStack.Pop());
            }
            return max;
        }

        //EX5
        public static Stack<int> greater_avrg(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();
            Stack<int> resultStack = new Stack<int>();
            int avg = 0;
            int sum = 0;
            int count = 0;
            while (!stack.IsEmpty())
            {
                int value = stack.Pop();
                tempStack.Push(value);
                count++;
                sum += value;
            }

            avg = sum / count;

            while (!tempStack.IsEmpty())
            {
                int finalValue = tempStack.Pop();
                if (finalValue > avg)
                {
                    resultStack.Push(finalValue);
                }
            }
            return resultStack;


        }
        //EX6
        public static int find_place(Stack<char> stack, char ch)
        {
            int count = 0;
            Stack<char> tempStack = new Stack<char>();
            while (!stack.IsEmpty())
            {
                char value = stack.Pop();
                tempStack.Push((char)value);
            }
            while (!tempStack.IsEmpty())
            {

                char finalValue = tempStack.Pop();
                stack.Push((char)finalValue);
                if (finalValue == ch)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
        //EX7
        public static void Insert_End(Stack<char> stack)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter a character to insert at the end of the stack:");
            char ch = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.WriteLine($"the original stack : {stack.ToString()}");

            Stack<char> tempStack = new Stack<char>();
            while (!stack.IsEmpty())
            {
                char value = stack.Pop();
                tempStack.Push((char)value);
            }
            stack.Push(ch);
            while (!tempStack.IsEmpty())
            {
                char finalValue = tempStack.Pop();
                stack.Push((char)finalValue);
            }

            Console.WriteLine("the stack is :");
            Console.WriteLine(stack.ToString());
            Console.ResetColor();
        }

        //EX8
        public static Stack<char> delete_item(Stack<char> stkc, char ch)
        {
            Stack<char> tempStack = new Stack<char>();
            while (!stkc.IsEmpty())
            {
                char value = stkc.Pop();
                if(value != ch)
                {
                    tempStack.Push((char)value);
                }
            }
            while (!tempStack.IsEmpty())
            {
                char finalValue = tempStack.Pop();
                stkc.Push((char)finalValue);
            }
            return stkc;

        }
        //EX9
        public static Stack<T> Merge_2_Stacks<T>(Stack<T> stack1, Stack<T> stack2)
        {
            Stack<T> mergedStack = new Stack<T>();
            while (!stack1.IsEmpty() && !stack2.IsEmpty())
            {
                T value = stack1.Pop();
                T value2 = stack2.Pop();
                mergedStack.Push(value);
                mergedStack.Push(value2);
            }

            // אם נותרו אלמנטים במחסנית הראשונה
            while (!stack1.IsEmpty())
            {
                mergedStack.Push(stack1.Pop());
            }

            // אם נותרו אלמנטים במחסנית השנייה
            while (!stack2.IsEmpty())
            {
                mergedStack.Push(stack2.Pop());
            }

            // הופכים את המחסנית הממוזגת כדי לשמור על הסדר הנכון
            Stack<T> finalStack = new Stack<T>();
            while (!mergedStack.IsEmpty())
            {
                finalStack.Push(mergedStack.Pop());
            }
            return finalStack;
        }
    }
    public class RunStackEX
    {
        public static void DemoMain()
        {
            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //stack.Push(5);
            //stack.Push(6);
            //int count = StackEx.Count_Stack(stack);
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine($" EX1 = the amount of objects that are inside the stacks are : {count}");
            //Console.ResetColor();

            //Console.ForegroundColor = ConsoleColor.Yellow;
            ////Console.WriteLine($" EX2 = the original stack is {stack} , ");
            ////Stack<int>MainStack = StackEx.reverse_stack(stack);

            //int sum = StackEx.Sum_Stack(stack);
            //Console.WriteLine($" EX3 = the sum of the stack is : {sum}");

            //int max = StackEx.Max_Stack(stack);
            //Console.WriteLine($"the max value in stack is : {max}");



            //Stack<char> stack2 = new Stack<char>();
            //stack2.Push('a');
            //stack2.Push('b');
            //stack2.Push('c');
            //stack2.Push('d');
            //Console.WriteLine($"the index of the char C is : {StackEx.find_place(stack2, 'c')}");
            ////Console.WriteLine($"the result stack is {StackEx.greater_avrg(stack)}");
            ////Console.WriteLine($" the revarsed stack : {MainStack}");
            //Console.ResetColor();
            ////StackEx.Insert_End(stack2);
            //Console.WriteLine($"the original stack : {stack2.ToString()}");
            //Console.WriteLine("the list after deleting C");
            //Console.WriteLine(StackEx.delete_item(stack2, 'c'));


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

            // Merge the two stacks
            Stack<int> mergedStack = StackEx.Merge_2_Stacks(stack1, stack2);
            Console.WriteLine(mergedStack.ToString());


        }
    }
}
