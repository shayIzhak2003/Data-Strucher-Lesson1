using Data_Strucher_Lesson1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            IntNode node1 = new IntNode(1);
            IntNode node2 = new IntNode(2);
            IntNode node3 = new IntNode(3);
            IntNode node4 = new IntNode(4);
            IntNode node5 = new IntNode(5);
            IntNode node6 = new IntNode(6);

            
            node1.setNext(node2);
            node2.setNext(node3);
            node3.setNext(node4);
            node4.setNext(node5);
            node5.setNext(node6);

            
            Console.WriteLine("Original linked list:");
            IntNode.print(node1);

           
            int sum = NodeEx.Sum(node1);
            Console.WriteLine("Sum of the linked list: " + sum);

            
            bool exists = NodeEx.IsExsist(node1, 4);
            Console.WriteLine("Does 4 exist in the list? " + exists);

            exists = NodeEx.IsExsist(node1, 10);
            Console.WriteLine("Does 10 exist in the list? " + exists);

            
            NodeEx.EnterLast(node1, 7);
            Console.WriteLine("Linked list after adding 7 at the end:");
            IntNode.print(node1);

            
            IntNode newNode = new IntNode(9);
            NodeEx.EnterSecond(node1, newNode);
            Console.WriteLine("Linked list after inserting 9 at the second position:");
            IntNode.print(node1);

            
            int size = NodeEx.Size(node1);
            Console.WriteLine("Size of the linked list: " + size);

           
            int count = NodeEx.HowMany(node1, 3);
            Console.WriteLine("How many times does 3 appear in the list? " + count);

            count = NodeEx.HowMany(node1, 9);
            Console.WriteLine("How many times does 9 appear in the list? " + count);

            
            bool inOrder = NodeEx.InOrder(node1);
            Console.WriteLine("Is the list in ascending order? " + inOrder);
           
            int sumOdd = NodeEx.SumOdd(node1);
            Console.WriteLine("Sum of values at odd positions: " + sumOdd);
            NodeEx.EnterInOrder(node1, 10);
            Console.WriteLine("Linked list after inserting 10:");
            IntNode.print(node1);

            Console.WriteLine($"Is the linked list an arithmetic series? {NodeEx.IsSerial(node1)}");
            Console.WriteLine();

            
            Console.WriteLine("Original linked list:");
            IntNode.print(node1);

            
            IntNode updatedList = NodeEx.RemovePos(node1, 2);
            Console.WriteLine("Linked list after removing node at position 2:");
            IntNode.print(updatedList);

           
            updatedList = NodeEx.RemovePos(updatedList, 0);
            Console.WriteLine("Linked list after removing node at position 0:");
            IntNode.print(updatedList);

           
            updatedList = NodeEx.RemovePos(updatedList, 10);
            Console.WriteLine("Linked list after trying to remove node at out-of-bounds position 10:");
            IntNode.print(updatedList);

            IntNode nodeAtPos = NodeEx.ReturnAtPos(node1, 2);
            Console.WriteLine("Node at position 2: " + (nodeAtPos != null ? nodeAtPos.GetValue().ToString() : "null"));

            
            nodeAtPos = NodeEx.ReturnAtPos(node1, 0);
            Console.WriteLine("Node at position 0: " + (nodeAtPos != null ? nodeAtPos.GetValue().ToString() : "null"));

            
            nodeAtPos = NodeEx.ReturnAtPos(node1, 10);
            Console.WriteLine("Node at position 10: " + (nodeAtPos != null ? nodeAtPos.GetValue().ToString() : "null"));

            Console.WriteLine();

            int[] testValues = { 3, 5, 7 };
            Console.WriteLine("The List :");
            IntNode.print(node1);
            foreach (int val in testValues)
            {
                int index = NodeEx.ReturnNum(node1, val);
                if (index != -1)
                {
                    Console.WriteLine($"Value {val} found at index {index}.");
                }
                else
                {
                    Console.WriteLine($"Value {val} not found in the list.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Original linked list:");
            IntNode.print(node1);

            
            int maxPosition = NodeEx.Max(node1);
            Console.WriteLine($"The biggest value is at position: {maxPosition}");
            Console.WriteLine();
            
            Console.WriteLine("Original linked list:");
            IntNode.print(node1);

            
            IntNode prevNode = NodeEx.Prev(node1, node3);
            if (prevNode != null)
            {
                Console.WriteLine($"The node before {node3.GetValue()} is {prevNode.GetValue()}.");
            }
            else
            {
                Console.WriteLine($"There is no node before {node3.GetValue()}.");
            }

            Console.WriteLine();
            Console.WriteLine("Lesson2 :");
            Console.WriteLine();
           
            Node<int> node11 = new Node<int>(10);
            Console.WriteLine("Node1 Value: " + node1.GetValue()); 

            
            Node<string> node12 = new Node<string>("Hello");
            Console.WriteLine("Node2 Value: " + node2.GetValue()); 

            
            Node<int> node13 = new Node<int>(20);
            Node<int> node14 = new Node<int>(30, node13);
            Node<int> node15 = new Node<int>(40, node14);
            
            Console.WriteLine("Node5 List: " + node15.ToPrint()); 

            
            Node<string> node16 = new Node<string>("World");
            Node<string> node7 = new Node<string>("Hello", node16);

            Console.WriteLine("Node7 List: " + node7.ToPrint()); 

            
            node11.SetValue(50);
            node11.SetNext(node15);

            Console.WriteLine("Node1 Modified List: " + node11.ToPrint());
            Console.WriteLine();
            Console.WriteLine("Lesson2 HomeWork :");
            DemoRunHomeWork.DemoMain();
        }
    }

    
    
}
