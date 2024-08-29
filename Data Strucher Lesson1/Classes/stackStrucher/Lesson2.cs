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
                stack.Push(5);

                Console.WriteLine("Original Stack: " + stack.ToString());

                // Get non-block objects
                Stack<int> result = GetNoneBlockObjects(stack);

                // Print the resulting stack after removing blocked objects
                Console.WriteLine("Non-block objects: " + result.ToString());

                Console.WriteLine();
            }
        }
    }
}
