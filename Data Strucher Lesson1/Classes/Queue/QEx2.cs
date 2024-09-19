using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue
{
    public class QEx2
    {
        // EX1
        public static int CountQueue<T>(Queue<T> queue)
        {
            Queue<T> tempQ = new Queue<T>();
            int count = 0;
            while (!queue.IsEmpty())
            {
                count++;
                T value = queue.Remove();
                tempQ.Insert(value);
            }
            while (!tempQ.IsEmpty())
            {
                T value = tempQ.Remove();
                queue.Insert(value);
            }
            return count;
        }
        //EX2
        public static void CloneQueue<T>(Queue<T> line)
        {
            Queue<T>tempQ = new Queue<T>();
            Queue<T>clone = new Queue<T>();

            while (!line.IsEmpty())
            {
                T value = line.Remove();
                tempQ.Insert(value);
                clone.Insert(value);
            }
            while (!tempQ.IsEmpty())
            {
                T value = tempQ.Remove();
                line.Insert(value);
            }
            Console.ForegroundColor  = ConsoleColor.Green;
            Console.WriteLine(clone);
            Console.ResetColor();
        }
        //EX3
        public static bool IsNumberIn(Queue<int> line, int num)
        {
            Queue<int> tempQ = new Queue<int>();
            bool flag = false;
            while(!line.IsEmpty())
            {
                int currentValue = line.Remove();
                if(currentValue == num)
                {
                    flag = true;
                }
                tempQ.Insert(currentValue);
            }
            while (!tempQ.IsEmpty())
            {
                int value = tempQ.Remove();
                line.Insert(value);
            }
            return flag;
        }
        //EX4
        public static bool IsInOrder(Queue<int> line)
        {
            Queue<int>tempQueue = new Queue<int>();
            int currentValue = line.Remove();
            tempQueue.Insert(currentValue);
            bool flag = true;
            while (!line.IsEmpty())
            {
                int nextValue = line.Remove();
                if(currentValue > nextValue)
                {
                    flag = false;
                }
                tempQueue.Insert(nextValue);
                currentValue = nextValue;
            }
            return flag;
        }

        //EX5
        public static bool IsLinesIdentical(Queue<int> line, Queue<int> line2)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            bool flag = true;

            while(!line.IsEmpty() && !line2.IsEmpty())
            {
                int currentValue1 = line.Remove();
                int currentValue2 = line2.Remove();

                if(currentValue1 != currentValue2)
                {
                    flag = false;
                }
                temp.Insert(currentValue1);
                temp2.Insert(currentValue2);
            }
            // If one queue is empty and the other is not, they are not identical
            if (!line.IsEmpty() || !line2.IsEmpty())
            {
                flag = false;
            }

            while (!temp.IsEmpty())
            {
                int value1 = temp.Remove();
                line.Insert(value1);
              
            }
            while (!temp2.IsEmpty())
            {
                  int value2 = temp2.Remove();
                  line2.Insert(value2);
            }

            return flag;
        }
        //EX6
        public static Queue<T> IsExist<T>(Queue<T> line, T objectToCheck)
        {
            Queue<T> tempLine = new Queue<T>();
            bool flag = false;
            T foundObject = default(T);

            // Check each element in the queue and move to tempLine
            while (!line.IsEmpty())
            {
                T value = line.Remove();
                if (value.Equals(objectToCheck))
                {
                    flag = true; // Mark that the object is found
                    foundObject = value; // Save the found object
                }
                else
                {
                    tempLine.Insert(value); // Move the other elements to the temporary queue
                }
            }

            // If the object was found, insert it at the head of the original queue
            if (flag)
            {
                line.Insert(foundObject);
            }

            // Restore the original queue from tempLine
            while (!tempLine.IsEmpty())
            {
                T value = tempLine.Remove();
                line.Insert(value); // Insert all remaining elements back into the original queue
            }

            // Output result based on whether the object was found
            if (flag)
            {
                Console.WriteLine($"{objectToCheck} was found and moved to the head of the queue.");
            }
            else
            {
                Console.WriteLine($"{objectToCheck} does not exist in the queue.");
            }

            return line; // Return the modified queue
        }
    }
    public class RunQEx2
    {
        public static void DemoMain()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Insert(1);
            intQueue.Insert(2);
            intQueue.Insert(3);
            intQueue.Insert(4);

            // Queue 2
            Queue<int> intQueue2 = new Queue<int>();
            intQueue2.Insert(1);
            intQueue2.Insert(2);
            intQueue2.Insert(3);
            intQueue2.Insert(4);
            Console.WriteLine($"the quqeue count is {QEx2.CountQueue(intQueue)}");
            QEx2.CloneQueue(intQueue);
            Console.WriteLine(intQueue.GetHashCode());
            Console.WriteLine($"is the number 4 in? {QEx2.IsNumberIn(intQueue,4)}");
            Console.WriteLine($"are the lines identical? {QEx2.IsLinesIdentical(intQueue,intQueue2)}");
            //Console.WriteLine($"is the queue in order : {QEx2.IsInOrder(intQueue)}");
            Console.WriteLine($"{QEx2.IsExist(intQueue,4)}");
        }
    }
}
