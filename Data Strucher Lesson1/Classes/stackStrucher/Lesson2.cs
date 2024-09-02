using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher
{
    public class Lesson2
    {
        // האם סוגריים תקינים - הקוד
        public static bool AreParenthesesOK(string expression)
        {
            Stack<char> s = new Stack<char>();
            bool res = true;
            for (int i = 0; i < expression.Length && res == true; i++)
            {
                char currentChar = expression[i];
                if (currentChar == '(' || currentChar == '[' || currentChar == '{')
                    s.Push(currentChar);
                else if (currentChar == ')' || currentChar == ']' || currentChar == '}')
                {
                    if (s.IsEmpty())
                        return false;
                    char ch = s.Pop();
                    if ((ch == '(' && currentChar != ')') ||
                           (ch == '[' && currentChar != ']') ||
                           (ch == '{' && currentChar != '}'))
                        res = false;
                }
            }
            if (!s.IsEmpty())
                res = false;
            return res;
        }

        // ספירת המופעים של ערך מסויים
        public static int CountValue(Stack<int> s, int val)
        {
            int count = 0;
            Stack<int> temp = new Stack<int>();
            while (!s.IsEmpty())
            {
                int TopValue = s.Pop();
                if (TopValue == val)
                    count++;
                temp.Push(TopValue);
            }
            while (!temp.IsEmpty())
                s.Push(temp.Pop());
            return count;
        }
        // הכנסת ערך למחסנית ממוינת
        public static void InsertValueToSortedStack(Stack<int> s, int val)
        {
            Stack<int> temp = new Stack<int>();
            while (!s.IsEmpty() && val < s.Top())
            {
                temp.Push(s.Pop());
            }
            s.Push(val);
            while (!temp.IsEmpty())
                s.Push(temp.Pop());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        // האם המחסנית ממוינת
        public static bool IsStackSorted(Stack<int> s)
        {
            Stack<int> temp = new Stack<int>();
            while (!s.IsEmpty())
            {
                temp.Push(s.Pop());
                if (s.IsEmpty())
                {
                    while (!s.IsEmpty())
                    {
                        temp.Push(s.Pop());
                    }
                    return true;
                }
                if (s.Top() > temp.Top())
                {
                    while (!s.IsEmpty())
                    {
                        temp.Push(s.Pop());
                    }
                    return false;
                }
            }
            return true; // should never get here
        }
        // סיבוב הערכים במחסנית - הקוד
        public static void RotateStack(Stack<int> s, int rounds)
        {
            Stack<int> temp = new Stack<int>();
            for (int i = 0; i < rounds; i++)
            {
                int top = s.Pop();
                while (!s.IsEmpty())
                    temp.Push(s.Pop());
                s.Push(top);
                while (!temp.IsEmpty())
                    s.Push(temp.Pop());
            }
        }
        // תוכנה שמכניסה את כל האיברים שאין להם רצץ למכסנית חדשה
        public static Stack<int> GetNoneBlockObjects(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();

            while (!stack.IsEmpty())
            {
                // Pop the top element
                int top = stack.Pop();

                if (!stack.IsEmpty())
                {
                    // Pop the element below the top
                    int belowTop = stack.Pop();

                    // If the elements are not the same, push the top element to the temp stack
                    if (top != belowTop)
                    {
                        temp.Push(top);
                    }
                }
                else
                {
                    // If the stack is empty after popping the top element, just push it back to temp
                    temp.Push(top);
                }
            }

            // Reverse the temp stack to preserve original order
            Stack<int> result = new Stack<int>();
            while (!temp.IsEmpty())
            {
                result.Push(temp.Pop());
            }

            return result;
        }

        // זוהי תוכנה שבודקת האם ספרת היחידות של איצ מספרות במחסנית שווה למספר המתקבל כפרמטר
        public static bool IsExist(Stack<int> stk, int num)
        {
            Stack<int>tempStack = new Stack<int>();
            int currentValue = 0;
            if(num < 0 && num > 9)
            {
                throw new ArgumentException("the number should be between 0-9!");
            }
            while (!stk.IsEmpty())
            {
                currentValue = stk.Pop();
                tempStack.Push(currentValue);
                if(currentValue % 10 == num)
                    return true;
            }

            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                stk.Push(value);
            }

            return false;
        }

        public static Stack<int> Clone(Stack<int> st)
        {
            Stack<int> tempStack = new Stack<int>();
            Stack<int> resultStack = new Stack<int>();

            while (!st.IsEmpty())
            {
                int value = st.Pop();
                tempStack.Push(value);
            }
            while (!tempStack.IsEmpty())
            {
                int value = tempStack.Pop();
                st.Push(value);
                resultStack.Push(value);
            }
            return resultStack;
        }
        // פעולת עזר המחזירה את הספרה המשמעותית במספר
        public static int GetMostSignificantDigit(int num)
        {
            while (num > 0)
                num = num / 10;
            return num;
        }
        // 
        public static bool AllExist(Stack<int> stk)
        {

            bool isAllExist = true;
            Stack<int> tmp = new Stack<int>();
            Stack<int> cloneStk = Clone(stk);

            while (!stk.IsEmpty() && isAllExist)
            {
                isAllExist = isAllExist &&
                             IsExist(cloneStk, GetMostSignificantDigit(stk.Top()));

                tmp.Push(stk.Pop());
            }

            while (!tmp.IsEmpty())
                stk.Push(tmp.Pop());

            return isAllExist;

        }
        public static int GetMaxOfStack1(Stack<int> stk)
        {
            int max = 0;
            int temp;
            int currrentValue = stk.Pop();
            while (!stk.IsEmpty())
            {
                temp = currrentValue + stk.Top();
                if(currrentValue > max)
                {
                    max = currrentValue;
                }
                currrentValue = stk.Pop();
            }
            return max;
        }
        public static int MaxCuple(Stack<int> st1, Stack<int> st2)
        {
            int max2 = GetMaxOfStack1(st2);
            int temp = 0;
            int sum = 0;
            bool isBigger = false;
            int currentValue = st1.Pop();
            while (!st1.IsEmpty() && !isBigger)
            {
                sum = currentValue + st1.Top();
                if(sum > max2)
                {
                    isBigger = true;
                }
                else
                {
                    currentValue = st1.Pop();
                }
               
            }
            if (!isBigger)
            {
                sum = 0;
            }
            return sum;
        }

        //public static void Secret()
        //{
        //    Queue<char> q = new Queue<char>(); // Use built-in Queue with Enqueue method
        //    Stack<char> stk = new Stack<char>(); // Use built-in Stack with Push method

        //    bool isReverse = false;

        //    Console.Write("Please enter a character or 'f' to stop: ");
        //    char ch = char.Parse(Console.ReadLine());
        //    while (ch != 'f')
        //    {
        //        if (ch == '@')
        //        {
        //            if (isReverse)  // Empty the stack into the queue
        //            {
        //                while (stk.Count > 0)
        //                    q.Enqueue(stk.Pop()); // Replaced Insert with Enqueue
        //            }
        //            isReverse = !isReverse;
        //        }
        //        else
        //        {
        //            if (isReverse)
        //                stk.Push(ch);
        //            else
        //                q.Enqueue(ch); // Replaced Insert with Enqueue
        //        }

        //        Console.Write("Please enter a character or 'f' to stop: ");
        //        ch = char.Parse(Console.ReadLine());
        //    }

        //    while (q.Count > 0) // Replaced IsEmpty with Count > 0
        //        Console.Write(q.Dequeue());
        //    Console.WriteLine();
        //}


        public class RunLesson2
        {
            public static void DemoMain()
            {
                // Create a sorted stack
                Stack<int> sortedStack = new Stack<int>();
                sortedStack.Push(10);
                sortedStack.Push(8);
                sortedStack.Push(5);
                sortedStack.Push(3);
                sortedStack.Push(1);

                // Print the original sorted stack
                Console.WriteLine("Original Stack: " + sortedStack.ToString());

                // Value to insert
                int valueToInsert = 6;

                // Insert the value into the sorted stack
                InsertValueToSortedStack(sortedStack, valueToInsert);



                // Print the stack after insertion
                Console.WriteLine("Stack after inserting " + valueToInsert + ": " + sortedStack);

                Console.WriteLine("==========");

                // Create a stack with some repeated elements
                Stack<int> stack = new Stack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);
                stack.Push(4);
                stack.Push(555);

                //Console.WriteLine("Original Stack: " + stack.ToString());

                //// Get non-block objects
                //Stack<int> result = GetNoneBlockObjects(stack);

                //// Print the resulting stack after removing blocked objects
                //Console.WriteLine("Non-block objects: " + result.ToString());

                //Console.WriteLine();

                //bool checkStackFirstValue = Lesson2.IsExist(stack, 5);
                //Console.WriteLine(checkStackFirstValue);

                //Console.WriteLine($"the result stack is {Lesson2.Clone(sortedStack)}");
                //Console.WriteLine(Lesson2.AllExist(stack));
                Console.WriteLine(Lesson2.MaxCuple(stack,sortedStack));


            }
        }
    }
}
