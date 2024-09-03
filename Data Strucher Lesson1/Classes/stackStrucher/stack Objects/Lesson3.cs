using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects
{
    public class Lesson3
    {
        public static int LastAndRemove(Stack<int> st)
        {
            Stack<int> tempStack = new Stack<int>();
            int num = -1;
            int count = 0;
            while (!st.IsEmpty())
            {
                count++;
                int value = st.Pop();
                if(count != 1)
                {
                    tempStack.Push(value);
                }
                else
                {
                    num = value;
                }
                
            }
            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                st.Push(value);
            }
            return num;

        }
    }
    public class RunLesson3
    {
        public static void DemoMain()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(4);
            stack.Push(555);
            Console.WriteLine("the original stack is : ");
            Console.WriteLine(stack.ToString());
            Console.WriteLine(Lesson3.LastAndRemove(stack));
            Console.WriteLine("the stack after the change is : ");
            Console.WriteLine(stack.ToString());
        }
    }
}
