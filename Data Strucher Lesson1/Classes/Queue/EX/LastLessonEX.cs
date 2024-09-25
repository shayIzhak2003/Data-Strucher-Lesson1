using Data_Strucher_Lesson1.Classes.Queue.campusIL_Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue.EX
{
    public class LastLessonEX
    {
        //EX1 pt.1
        public static int CountQueue<T>(Queue<T> queue, T value)
        {
            Queue<T> clonQ = Chep1.CloneQueue(queue);
            int count = 0;
            while (!clonQ.IsEmpty())
            {
                T CurrentValue = clonQ.Remove();
                if (CurrentValue.Equals(value))
                {
                    count++;
                }
            }
            return count;
        }
        //EX1 pt.2
        public static Queue<int> DuplicateLines(Queue<int> line1, Queue<int> line2)
        {
            Queue<int> resultQueue = new Queue<int>();
            Queue<int> cloneLine1 = Chep1.CloneQueue(line1);

            while (!cloneLine1.IsEmpty())
            {
                int line1CurrentValue = cloneLine1.Remove();
                int count1 = CountQueue(line1, line1CurrentValue);
                int count2 = CountQueue(line2, line1CurrentValue);


                if (count1 != count2 && count2 > 0 && count1 > 0 && !Contains(resultQueue, line1CurrentValue))
                {
                    resultQueue.Insert(line1CurrentValue);
                }
            }

            return resultQueue;
        }


        private static bool Contains(Queue<int> queue, int value)
        {
            Queue<int> cloneQ = Chep1.CloneQueue(queue);

            while (!cloneQ.IsEmpty())
            {
                if (cloneQ.Remove() == value)
                {
                    return true;
                }
            }

            return false;
        }

        //EX2
        public static bool IsValidBooleanExpression(Queue<char> queue)
        {
            Queue<char> cloneQueue = Chep1.CloneQueue(queue);
            if (queue.IsEmpty())
                return false;

            char first = queue.Remove();


            if (first != 'F' && first != 'T')
                return false;

            bool expectOperator = true;

            while (!cloneQueue.IsEmpty())
            {
                char currentChar = cloneQueue.Remove();

                if (expectOperator)
                {
                    if (currentChar != 'T' && currentChar != 'F')
                    {
                        return false;
                    }
                    expectOperator = false;
                }
                else
                {
                    if (currentChar != 'A' && currentChar != 'O')
                    {
                        return false;
                    }
                    expectOperator = true;
                }
            }
            return !expectOperator;

        }
        //EX3
        public static Queue<int> GetMaxQueue(Queue<int> queue)
        {
            Queue<int> cloneQ = Chep1.CloneQueue(queue);
            Queue<int> resultQueue = new Queue<int>();
            int maxValue = 0;
            bool firstValue = true;

            while (!cloneQ.IsEmpty())
            {
                int currentValue = cloneQ.Remove();
                if (currentValue != -1)
                {
                    if (firstValue)
                    {
                        maxValue = currentValue;
                        firstValue = false;
                    }
                    else if (currentValue > maxValue)
                    {
                        maxValue = currentValue;
                    }
                }
                else
                {
                    resultQueue.Insert(maxValue);
                    resultQueue.Insert(-1);
                    maxValue = 0;
                    firstValue = true;
                }

            }
            if (!firstValue)
            {
                resultQueue.Insert(maxValue);
            }
            return resultQueue;

        }
        //EX4
        public static Queue<int> UnknowenLengthQueue(Queue<int> queue)
        {
            Queue<int> cloneQ = Chep1.CloneQueue(queue);
            Queue<int> resultQueue = new Queue<int>();

            while (!cloneQ.IsEmpty())
            {
                int currentValue = cloneQ.Remove();
                for (int i = 0; i < currentValue; i++)
                {
                    resultQueue.Insert(currentValue);
                }
            }
            return resultQueue;
        }

    }
    public class RunLastLessonEX
    {
        public static void DemoMain()
        {

            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);

            Queue<int> intQueue2 = new Queue<int>();
            intQueue2.Insert(4);
            intQueue2.Insert(2);
            intQueue2.Insert(2);
            intQueue2.Insert(4);
            int count = LastLessonEX.CountQueue(intQueue, 4);
            Console.WriteLine($"4 count in the list is {count}");
            Console.WriteLine(LastLessonEX.DuplicateLines(intQueue, intQueue2));

            //EX2
            Queue<char> queue1 = new Queue<char>();
            queue1.Insert('F');
            queue1.Insert('O');
            queue1.Insert('T');
            queue1.Insert('A');
            queue1.Insert('T');
            Console.WriteLine(LastLessonEX.IsValidBooleanExpression(queue1));

            Queue<char> queue2 = new Queue<char>();
            queue2.Insert('T');
            queue2.Insert('A');
            queue2.Insert('O');
            Console.WriteLine(LastLessonEX.IsValidBooleanExpression(queue2));


            //EX3
            Queue<int> inputQueue = new Queue<int>();
            inputQueue.Insert(34);
            inputQueue.Insert(65);
            inputQueue.Insert(3);
            inputQueue.Insert(-1);
            inputQueue.Insert(100);
            inputQueue.Insert(-1);
            inputQueue.Insert(678);
            inputQueue.Insert(89);
            inputQueue.Insert(5);
            Console.WriteLine(LastLessonEX.GetMaxQueue(inputQueue));

            Console.WriteLine(LastLessonEX.UnknowenLengthQueue(intQueue));
        }
    }
}
