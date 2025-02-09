using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.Summer_mohed_A
{
    public class MahatSummer2024
    {
        //EX1
        public static bool IsBalanced(Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            int countZero = 0;
            int countPositives = 0;
            int countNegatives = 0;

            while (!st.IsEmpty())
            {
                int currentValue = st.Pop();
                temp.Push(currentValue);

                if (currentValue == 0)
                {
                    countZero++;
                }
                else if (currentValue > 0)
                {
                    countPositives++;
                }

                else
                {
                    countNegatives++;
                }
            }

            return countZero == countNegatives && countPositives == countZero;

            // the runtime function is O(N) beacuse in the worst case the loop is running N times 
            // so the runtime function will be O(N).
        }

        //EX2
        public static void UpdateMiddleStack(Queue<int> st, int x, int y)
        {
            Queue<int> temp = new Queue<int>();
            Random rnd = new Random();
            int randomValue = rnd.Next(x, y + 1);
            int counter = 0;
            while (!st.IsEmpty())
            {
                temp.Insert(st.Remove());
                counter++;
            }
            while (!temp.IsEmpty())
            {
                st.Insert(temp.Remove());
            }
            int middle = counter / 2;

            for (int i = 0; i < counter; i++)
            {
                int val = st.Remove();
                if (counter % 2 == 0)
                {
                    if (i == middle - 1)
                    {
                        temp.Insert(x);
                    }
                    else if (i == middle)
                        temp.Insert(y);
                    else
                        temp.Insert(val);
                }
                else
                {
                    if (i == middle)
                        temp.Insert(randomValue);
                    else
                        temp.Insert(val);
                }
            }

            while (!temp.IsEmpty())
            {
                st.Insert(temp.Remove());
            }
        }
        //EX3 pt.1
        public static bool IsDownList(Node<int> chain)
        {
            if (chain == null || chain.GetNext() == null || chain.GetNext().GetNext() == null)
                return false; // חייבים לפחות 3 איברים כדי לבדוק את התנאי

            Node<int> prevPrev = chain;
            Node<int> prev = chain.GetNext();
            Node<int> current = chain.GetNext().GetNext();

            while (current != null)
            {
                if (current.GetValue() != Math.Abs(prev.GetValue() - prevPrev.GetValue()))
                    return false;

                prevPrev = prev;
                prev = current;
                current = current.GetNext();

            }
            return true;

        }

        //EX3 pt.2
        public static Node<int> BuildDown(int num, int a, int b)
        {
            if (num <= 0) return null; // טיפול במקרה של מספר לא תקין

            Node<int> head = new Node<int>(a);
            if (num == 1) return head;

            Node<int> second = new Node<int>(b);
            head.SetNext(second);

            Node<int> current = second;
            for (int i = 3; i <= num; i++)
            {
                int nextValue = a - b; // יצירת המספר הבא בסדרה
                Node<int> nextNode = new Node<int>(nextValue);
                current.SetNext(nextNode);
                current = nextNode;
                a = b;
                b = nextValue;
            }

            return head;
        }

        //EX6 pt.1
        public static void RemoveNumFromList(Stack<int> st, int num)
        {
            Stack<int> temp = new Stack<int>();
            while (!st.IsEmpty())
            {
                temp.Push(st.Pop());
            }

            while (!temp.IsEmpty())
            {
                int currentValue = temp.Pop();
                if (currentValue != num)
                    st.Push(currentValue);
            }

        }
        //EX6 pt.2
        public static Stack<int> CommonValues(Stack<int> s1, Stack<int> s2)
        {
            Stack<int> tempS1 = new Stack<int>();
            Stack<int> tempS2 = new Stack<int>();
            Stack<int> s3 = new Stack<int>();

            while (!s1.IsEmpty())
            {
                tempS1.Push(s1.Pop());
            }

            while (!s2.IsEmpty())
            {
                tempS2.Push(s2.Pop());
            }

            // running on the s1 stack
            while (!tempS1.IsEmpty()) // FIXED: changed from tempS1.IsEmpty() to !tempS1.IsEmpty()
            {
                Stack<int> tempS3 = new Stack<int>();
                int currentValue = tempS1.Pop();
                s1.Push(currentValue);
                if (s3.IsEmpty())
                {
                    s3.Push(currentValue);
                }
                else
                {
                    bool check = true;
                    while (!s3.IsEmpty())
                    {
                        int currentS3Value = s3.Pop();
                        tempS3.Push(currentS3Value);

                        if (currentS3Value == currentValue)
                        {
                            check = false;
                        }
                    }
                    while (!tempS3.IsEmpty())
                    {
                        s3.Push(tempS3.Pop());
                    }
                    if (check)
                    {
                        s3.Push(currentValue);
                    }
                }
            }

            // running on the s2 stack
            while (!tempS2.IsEmpty()) // No change needed here
            {
                Stack<int> tempS3 = new Stack<int>();
                int currentValue = tempS2.Pop();
                s2.Push(currentValue);
                if (s3.IsEmpty())
                {
                    s3.Push(currentValue);
                }
                else
                {
                    bool check = true;
                    while (!s3.IsEmpty())
                    {
                        int currentS3Value = s3.Pop();
                        tempS3.Push(currentS3Value);

                        if (currentS3Value == currentValue)
                        {
                            check = false;
                        }
                    }
                    while (!tempS3.IsEmpty())
                    {
                        s3.Push(tempS3.Pop());
                    }
                    if (check)
                    {
                        s3.Push(currentValue);
                    }
                }
            }

            return s3;
        }





    }
    public class RunMahatSummer2024
    {
        public static void DemoMain()
        {
            //Stack<int> stack1 = new Stack<int>();
            //stack1.Push(1);
            //stack1.Push(2);
            //stack1.Push(0);
            //stack1.Push(0);
            //stack1.Push(-1);
            //stack1.Push(-10);

            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(3);
            stack1.Push(6);
            stack1.Push(2);
            stack1.Push(14);
            stack1.Push(6);
            stack1.Push(3);

            Stack<int> stack2 = new Stack<int>();
            stack2.Push(5);
            stack2.Push(3);
            stack2.Push(7);
            stack2.Push(6);
            stack2.Push(14);
            stack2.Push(8);
            stack2.Push(1);


            Queue<int> q = new Queue<int>();
            q.Insert(5);
            q.Insert(8);
            q.Insert(12);
            q.Insert(20);
            q.Insert(15);
            q.Insert(3);

            Node<int> chain1 = new Node<int>(55);
            chain1.SetNext(new Node<int>(34));
            chain1.GetNext().SetNext(new Node<int>(21));
            chain1.GetNext().GetNext().SetNext(new Node<int>(13));
            chain1.GetNext().GetNext().GetNext().SetNext(new Node<int>(8));
            chain1.GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(5));



            Console.WriteLine($"is the stack balaced? {MahatSummer2024.IsBalanced(stack1)}");
            MahatSummer2024.UpdateMiddleStack(q, 30, 40);
            Console.WriteLine(q);
            Console.WriteLine("============");
            Console.WriteLine($"is the list a IsDownList? {MahatSummer2024.IsDownList(chain1)} ");

            Node<int> list = MahatSummer2024.BuildDown(5, 10, 6);
            Console.WriteLine(list.ToPrint());

            Console.WriteLine("===============");
            Console.WriteLine(MahatSummer2024.CommonValues(stack1, stack2));
        }
    }
}
