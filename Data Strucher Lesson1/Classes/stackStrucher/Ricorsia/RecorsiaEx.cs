using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.Ricorsia
{
    public class RecorsiaEx2
    {
        //פעולה המקבלת מחסנית של מספרים, ומעדכנת את ערכיה להיות כפולים.
        public static void MultAllValuesRec(Stack<int> s)
        {
            if (s.IsEmpty())
                return;
            int top = s.Pop();
            MultAllValuesRec(s);
            s.Push(top * 2);
        }

        //או, בצורה קצת שונה 
        public static void MultAllValuesRec2(Stack<int> s)
        {
            if (!s.IsEmpty())
            {
                int top = s.Pop();
                MultAllValuesRec2(s);
                s.Push(top * 2);
            }
        }
        // הסרת ערך מהמחסנית באמצעות רקורסיה
        public static void RemoveValueRec(Stack<int> s, int toRemove)
        {
            Stack<int>temp = new Stack<int>();
            if (!s.IsEmpty())
            {
                int top = s.Top();
                if(top == toRemove)
                {
                    s.Pop();
                    return;
                }
                int next = s.Pop();
                temp.Push(top);
                RemoveValueRec(s, toRemove);

            }
            while (!temp.IsEmpty())
            {
                int value = temp.Pop();
                s.Push((int)value);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s.ToString());
            Console.ResetColor();
        }
    }
    public class RunRecorsiaEx2
    {
        public static void DemoMain()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
            stack1.Push(6);
            Console.WriteLine(stack1.ToString());
            RecorsiaEx2.RemoveValueRec(stack1, 5);
            Console.WriteLine(531 % 2 == 1 % 2);
        }
    }
}
