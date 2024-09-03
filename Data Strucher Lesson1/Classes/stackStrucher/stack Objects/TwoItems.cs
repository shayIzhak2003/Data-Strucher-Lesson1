using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects
{
    public class TwoItems
    {
        public int num1 { get; set; }
        public int num2 { get; set; }

        public TwoItems(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }
        public static Stack<TwoItems> StackTwoItems(Stack<int> stk)
        {
            {
                Stack<TwoItems> result = new Stack<TwoItems>();
                int last;
                while (!stk.IsEmpty())
                {
                    last = Lesson3.LastAndRemove(stk);  // האיבר האחרון
                                                // מספר האיברים זוגי, לכן המחסנית בוודאות לא ריקה
                    result.Push(new TwoItems(stk.Pop(), last));
                }
                return result;
            }
        }
    }
    public class RunTwoItems
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

            Stack<TwoItems> resultStack = TwoItems.StackTwoItems(stack);

            // Print the result stack to see the pairs
            while (!resultStack.IsEmpty())
            {
                TwoItems item = resultStack.Pop();
                Console.WriteLine($"num1: {item.num1}, num2: {item.num2}");
            }
        }
    }

}
