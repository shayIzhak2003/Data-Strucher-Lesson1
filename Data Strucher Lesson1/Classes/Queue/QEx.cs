using System;
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

            // string queue
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Insert("hello");
            stringQueue.Insert("world");
            int count = QEx.CountQueue(stringQueue);
            QEx.CloneQueue(stringQueue);
            Console.WriteLine($"the counter = {count}");
        }
    }
}
