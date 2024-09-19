using Data_Structure_Lesson1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue.campusIL_Course
{
    public class Chep1
    {
        //EX1
        static void MoveAll<T>(Queue<T> srcQ, Queue<T> destQ)
        {
            while (!srcQ.IsEmpty())
                destQ.Insert(srcQ.Remove());
        }

        //EX2
        public static bool IsFibonacci(Queue<int> q)
        {
            if (q.IsEmpty())
                return false;
            Queue<int> helpQueue = new Queue<int>();
            int first = q.Remove();
            helpQueue.Insert(first);
            int second = 0;
            if (q.IsEmpty())
            {
                q.Insert(helpQueue.Remove());
                return false;
            }
            else
            {
                second = q.Remove();
                helpQueue.Insert(second);
            }
            if (q.IsEmpty())
            {
                MoveAll(helpQueue, q);
                return false;
            }
            while (!q.IsEmpty())
            {
                int current = q.Remove();
                helpQueue.Insert(current);
                if (first + second != current)
                {
                    MoveAll(q, helpQueue);
                    MoveAll(helpQueue, q);
                    return false;
                }
                first = second;
                second = current;
            }
            MoveAll(helpQueue, q);
            return true;
        }

        // with temp queue
        //public static bool IsExist(Queue<int> qu, int number)
        //{

        //    Queue<int> helpQueue = new Queue<int>();
        //    while (!qu.IsEmpty())
        //    {
        //        int value = qu.Remove();
        //        if (value == number)
        //        {
        //            return true;
        //        }
        //    }
        //    while (!helpQueue.IsEmpty())
        //    {
        //        int value = helpQueue.Remove();
        //        qu.Insert(value);
        //    }
        //    return false;
        //}

        // without tempQueue
        //public static bool IsExist(Queue<int> qu, int number)
        //{
        //    bool found = false;
        //    bool OutOfLoop = false;
        //    int firstValueHesh = qu.Head().GetHashCode();
        //    int switchedValue;

        //    // Traverse through the queue and check for the number
        //    do
        //    {
        //        switchedValue = qu.Remove();

        //        if (switchedValue == number)
        //        {
        //            found = true;
        //        }

        //        qu.Insert(switchedValue);

        //        if (firstValueHesh == qu.Head().GetHashCode())
        //        {
        //            OutOfLoop = true; // Exits when back at the starting point
        //        }

        //    } while (!OutOfLoop && !found);

        //    return found;
        //}

        // the rigth way 
        public static bool IsExist(Queue<int> qu, int number)
        {
            bool found = false;
            int stop = -99999;
            qu.Insert(stop);
            while (!qu.IsEmpty() && !found && qu.Head() != stop)
            {
                if (qu.Head() == number)
                {
                    found = true;
                }
                qu.Insert(qu.Remove());
            }
            // הוצאת האיבר הפיקטיבי
            if (!qu.IsEmpty())
                qu.Remove();
            return found;
        }
        //EX3
        public static bool IsPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static int PrimeQueue(Queue<int> qu)
        {
            Queue<int> tempQueue = new Queue<int>();
            int counter = 0;
            while (!qu.IsEmpty())
            {
                int value = qu.Remove();
                if (IsPrime(value))
                {
                    counter++;
                }
                tempQueue.Insert(value);
            }
            while (!tempQueue.IsEmpty())
            {
                int value = tempQueue.Remove();
                qu.Insert(value);
            }
            return counter;
        }
        //EX4

        public static Queue<T> CloneQueue<T>(Queue<T> qu)
        {
            Queue<T> tmp = new Queue<T>();
            Queue<T> clone = new Queue<T>();
            while (!qu.IsEmpty())
            {
                clone.Insert(qu.Head());
                tmp.Insert(qu.Remove());
            }
            // החזרת כל האיברים כסדרם לתור המקורי
            while (!tmp.IsEmpty())
                qu.Insert(tmp.Remove());
            return clone;
        }
        public static int Counter(Queue<int> line, int number)
        {
            Queue<int> tempQueue = new Queue<int>();
            int counter = 0;
            while (!line.IsEmpty())
            {
                int value = line.Remove();
                if (value == number)
                    counter++;

                tempQueue.Insert(value);
            }
            while (!tempQueue.IsEmpty())
            {
                int value = tempQueue.Remove();
                line.Insert(value);
            }
            return counter;
        }
        public static Queue<int> FrequencyQueueu(Queue<int> qu)
        {
            Queue<int> tempQueue = new Queue<int>();
            Queue<int> freqQueue = new Queue<int>();
            int value;

            while (!qu.IsEmpty())
            {
                value = qu.Remove();

                // Check if value is already processed by seeing if it exists in tempQueue
                if (Counter(tempQueue, value) == 0)
                {
                    int counter = Counter(qu, value) + 1;
                    freqQueue.Insert(value);
                    freqQueue.Insert(counter);
                }

                tempQueue.Insert(value);
            }

            // Restore original queue
            while (!tempQueue.IsEmpty())
            {
                int val = tempQueue.Remove();
                qu.Insert(val);
            }

            return freqQueue;
        }
        public static Queue<T> Merge2Queues<T>(Queue<T> q1, Queue<T> q2)
        {
            Queue<T> tempQueue1 = CloneQueue(q1);
            Queue<T> tempQueue2 = CloneQueue(q2);
            Queue<T> resuleQueue = new Queue<T>();

            while (!tempQueue1.IsEmpty())
            {
                T value = tempQueue1.Remove();
                resuleQueue.Insert(value);
            }
            while (!tempQueue2.IsEmpty())
            {
                T value = tempQueue2.Remove();
                resuleQueue.Insert(value);
            }
            return resuleQueue;
        }

        public static Point BarnOwl(Queue<Point> qu)
        {
            Queue<Point> temp = new Queue<Point>();
            int x, dx = qu.Head().GetX();
            int y, dy = qu.Head().GetY();
            double d = Math.Pow(dx, 2) + Math.Pow(dy, 2);
            while (!qu.IsEmpty())
            {
                x = qu.Head().GetX();
                y = qu.Head().GetY();
                if (Math.Pow(x, 2) + Math.Pow(y, 2) < d)
                {
                    dx = x;
                    dy = y;
                    d = Math.Pow(dx, 2) + Math.Pow(dy, 2);
                }
                temp.Insert(qu.Remove());
            }
            while (!temp.IsEmpty())
            {
                qu.Insert(temp.Remove());
            }
            return new Point(dx, dy);
        }

    }
    public class RunChep1
    {
        public static void DemoMain()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(0);
            intQueue.Insert(1);
            intQueue.Insert(1);
            intQueue.Insert(2);

            Queue<int> intQueue2 = new Queue<int>();
            intQueue2.Insert(1);
            intQueue2.Insert(1);
            intQueue2.Insert(2);
            intQueue2.Insert(4);
            intQueue2.Insert(3);
            intQueue2.Insert(4);
            // point queue
            Queue<Point> queueObject = new Queue<Point>();
            queueObject.Insert(new Point(4, 8));
            queueObject.Insert(new Point(7, 3));
            queueObject.Insert(new Point(-11, -6));
            queueObject.Insert(new Point(7, 4));
            queueObject.Insert(new Point(-9, 5));
            queueObject.Insert(new Point(2, 3));
            queueObject.Insert(new Point(5, 11));

            Console.WriteLine(Chep1.IsFibonacci(intQueue));
            Console.WriteLine(Chep1.IsExist(intQueue, 2));
            int count = Chep1.PrimeQueue(intQueue2);
            Console.WriteLine($"the amount of numbers that are prime is : {count}");
            Console.WriteLine(Chep1.FrequencyQueueu(intQueue2));
            Console.WriteLine(Chep1.Merge2Queues(intQueue, intQueue2));
            Console.WriteLine(Math.Pow(7, 2));
            Console.WriteLine(Chep1.BarnOwl(queueObject));


        }
    }

}
