using Data_Strucher_Lesson1.Classes.Queue;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.mohed_B
{
    public class MahatSpring2024
    {
        //EX1
        public static bool IsOrdered(Stack<int> st)
        {
            if (st.IsEmpty()) return true; // מחסנית ריקה נחשבת כמסודרת

            Stack<int> tempStack = new Stack<int>(); // מחסנית עזר
            bool foundOdd = false; // האם מצאנו מספר אי-זוגי?
            bool isOrdered = true; // האם המחסנית מסודרת?

            // מעבר על כל האיברים
            while (!st.IsEmpty())
            {
                int num = st.Pop();
                tempStack.Push(num);

                if (num % 2 == 0) // אם המספר זוגי
                {
                    if (foundOdd) // אם כבר ראינו אי-זוגי, הסדר לא נכון
                        isOrdered = false;
                }
                else // אם המספר אי-זוגי
                {
                    foundOdd = true; // מעכשיו כל המספרים חייבים להיות אי-זוגיים
                }
            }

            // החזרת הנתונים למחסנית המקורית
            while (!tempStack.IsEmpty())
                st.Push(tempStack.Pop());

            return isOrdered;
        }
        //EX2
        public static void UpdateQueue(Queue<int> qu)
        {
            if (qu.IsEmpty()) return; // אם התור ריק, אין מה לעשות

            Queue<int> temp = new Queue<int>();
            int length = 0;

            // ספירת האורך
            while (!qu.IsEmpty())
            {
                length++;
                temp.Insert(qu.Remove());
            }

            int mid1 = length / 2; // המיקום הראשון למחיקה
            int mid2;

            // אם האורך זוגי מוחקים שניים, אחרת רק אחד
            if (length % 2 == 0)
            {
                mid2 = mid1 - 1;
            }
            else
            {
                mid2 = mid1;
            }

            int currentCounter = 0;

            // החזרת האיברים לתור תוך דילוג על האמצעי (או שניים אם אורך זוגי)
            while (!temp.IsEmpty())
            {
                int currentValue = temp.Remove();
                if (currentCounter != mid1 && currentCounter != mid2)
                {
                    qu.Insert(currentValue);
                }
                currentCounter++;
            }
        }

        // EX3
        public static bool IsMiracle(Node<int> chain)
        {
            int count = 0;
            int secondCounter = 0;
            Node<int> pos = chain;
            Node<int> secondPos = chain;
            int startValue = 0;
            int middleValue = 0;
            int endValue = 0;
            bool isBigger = false;

            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }

            while (secondPos != null)
            {
                if (secondCounter == 0)
                {
                    startValue = secondPos.GetValue();
                }
                if (secondCounter == count / 2)
                {
                    middleValue = secondPos.GetValue();
                }
                if (secondPos.GetNext() == null)
                {
                    endValue = secondPos.GetValue();
                }

                if (secondPos.GetValue() < middleValue)
                {
                    isBigger = true;
                }
                secondCounter++;
                secondPos = secondPos.GetNext();
            }
            return !isBigger && startValue == endValue;

        }
        // the run time function is O(N * N)

        //EX4
        // the answer in the notbook

        //EX5
        // DO IT LATER.....

        //EX6 pt.1
        public static bool IsBottomStack(Stack<int> s1, Stack<int> s2)
        {
            Stack<int> tempS1 = new Stack<int>();
            Stack<int> tempS2 = new Stack<int>();

            // Copy s1 to tempS1 (to preserve original s1)
            Stack<int> copyS1 = new Stack<int>();
            Stack<int> reverseS1 = new Stack<int>();
            while (!s1.IsEmpty())
            {
                int value = s1.Pop();
                reverseS1.Push(value);
                copyS1.Push(value);
            }
            while (!copyS1.IsEmpty()) s1.Push(copyS1.Pop()); // Restore original s1

            // Copy s2 to tempS2 (to preserve original s2)
            Stack<int> copyS2 = new Stack<int>();
            while (!s2.IsEmpty())
            {
                int value = s2.Pop();
                copyS2.Push(value);
                tempS2.Push(value);
            }
            while (!copyS2.IsEmpty()) s2.Push(copyS2.Pop()); // Restore original s2

            // Find the bottom part of s2 that should match s1
            while (!tempS2.IsEmpty() && !reverseS1.IsEmpty())
            {
                if (tempS2.Pop() != reverseS1.Pop())
                {
                    return false;
                }
            }

            return reverseS1.IsEmpty(); // True only if all s1 elements were found at bottom of s2
        }
        //EX6 pt.2
        public static Stack<int> LongestCommonBottom(Stack<int> s1, Stack<int> s2)
        {
            Stack<int> reverseS1 = new Stack<int>();
            Stack<int> reverseS2 = new Stack<int>();
            Stack<int> commonBottom = new Stack<int>();

            // העתקת S1 לסדר הפוך
            Stack<int> copyS1 = new Stack<int>();
            while (!s1.IsEmpty())
            {
                int value = s1.Pop();
                reverseS1.Push(value);
                copyS1.Push(value);
            }
            while (!copyS1.IsEmpty()) s1.Push(copyS1.Pop()); // שחזור S1

            // העתקת S2 לסדר הפוך
            Stack<int> copyS2 = new Stack<int>();
            while (!s2.IsEmpty())
            {
                int value = s2.Pop();
                reverseS2.Push(value);
                copyS2.Push(value);
            }
            while (!copyS2.IsEmpty()) s2.Push(copyS2.Pop()); // שחזור S2

            // השוואת התחתיות הארוכות ביותר
            while (!reverseS1.IsEmpty() && !reverseS2.IsEmpty() && reverseS1.Top() == reverseS2.Top())
            {
                commonBottom.Push(reverseS1.Pop());
                reverseS2.Pop(); // להסיר גם מ-S2
            }

            return commonBottom;

            // two of the functions runtime function is O(N * N)
        }

        //EX7
        public static bool IsFibonacci(Node<int> chain)
        {
            if (chain == null || chain.GetNext() == null || chain.GetNext().GetNext() == null)
                return false; // A Fibonacci sequence needs at least three numbers

            Node<int> first = chain;
            Node<int> second = first.GetNext();
            Node<int> third = second.GetNext();

            while(third != null)
            {
                if(third.GetValue() != first.GetValue() + second.GetValue())
                    return false;

                first = second;
                second = third;
                third = third.GetNext();
            }
            return true;
        }

        //EX8
        public static bool IsDownBinaryTree(BinNode<int> root)
        {
            if(root == null)
                return true;

            if((root.GetLeft() == null || root.GetRight() == null) ||
                root.GetValue() < root.GetLeft().GetValue() ||
                root.GetValue() < root.GetRight().GetValue())
            {
                return false;
            }

            return IsDownBinaryTree(root.GetLeft()) && IsDownBinaryTree(root.GetRight());
        }

        //EX9 pt.1
        public static int MaxDiff(Queue<int> q)
        {
            Queue<int> cloneQ1 = QEx.CloneQueue1(q);
            int firstValue = cloneQ1.Remove(); // Take the first element as a reference
            int max = firstValue;
            int min = firstValue;
            while (!cloneQ1.IsEmpty())
            {
                int currentValue = cloneQ1.Remove();
                if (currentValue < min)
                {
                    min = currentValue;
                }
                if (currentValue > max)
                {
                    max = currentValue;
                }
               
            }
            return max - min;
         
            
        }
    }
    public class RunMahatSpring2024
    {
        public static void DemoMain()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(3);
            stack1.Push(5);
            stack1.Push(6);
            stack1.Push(8);

            Stack<int> stack2 = new Stack<int>();
            stack2.Push(1);
            stack2.Push(3);
            stack2.Push(2);

            Stack<int> stack3 = new Stack<int>();
            stack3.Push(5);
            stack3.Push(3);
            stack3.Push(1);
            stack3.Push(8);
            stack3.Push(6);
            stack3.Push(4);

            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            // מילוי s1 בערכים מסוימים
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);

            // מילוי s2 כך שהחלק התחתון שלו זהה ל-s1
            s2.Push(1);
            s2.Push(2);
            s2.Push(3);
            s2.Push(4);
            s2.Push(5);

            // queue section 
            Queue<int> q1 = new Queue<int>();
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(4);
            q1.Insert(5);

            //List section
            // יצירת רשימה מקושרת: 5 -> 7 -> 10 -> 7 -> 5
            Node<int> chain = new Node<int>(1,
                new Node<int>(1,
                    new Node<int>(2,
                        new Node<int>(3,
                            new Node<int>(5, null)))));


            //Console.WriteLine(MahatSpring2024.IsOrdered(stack1)); // true
            //Console.WriteLine(MahatSpring2024.IsOrdered(stack2)); // false
            //Console.WriteLine(MahatSpring2024.IsOrdered(stack3)); // true
            Console.WriteLine("========");
            //Console.WriteLine(q1);
            //MahatSpring2024.UpdateQueue(q1);
            Console.WriteLine(q1);
            Console.WriteLine("List Section");
            Console.WriteLine();
            Console.WriteLine(MahatSpring2024.IsMiracle(chain));
            Console.WriteLine($"the max gap in the queue is :=> {MahatSpring2024.MaxDiff(q1)}");

            Console.WriteLine("Stack Section!");
            Console.WriteLine("========");
            Console.WriteLine($"is s1 substack of s2? {MahatSpring2024.IsBottomStack(s1, s2)}");
            Console.WriteLine($"the result stack: {MahatSpring2024.LongestCommonBottom(s1, s2)}");
            Console.WriteLine($"is the node is a fibunachii? {MahatSpring2024.IsFibonacci(chain)}");

        }
    }

}
