﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue
{
    public class QEx
    {
        //EX1   
        public static int CountQueue<T>(Queue<T> queue)
        {
            int count = 0;
            Queue<T> tempLine = new Queue<T>();

            while (!queue.IsEmpty())
            {
                count++;
                T value = queue.Remove();
                tempLine.Insert(value);
            }


            while (!tempLine.IsEmpty())
            {
                T value = tempLine.Remove();
                queue.Insert(value);
            }

            return count;
        }
        //EX2
        public static void CloneQueue<T>(Queue<T> line)
        {
            Queue<T> temp = new Queue<T>();
            Queue<T> clone = new Queue<T>();

            // Transfer elements from the original queue to both temp and clone
            while (!line.IsEmpty())
            {
                T value = line.Remove();
                temp.Insert(value);  // To restore the original queue later
                clone.Insert(value); // To create the clone
            }

            // Restore the original queue from temp
            while (!temp.IsEmpty())
            {
                T value = temp.Remove();
                line.Insert(value);
            }

            // Display the cloned queue
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The cloned queue:");
            Console.WriteLine(clone);
            Console.ResetColor();
        }
        //EX3
        public static bool IsNumberIn(Queue<int> line, int num)
        {
            Queue<int> templine = new Queue<int>();
            bool flag = false;
            while (!line.IsEmpty())
            {
                int value = line.Remove();
                if (value == num)
                {
                    flag = true;
                }
                templine.Insert(value);

            }
            while (!templine.IsEmpty())
            {
                int value = templine.Remove();
                line.Insert(value);
            }
            return flag;
        }
        //EX4
        public static bool IsInOrder(Queue<int> line)
        {
            if (line.IsEmpty())
                return true; // An empty queue is considered in order

            Queue<int> tempLine = new Queue<int>();
            bool flag = true;

            // Start by removing the first element
            int prevValue = line.Remove();
            tempLine.Insert(prevValue);

            while (!line.IsEmpty())
            {
                int currentValue = line.Remove();

                if (prevValue > currentValue)
                {
                    flag = false;
                }

                // Insert both previous and current values into the temp queue
                tempLine.Insert(currentValue);
                prevValue = currentValue; // Move to the next comparison
            }

            // Restore the original queue
            while (!tempLine.IsEmpty())
            {
                int value = tempLine.Remove();
                line.Insert(value);
            }

            return flag;
        }
        //EX5
        public static bool IsLinesIdentical(Queue<int> line, Queue<int> line2)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            bool flag = true;

            // Compare elements of both queues
            while (!line.IsEmpty() && !line2.IsEmpty())
            {
                int value1 = line.Remove();
                int value2 = line2.Remove();

                if (value1 != value2)
                {
                    flag = false;
                }
                temp.Insert(value1);  // Store the values to restore later
                temp2.Insert(value2);
            }

            // If one queue is empty and the other is not, they are not identical
            if (!line.IsEmpty() || !line2.IsEmpty())
            {
                flag = false;
            }

            // Restore the original queues
            while (!temp.IsEmpty())
            {
                line.Insert(temp.Remove());
            }
            while (!temp2.IsEmpty())
            {
                line2.Insert(temp2.Remove());
            }

            return flag;
        }

        //EX6

    }
    public class RunQEx
    {
        public static void DemoMain()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);

            Queue<int> intQueue2 = new Queue<int>();
            intQueue2.Insert(1);
            intQueue2.Insert(2);
            intQueue2.Insert(3);
            intQueue2.Insert(4);


            // string queue
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Insert("hello");
            stringQueue.Insert("world");
            int count = QEx.CountQueue(stringQueue);
            QEx.CloneQueue(stringQueue);
            Console.WriteLine($"the counter = {count}");
            Console.WriteLine($"is the number in ? {QEx.IsNumberIn(intQueue, 4)}");
            Console.WriteLine($"is the Queue in order? {QEx.IsInOrder(intQueue)}");
            Console.WriteLine($"are the lines Identical ? {QEx.IsLinesIdentical(intQueue, intQueue2)}");
        }
    }
}
