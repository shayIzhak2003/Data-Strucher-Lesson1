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
                if(counter % 2 == 0)
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
                    if(i == middle) 
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
    }
    public class RunMahatSummer2024
    {
        public static void DemoMain()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(0);
            stack1.Push(0);
            stack1.Push(-1);
            stack1.Push(-10);
           

            Queue<int> q = new Queue<int>();
            q.Insert(5);
            q.Insert(8);
            q.Insert(12);
            q.Insert(20);
            q.Insert(15);
            q.Insert(3);

            Console.WriteLine($"is the stack balaced? {MahatSummer2024.IsBalanced(stack1)}");
            MahatSummer2024.UpdateMiddleStack(q, 30, 40);
            Console.WriteLine(q);
        }
    }
}
