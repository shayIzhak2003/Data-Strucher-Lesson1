using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Recorsia
{
    public class RecEx2
    {
        //EX1
        public static bool IsInside(Queue<int> q, int num)
        {
            if (q.IsEmpty())
            {
                return false;
            }
            int current = q.Remove();

            if (current == num)
            {
                return true;
            }

            bool isFound = IsInside(q, num);

            q.Insert(current);

            return isFound;
        }
        //EX2
        public static int CountEven(Queue<int> q)
        {
            int count = 0;

            if (q.IsEmpty())
            {
                return 0;
            }
            int current = q.Remove();

            if (current % 2 == 0)
            {
                count++;
            }
            return CountEven(q) + count;

        }
        // Stack Recorseion
        //EX1
        public static bool IsNumInsideStack(Stack<int> stack, int number)
        {
            if (stack.IsEmpty())
            {
                return false;
            }
            int current = stack.Pop();
            if(current == number)
            {
                return true;
            }
            bool isFound = IsNumInsideStack(stack, number);
            stack.Push(current);

            return isFound;
        }
        //EX2
        public static int CountEvenInStack(Stack<int> stack)
        {
            int count = 0;
            if (stack.IsEmpty())
            {
                return 0;
            }
            int current = stack.Pop();
            if (current % 2 == 0)
            {
                count++;
            }

            return CountEvenInStack(stack) + count;

        }
        //EX3
        public static int MinValueInStack(Stack<int> stack)
        {
           

           
            int current = stack.Pop();

            if (stack.IsEmpty())
            {
                return current;
            }


            int minInRest = MinValueInStack(stack);

            int min = Math.Min(current, minInRest);

            stack.Push(current);

            return min;
        }

        public static int Schum(Node<int> lst, Node<int> p)
        {
            // Get the next node
            Node<int> p1 = p.GetNext();

            // If the next node is null, return 0
            if (p1 == null)
                return 0;

            // If the value of the next node is greater than the current node's value, return 0
            if (p1.GetValue() > p.GetValue())
                return 0;

            // Recursive call: sum the current node's value with the result of the next nodes
            return Schum(lst, p1) + p.GetValue();
        }


    }
    public class RunRecEx2
    {
        public static void DemoMain()
        {

            Queue<int> queue = new Queue<int>();
            queue.Insert(10);
            queue.Insert(20);
            queue.Insert(30);
            queue.Insert(45);
            queue.Insert(50);
            queue.Insert(33);

            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(50);

            Node<int> node1 = new Node<int>(3);
            Node<int> node2 = new Node<int>(4);
            Node<int> node3 = new Node<int>(5);
            Node<int> node4 = new Node<int>(6);
            Node<int> node5 = new Node<int>(7);
            Node<int> node6 = new Node<int>(5);
            Node<int> node7 = new Node<int>(7);
            Node<int> node8 = new Node<int>(1);
            Node<int> node9 = new Node<int>(6);

            // Build the linked list
            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            node4.SetNext(node5);
            node5.SetNext(node6);
            node6.SetNext(node7);
            node7.SetNext(node8);
            node8.SetNext(node9);

            Console.WriteLine(RecEx2.IsInside(queue, 40));
            Console.WriteLine(RecEx2.CountEven(queue));
            Console.WriteLine(RecEx2.IsNumInsideStack(stack, 10));
            Console.WriteLine(RecEx2.CountEvenInStack(stack));
            Console.WriteLine(RecEx2.MinValueInStack(stack));

            Console.WriteLine(RecEx2.Schum(node1, node1));

        }
    }
}
