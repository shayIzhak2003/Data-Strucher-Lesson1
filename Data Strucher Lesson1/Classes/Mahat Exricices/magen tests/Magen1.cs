using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices.magen_tests
{
    public class Magen1
    {

        //EX1

        public static int Count(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            int count = 0;
            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
                count++;
            }
            return count;
        }
        public static bool CheckStackPalindrome(Stack<int> stack)
        {
            if (stack == null || stack.IsEmpty())
                return false;

            Stack<int> tempStack = new Stack<int>();
            Stack<int> firstPart = new Stack<int>();
            Stack<int> secondPart = new Stack<int>();
            Stack<int> thirdPart = new Stack<int>();

            int totalSize = Count(stack);
            if (totalSize % 3 != 0) // Ensure stack can be divided into three equal parts
                return false;

            int thirdSize = totalSize / 3;

            // First third
            for (int i = 0; i < thirdSize; i++)
            {
                firstPart.Push(stack.Pop());
            }

            // Second third
            for (int i = 0; i < thirdSize; i++)
            {
                secondPart.Push(stack.Pop());
            }

            // Third third
            for (int i = 0; i < thirdSize; i++)
            {
                thirdPart.Push(stack.Pop());
            }

            // Reverse secondPart
            while (!secondPart.IsEmpty())
            {
                tempStack.Push(secondPart.Pop());
            }

            if (Count(firstPart) != Count(tempStack))
                return false;

            // Compare firstPart and reversed secondPart
            while (!firstPart.IsEmpty() && !tempStack.IsEmpty())
            {
                if (firstPart.Pop() != tempStack.Pop())
                    return false;
            }

            // Reverse secondPart back to its original order
            while (!tempStack.IsEmpty())
            {
                secondPart.Push(tempStack.Pop());
            }

            if (Count(secondPart) != Count(thirdPart))
                return false;

            // Compare secondPart and thirdPart
            while (!secondPart.IsEmpty() && !thirdPart.IsEmpty())
            {
                if (secondPart.Pop() != thirdPart.Pop())
                    return false;
            }

            return true;
        }



        //EX2
        public static int QueueToNumber(Queue<int> queue)
        {
            int number = 0;

            while (!queue.IsEmpty())
            {
                number = number * 10 + queue.Remove();
            }

            return number;
        }

    }
    public class RunMagen1
    {
        public static void DemoMain()
        {
            Queue<int> queue = new Queue<int>();
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(3);
            Console.WriteLine(queue);
            Console.WriteLine(Magen1.QueueToNumber(queue));

            Console.WriteLine("stack section!");

            Stack<int> stack = new Stack<int>();

            // הכנס נתונים לדוגמה - מחסנית עם 9 איברים שמתאימה לפלינדרום בשלישים
            int[] data = { 1, 2, 3, 3, 2, 1, 1, 2, 3 }; // פלינדרום בשלישים

            // הכנסה למחסנית
            for (int i = data.Length - 1; i >= 0; i--)
            {
                stack.Push(data[i]);
            }

            Console.WriteLine(Magen1.CheckStackPalindrome(stack));
        }
    }
}
