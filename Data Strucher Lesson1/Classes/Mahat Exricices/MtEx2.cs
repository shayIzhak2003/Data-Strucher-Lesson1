using Data_Strucher_Lesson1.Classes.Mahat_Exricices.MtEx3;
using Data_Strucher_Lesson1.Classes.Queue;
using Data_Strucher_Lesson1.Classes.stackStrucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices
{
    //NOTES
    // the clone queue function in the QEX > EX(Folder)

    public class MtEx2
    {
        //EX1
        public static Queue<int> AverageQueue(Queue<int> marks, Queue<int> tests)
        {
            Queue<int> avarage = new Queue<int>();
            int avg, sum = 0;

            while (!tests.IsEmpty())
            {
                sum = 0;
                int currentTestAmount = tests.Remove();
                for (int i = 0; i < currentTestAmount; i++)
                {
                    int currentMark = marks.Remove();
                    sum += currentMark;
                }
                avg = sum / currentTestAmount;
                avarage.Insert(avg);
            }
            return avarage;

        }

        //EX Pt.2 : the runtime function is O(N)!

        //EX2 pt.1
        public static int NumDigits(Node<int> lst)
        {
            int count = 0;
            Node<int> pos = lst;
            while (pos != null)
            {
                pos = pos.GetNext();
                count++;
            }
            return count;
        }

        //EX2 pt.2
        public static int Compare(Node<int> n1, Node<int> n2)
        {
            Node<int> pos1 = n1;
            Node<int> pos2 = n2;

            int length1 = NumDigits(n1);
            int length2 = NumDigits(n2);


            if (length1 > length2)
            {
                return 1;
            }

            if (length1 < length2)
            {
                return 2;
            }

            while (pos1 != null && pos2 != null)
            {
                if (pos1.GetValue() > pos2.GetValue())
                {
                    return 1;
                }

                if (pos1.GetValue() < pos2.GetValue())
                {
                    return 2;
                }

                pos1 = pos1.GetNext();
                pos2 = pos2.GetNext();
            }
            return 0;
        }
        //EX2 Pt.3 : the runtime function is O(N)!

        //EX3
        // the Demi Main function is in the DemoMain below

        //EX4
        //..... do it later 

        //EX5 pt.1
        public static int Distance(Node<int> lst, int num)
        {
            if (lst == null)
                return -1; // אם הרשימה ריקה, מחזירים -1

            int position = 0; // מיקום נוכחי בשרשרת
            int firstOccurrence = -1; // המיקום הראשון של המספר num
            int lastOccurrence = -1; // המיקום האחרון של המספר num
            int length = 0; // אורך השרשרת

            Node<int> current = lst;

            // מעבר על כל השרשרת
            while (current != null)
            {
                position++;
                if (current.GetValue() == num)
                {
                    if (firstOccurrence == -1) // שמירה על המיקום הראשון
                        firstOccurrence = position;

                    lastOccurrence = position; // עדכון המיקום האחרון
                }


                current = current.GetNext();
            }

            length = position; // האורך הכולל של השרשרת

            // אם לא נמצא num בשרשרת
            if (firstOccurrence == -1)
                return -1;

            // חישוב המרחק
            int distanceFromStart = firstOccurrence;
            int distanceFromEnd = length - lastOccurrence;
            return distanceFromStart + distanceFromEnd;
        }

        //EX5 pt.2

        public static int MinDistanceValue(Node<int> lst)
        {
            if (lst == null)
                throw new ArgumentException("The list cannot be null.");
            Node<int> outer = lst;

            int minDistance = Distance(lst, outer.GetValue()); // ערך המרחק המינימלי
            int minValue = outer.GetValue();   // הערך בעל המרחק המינימלי


            while (outer != null) // לולאת מעבר על כל הערכים בשרשרת
            {
                int value = outer.GetValue();
                int distance = Distance(lst, value); // חישוב המרחק עבור הערך הנוכחי

                if (distance != -1) // לוודא שהערך קיים בשרשרת
                {
                    if (distance < minDistance || (distance == minDistance && value < minValue))
                    {
                        minDistance = distance;
                        minValue = value;
                    }
                }

                outer = outer.GetNext();
            }

            return minValue;
        }

        //EX5 pt3. Distance = O(N) , MinDistanceValue = O(N) * 2

        // צריך מחר לעשות את שאלה 7 מהמהט

        //EX8
        //...... DO THIS LATER

        //EX9
        public static int NumOf(Stack<int> m)
        {
            Stack<int> cloneStack = Lesson2.Clone(m);
            int count = 0;

            while (!cloneStack.IsEmpty())
            {
                count++;
                cloneStack.Pop();
            }
            return count;
        }

        //EX9 pt.1
        public static int RandChoice(Stack<int> m)
        {
            int StackLength = NumOf(m);
            Stack<int> stackClone = Lesson2.Clone(m);
            int valueToReturn = 0;
            Random random = new Random();
            int rnd = random.Next(StackLength);

            for (int i = 0; i <= rnd; i++)
            {
                valueToReturn = stackClone.Pop();
            }

            return valueToReturn;
        }

        //EX9 pt.2
        public static Stack<int> CreateSmall(Stack<int> m, int a)
        {
            Stack<int> stackClone = Lesson2.Clone(m);
            Stack<int> stackToReturn = new Stack<int>();

            while (!stackClone.IsEmpty())
            {
                int currentValue = stackClone.Pop();
                if (currentValue < a)
                {
                    stackToReturn.Push(currentValue);
                }

            }
            return stackToReturn;

        }

        //EX9 pt.3
        public static Stack<int> CreateLarge(Stack<int> m, int a)
        {
            Stack<int> stackClone = Lesson2.Clone(m);
            Stack<int> stackToReturn = new Stack<int>();

            while (!stackClone.IsEmpty())
            {
                int currentValue = stackClone.Pop();
                if (currentValue > a)
                {
                    stackToReturn.Push(currentValue);
                }

            }
            return stackToReturn;
        }

        //EX9 pt.4
        public static void EraseSmalls(Stack<int> m, int k)
        {

            Stack<int> stackToReturn = new Stack<int>();

            while (!m.IsEmpty())
            {
                int currentValue = m.Pop();
                if (currentValue < k)
                {
                    stackToReturn.Push(currentValue);
                }
            }

            while (!stackToReturn.IsEmpty())
            {
                int currentValue = stackToReturn.Pop();
                m.Push(currentValue);
            }

            Console.WriteLine(m);
        }
        //EX9 pt.5
        public static void EraseLarges(Stack<int> m, int k)
        {

            Stack<int> stackToReturn = new Stack<int>();

            while (!m.IsEmpty())
            {
                int currentValue = m.Pop();
                if (currentValue > k)
                {
                    stackToReturn.Push(currentValue);
                }
            }

            while (!stackToReturn.IsEmpty())
            {
                int currentValue = stackToReturn.Pop();
                m.Push(currentValue);
            }

            Console.WriteLine(m);
        }

        //EX10
        // Main function to check if the queue is perfect
        public static bool IsPerfect(Queue<Stack<int>> q)
        {
            // Clone the queue to preserve its original state
            Queue<Stack<int>> queueClone = CloneQueue(q);

            if (queueClone.IsEmpty())
                return true;

            Stack<int> prevStack = queueClone.Remove();

            // Check the first stack's ascending order
            if (!IsStackAscending(prevStack))
                return false;

            while (!queueClone.IsEmpty())
            {
                Stack<int> currentStack = queueClone.Remove();

                // Check if both stacks are in ascending order
                if (!IsStackAscending(currentStack))
                    return false;

                // Ensure the size of the current stack is greater than the previous
                if (Lesson1.count_stack(prevStack) >= Lesson1.count_stack(currentStack))
                    return false;

                // Ensure the bottom of the previous stack matches the top of the current stack
                if (GetStackBottom(prevStack) != GetStackTop(currentStack))
                    return false;

                prevStack = currentStack;
            }

            return true;
        }

        // Clone the original queue
        public static Queue<T> CloneQueue<T>(Queue<T> originalQueue)
        {
            Queue<T> clonedQueue = new Queue<T>();
            Queue<T> tempQueue = new Queue<T>();

            while (!originalQueue.IsEmpty())
            {
                T item = originalQueue.Remove();
                tempQueue.Insert(item);
                clonedQueue.Insert(item);
            }

            while (!tempQueue.IsEmpty())
            {
                originalQueue.Insert(tempQueue.Remove());
            }

            return clonedQueue;
        }

        // Check if a stack is sorted in ascending order
        public static bool IsStackAscending(Stack<int> stack)
        {
            Stack<int> stackClone = Lesson2.Clone(stack);

            if (stackClone.IsEmpty())
                return true;

            int prevValue = stackClone.Pop();

            while (!stackClone.IsEmpty())
            {
                int currentValue = stackClone.Pop();
                if (currentValue <= prevValue)
                    return false;

                prevValue = currentValue;
            }

            return true;
        }

        // Get the bottom element of a stack
        public static int GetStackBottom(Stack<int> stack)
        {
            Stack<int> stackClone = Lesson2.Clone(stack);
            int bottomValue = 0;

            while (!stackClone.IsEmpty())
            {
                bottomValue = stackClone.Pop();
            }

            return bottomValue;
        }

        // Get the top element of a stack
        public static int GetStackTop(Stack<int> stack)
        {
            Stack<int> stackClone = Lesson2.Clone(stack);

            // The top element is the first to be popped
            return stackClone.Pop();
        }


    }
    public class RunMtEx2
    {
        public static void DemoMain()
        {
            // Initialize the marks queue
            Queue<int> marks = new Queue<int>();
            marks.Insert(85); // Test 1: 85, 90
            marks.Insert(90);
            marks.Insert(78); // Test 2: 78, 88, 92
            marks.Insert(88);
            marks.Insert(92);

            // Initialize the tests queue
            Queue<int> tests = new Queue<int>();
            tests.Insert(2); // First test group has 2 marks
            tests.Insert(3); // Second test group has 3 marks

            Node<int> n1 = new Node<int>(2);
            Node<int> node1_2 = new Node<int>(3);
            Node<int> node1_3 = new Node<int>(2);
            Node<int> node1_4 = new Node<int>(1);
            Node<int> node1_5 = new Node<int>(4);
            Node<int> node1_6 = new Node<int>(1);
            Node<int> node1_7 = new Node<int>(8);

            n1.SetNext(node1_2);
            node1_2.SetNext(node1_3);
            node1_3.SetNext(node1_4);
            node1_4.SetNext(node1_5);
            node1_5.SetNext(node1_6);
            node1_6.SetNext(node1_7);

            // Create the second number: 1 -> 3 -> 9 -> 5
            Node<int> n2 = new Node<int>(1);
            Node<int> node2_2 = new Node<int>(3);
            Node<int> node2_3 = new Node<int>(9);
            Node<int> node2_4 = new Node<int>(5);

            n2.SetNext(node2_2);
            node2_2.SetNext(node2_3);
            node2_3.SetNext(node2_4);

            // stack section
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(4);
            stack.Push(555);


            // Calculate averages
            Queue<int> averages = MtEx2.AverageQueue(marks, tests);
            Console.WriteLine(averages);
            Console.WriteLine(MtEx2.NumDigits(n1));
            Console.WriteLine(MtEx2.Compare(n1, n2));

            //EX3
            RunFruitAndAppleApp.DemoMain();

            //EX5

            // Building the linked list: 3 -> 4 -> 7 -> 7 -> 5 -> 7 -> 1 -> 6
            Node<int> lst = new Node<int>(3);
            Node<int> node2 = new Node<int>(4);
            Node<int> node3 = new Node<int>(7);
            Node<int> node4 = new Node<int>(7);
            Node<int> node5 = new Node<int>(5);
            Node<int> node6 = new Node<int>(7);
            Node<int> node7 = new Node<int>(1);
            Node<int> node8 = new Node<int>(6);

            // Linking the nodes together
            lst.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node7);
            node7.SetNext(node8);

            // Testing the Distance method
            Console.WriteLine(MtEx2.Distance(lst, 7)); // Output: 5
            Console.WriteLine(MtEx2.Distance(lst, 3)); // Output: 9
            Console.WriteLine(MtEx2.Distance(lst, 2)); // Output: -1


            Console.WriteLine($"the the min value is: => {MtEx2.MinDistanceValue(lst)}");
            Console.WriteLine($"the stack count is :=> {MtEx2.NumOf(stack)}");
            Console.WriteLine($"getting a random value from the stack: => {MtEx2.RandChoice(stack)}");
            Console.WriteLine($"stack with the values that are smaller then 3 {MtEx2.CreateSmall(stack, 3)}");
            Console.WriteLine($"stack with the values that are bigger then 3 {MtEx2.CreateLarge(stack, 3)}");
            //MtEx2.EraseSmalls(stack, 4);
            //MtEx2.EraseLarges(stack,2);

            Queue<Stack<int>> queue = new Queue<Stack<int>>();

            Stack<int> stack1 = new Stack<int>();
            stack1.Push(40);
            stack1.Push(20);

            Stack<int> stack2 = new Stack<int>();
            stack2.Push(60);
            stack2.Push(50);
            stack2.Push(40);

            Stack<int> stack3 = new Stack<int>();
            stack3.Push(4000);
            stack3.Push(500);
            stack3.Push(100);
            stack3.Push(60);

            queue.Insert(stack1);
            queue.Insert(stack2);
            queue.Insert(stack3);

            Console.WriteLine((stack2));
            
            Console.WriteLine(MtEx2.IsPerfect(queue)); // Output: True




        }
    }

}
