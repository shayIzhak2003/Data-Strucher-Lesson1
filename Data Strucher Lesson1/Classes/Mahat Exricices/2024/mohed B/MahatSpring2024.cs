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

            while(secondPos != null)
            {
                if(secondCounter == 0)
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

                if(secondPos.GetValue() < middleValue)
                {
                    isBigger = true;
                }
                secondCounter++;
                secondPos = secondPos.GetNext();
            }
            return !isBigger && startValue == endValue;

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
            stack2.Push(3);
            stack2.Push(6);
            stack2.Push(7);
            stack2.Push(4);
            stack2.Push(2);

            Stack<int> stack3 = new Stack<int>();
            stack3.Push(5);
            stack3.Push(3);
            stack3.Push(1);
            stack3.Push(8);
            stack3.Push(6);
            stack3.Push(4);

            // queue section 
            Queue<int> q1 = new Queue<int>();
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(4);
            q1.Insert(5);

            //List section
            // יצירת רשימה מקושרת: 5 -> 7 -> 10 -> 7 -> 5
            Node<int> chain = new Node<int>(5,
                new Node<int>(7,
                    new Node<int>(3,
                        new Node<int>(7,
                            new Node<int>(5, null)))));


            Console.WriteLine(MahatSpring2024.IsOrdered(stack1)); // true
            Console.WriteLine(MahatSpring2024.IsOrdered(stack2)); // false
            Console.WriteLine(MahatSpring2024.IsOrdered(stack3)); // true
            Console.WriteLine("========");
            Console.WriteLine(q1);
            MahatSpring2024.UpdateQueue(q1);
            Console.WriteLine(q1);
            Console.WriteLine("List Section");
            Console.WriteLine();
            Console.WriteLine(MahatSpring2024.IsMiracle(chain));

        }
    }

}
