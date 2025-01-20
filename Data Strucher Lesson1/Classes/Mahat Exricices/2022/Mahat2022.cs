using Data_Strucher_Lesson1.Classes.Mahat_Exercises._2022.Ex3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022
{
    public class Mahat2022
    {
        //EX1
        // EX1: Duplicates each node in the chain
        public static void First(Node<int> chain)
        {
            Node<int> pos = chain;

            while (pos != null)
            {
                int currentValue = pos.GetValue();

                // Create a duplicate node with the same value
                Node<int> duplicateNode = new Node<int>(currentValue);

                // Link the duplicate node to the next node
                duplicateNode.SetNext(pos.GetNext());

                // Link the current node to the duplicate node
                pos.SetNext(duplicateNode);

                // Move the pointer to the next original node (skip the duplicate node)
                pos = duplicateNode.GetNext();
            }
        }

        //EX1 pt.2
        public static void Second(Node<int> chain)
        {
            if (chain == null) return;

            Node<int> pos = chain;
            Node<int> head = chain;

            // Traverse to the end of the original chain
            while (pos.GetNext() != null)
            {
                pos = pos.GetNext();
            }

            // `pos` is now at the last node of the original chain
            Node<int> tail = pos;

            // Create duplicates for each node in the original chain
            while (head != null)
            {
                int value = head.GetValue();

                // Create a new node with the same value as the current node
                Node<int> duplicateNode = new Node<int>(value);

                // Add this duplicate node to the end of the chain
                tail.SetNext(duplicateNode);

                // Move the tail to the new duplicate node
                tail = duplicateNode;

                // Move the head to the next node in the original chain
                head = head.GetNext();
            }
        }

        //EX2
        public static void SortByAverage(Stack<int> stack1)
        {
            int avarge = 0;
            int sum = 0;
            int count = 0;
            Stack<int> tempStack = new Stack<int> ();
            Stack<int> tempLessThenAvarage = new Stack<int>();
            while (!stack1.IsEmpty())
            {
                
                int currentValue = stack1.Pop();
                sum += currentValue;
                count++;
                tempStack.Push(currentValue);
            }

            avarge = sum / count;
            while (!tempStack.IsEmpty())
            {
                int currentValue = tempStack.Pop();
                stack1.Push(currentValue);
            }

            while (!stack1.IsEmpty())
            {
                int currentValue = stack1.Pop();
                if(currentValue > avarge)
                {
                    tempStack.Push(currentValue);
                }
                else
                {
                    tempLessThenAvarage.Push(currentValue);
                }
            }

            while (!tempLessThenAvarage.IsEmpty())
            {
                stack1.Push(tempLessThenAvarage.Pop());
            }
            while (!tempStack.IsEmpty())
            {
                stack1.Push(tempStack.Pop());
            }


        }



    }
    public class RunMahat2022
    {
        public static void DemoMain()
        {
            // Create a linked list: 1 -> 2 -> 3 -> 4 -> 5 -> 6
            Node<int> node6 = new Node<int>(6);
            Node<int> node5 = new Node<int>(5, node6);
            Node<int> node4 = new Node<int>(4, node5);
            Node<int> node3 = new Node<int>(3, node4);
            Node<int> node2 = new Node<int>(2, node3);
            Node<int> node1 = new Node<int>(1, node2);

            Stack<int> stack1 = new Stack<int>();
            stack1.Push(11);
            stack1.Push(2);
            stack1.Push(30);
            stack1.Push(4);

            // Print the original chain
            Console.WriteLine($"The original chain: {node1.ToPrint()}");

            // Apply the First method
            //Mahat2022.First(node1);

            //// Print the updated chain
            //Console.WriteLine($"The updated chain: {node1.ToPrint()}");

            //Mahat2022.Second(node1);
            //Console.WriteLine($"The updated chain: {node1.ToPrint()}");
            Console.WriteLine(stack1);
            Mahat2022.SortByAverage(stack1);
            Console.WriteLine(stack1);

            //EX3
            RunB.DemoMain();
        }


    }
}
