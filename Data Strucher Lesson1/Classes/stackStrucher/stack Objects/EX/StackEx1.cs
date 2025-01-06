using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.EX
{
    public class StackEx1
    {
        public static bool CheckForValidStack(Stack<char> stack)
        {
            char prev = 'O';
            while (!stack.IsEmpty())
            {
                char current = stack.Pop();
                if ((prev == 'O' || prev == 'A') && (current != 'F' && current != 'T'))
                    return false;
                if ((prev == 'T' || prev == 'F') && (current != 'A' && current != 'O'))
                    return false;
                if ((current == 'O' || current == 'A') && stack.IsEmpty())
                    return false;
                prev = current;
            }
            return true;
        }

        public class RunStackEx1
        {
            public static void DemoMain()
            {
                Stack<char> stack = new Stack<char>();
                stack.Push('F');
                stack.Push('O');
                stack.Push('T');
                stack.Push('A');
                stack.Push('T');
                Console.WriteLine($"is the stack valid? {StackEx1.CheckForValidStack(stack)}");
            }
        }
    }
    }
