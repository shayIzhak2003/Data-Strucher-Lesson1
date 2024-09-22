using Data_Strucher_Lesson1.Classes.Queue.campusIL_Course;
using System;

namespace Data_Strucher_Lesson1.Classes.Queue
{
    public class QEx3
    {
        // EX1 pt.1
        public static int CountNum<T>(Queue<T> line, T value)
        {
            Queue<T> q = Chep1.CloneQueue(line);
            int count = 0;
            while (!q.IsEmpty())
            {
                T currentValue = q.Remove();
                if (currentValue.Equals(value))
                {
                    count++;
                }
            }
            return count;
        }

        // EX1 pt.2
        public static Queue<int> DuplicateLines(Queue<int> line1, Queue<int> line2)
        {
            Queue<int> cloneLine1 = Chep1.CloneQueue(line1);
            Queue<int> resultQueue = new Queue<int>();

            while (!cloneLine1.IsEmpty())
            {
                int line1CurrentValue = cloneLine1.Remove();
                Queue<int> cloneLine2 = Chep1.CloneQueue(line2);

                while (!cloneLine2.IsEmpty())
                {
                    int line2CurrentValue = cloneLine2.Remove();

                    if (line1CurrentValue == line2CurrentValue)
                    {
                        int countLine1Value = CountNum(line1, line1CurrentValue);
                        int countLine2Value = CountNum(line2, line2CurrentValue);

                        if (countLine1Value != countLine2Value && countLine1Value > 0 && countLine2Value > 0)
                        {
                            if (!resultQueue.ToString().Contains(line2CurrentValue.ToString()))
                            {
                                resultQueue.Insert(line2CurrentValue);
                            }
                        }
                        
                    }
                }
            }

            return resultQueue;
        }

        //EX2
        public static bool IsValidBooleanExpression(Queue<char> queue)
        {
            if (queue.IsEmpty())
                return false;

            char first = queue.Remove();

            
            if (first != 'F' && first != 'T')
                return false;

            bool expectOperator = true;

            while (!queue.IsEmpty())
            {
                char current = queue.Remove();

                if (expectOperator)
                {
                    
                    if (current != 'A' && current != 'O')
                        return false;
                    expectOperator = false;
                }
                else
                {
                   
                    if (current != 'F' && current != 'T')
                        return false;
                    expectOperator = true;
                }
            }

            
            return expectOperator;
        }
        //EX3


    }

    public class RunQEx3
    {
        public static void DemoMain()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(2);
            intQueue.Insert(4);

            Queue<int> intQueue2 = new Queue<int>();
            intQueue2.Insert(1);
            intQueue2.Insert(2);
            intQueue2.Insert(4);
            intQueue2.Insert(4);
            intQueue2.Insert(5);
            intQueue2.Insert(1);

            int count = QEx3.CountNum(intQueue, 4);
            Queue<char> queue1 = new Queue<char>();
            queue1.Insert('F');
            queue1.Insert('O');
            queue1.Insert('T');
            queue1.Insert('A');
            queue1.Insert('T');
            Console.WriteLine(QEx3.IsValidBooleanExpression(queue1)); // True

            Queue<char> queue2 = new Queue<char>();
            queue2.Insert('T');
            queue2.Insert('A');
            queue2.Insert('O');
            Console.WriteLine(QEx3.IsValidBooleanExpression(queue2)); // False

            Console.WriteLine($"The amount of times that 4 is on the list is {count}");

            Queue<int> duplicateQueue = QEx3.DuplicateLines(intQueue, intQueue2);

            Console.WriteLine($"Duplicate values: {duplicateQueue}");


        }
    }
}
