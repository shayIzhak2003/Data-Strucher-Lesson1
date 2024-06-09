using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Strucher_Lesson1.Classes.Lesson3
{
    public class Ls3NoneEx
    {
        //EX1
        public static bool ArePositiveNumbersMore(Node<int> head)
        {
            int positiveCount = 0;
            int negativeCount = 0;

            Node<int> currentNode = head;

            while (currentNode != null)
            {
                int value = currentNode.GetValue();
                if(value > 0)
                {
                    positiveCount++;
                }
                else if (value < 0)
                {
                    negativeCount++;
                }

                currentNode = currentNode.GetNext();
            }

            return positiveCount > negativeCount;

        }

        //EX2
        public static bool IsGoingUp(Node<int> head)
        {
            Node<int> currentNode = head;
            while (currentNode != null)
            {
                Node<int> next = currentNode.GetNext();
                if (next != null && currentNode.GetValue() >= next.GetValue())
                {
                    return false;   
                }
                currentNode = currentNode.GetNext();
            }
            return true;
        }

        //EX3
        public static bool IsNameInOrder(Node<char> head, string name)
        {
            Node<char> currentNode = head;
            int index = 0;
            while (currentNode != null && index < name.Length)
            {
                if (currentNode.GetValue() == name[index])
                {
                    index++;
                }
                currentNode = currentNode.GetNext();
            }
            return index == name.Length;
        }

        //EX4
        public static void AddEvenNumbers(Node<int> c1, Node<int> c2)
        {
            Node<int> currentNodeC1 = c1;
            Node<int> lastNodeC2 = c2;

            // מציאת החוליה האחרונה ב-C2
            while (lastNodeC2.GetNext() != null)
            {
                lastNodeC2 = lastNodeC2.GetNext();
            }

            // מעבר על כל האיברים ב-C1 והוספת האיברים הזוגיים ל-C2
            while (currentNodeC1 != null)
            {
                if (currentNodeC1.GetValue() % 2 == 0)
                {
                    lastNodeC2.SetNext(new Node<int>(currentNodeC1.GetValue()));
                    lastNodeC2 = lastNodeC2.GetNext();
                }
                currentNodeC1 = currentNodeC1.GetNext();
            }
        }

        //EX5
        public static Node<int> ListMulti(Node<int> head)
        {
            if (head == null || head.GetNext() == null)
            {
                return null;
            }

            Node<int> currentNode = head;
            Node<int> resultHead = null;
            Node<int> resultTail = null;

            while (currentNode != null && currentNode.GetNext() != null)
            {
                int number = currentNode.GetValue();
                int count = currentNode.GetNext().GetValue();
                int product = number * count;

                Node<int> newNode = new Node<int>(product);

                if (resultHead == null)
                {
                    resultHead = newNode;
                    resultTail = newNode;
                }
                else
                {
                    resultTail.SetNext(newNode);
                    resultTail = newNode;
                }

                
                currentNode = currentNode.GetNext().GetNext();
            }

            return resultHead;
        }

        //EX6
        public static Node<int> ListBuild(Node<int> head)
        {
            Node<int> pos = head;
            Node<int> newHead = null;
            Node<int> newTail = null;

            while (pos != null)
            {
                int num = pos.GetValue();
                int count = pos.GetNext().GetValue(); 

                for (int i = 0; i < count; i++)
                {
                    if (newHead == null)
                    {
                        newHead = new Node<int>(num);
                        newTail = newHead;
                    }
                    else
                    {
                        Node<int> newNode = new Node<int>(num);
                        newTail.SetNext(newNode);
                        newTail = newNode;
                    }
                }

                pos = pos.GetNext().GetNext(); 
            }

            return newHead;
        }


        //EX7
        public static Node<int> ReverseLinkedList(Node<int> head)
        {
            Node<int> prev = null;
            Node<int> current = head;
            Node<int> next = null;

            while(current != null)
            {
                next = current.GetNext(); 
                current.SetNext(prev); 

                
                prev = current;
                current = next;
            }   
             
            head = prev;

            return head;
        }

        //EX8
        public static bool IsCircularLinkedList(Node<int> head)
        {
            if (head == null)
                return false;

            Node<int> slow = head;
            Node<int> fast = head;

            while (fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();

                // If fast and slow pointers meet, then the linked list is cyclic
                if (slow == fast)
                    return true;
            }

            // If we reach here, it means we didn't encounter a cycle
            return false;
        }
    }



    public class RunLs3NoneEx 
    {
        public static void RunDemoMain()
        {
            // יצירת שרשרת מספרים לדוגמה
            Node<int> node5 = new Node<int>(14);
            Node<int> node4 = new Node<int>(13, node5);
            Node<int> node3 = new Node<int>(12, node4);
            Node<int> node2 = new Node<int>(11, node3);
            Node<int> node1 = new Node<int>(10, node2);

            Console.WriteLine("List of numbers: " + node1.ToPrint());

            bool resultPositive = Ls3NoneEx.ArePositiveNumbersMore(node1);
            Console.WriteLine("More positive numbers than negative: " + resultPositive);

            bool isGoingUpResults = Ls3NoneEx.IsGoingUp(node1);
            Console.WriteLine("Is the list going up? : " + isGoingUpResults);

            // יצירת שרשרת תווים לדוגמה
            Node<char> charNode4 = new Node<char>('a');
            Node<char> charNode3 = new Node<char>('t', charNode4);
            Node<char> charNode2 = new Node<char>('i', charNode3);
            Node<char> charNode1 = new Node<char>('d', charNode2);

            Console.WriteLine("List of characters: " + charNode1.ToPrint());

            string name = "dita";
            bool isNameInOrderResult = Ls3NoneEx.IsNameInOrder(charNode1, name);
            Console.WriteLine($"Is the name '{name}' in order? : {isNameInOrderResult}");

            // יצירת שרשרת תווים נוספת לדוגמה
            Node<char> charNode8 = new Node<char>('b');
            Node<char> charNode7 = new Node<char>('a', charNode8);
            Node<char> charNode6 = new Node<char>('t', charNode7);
            Node<char> charNode5Alt = new Node<char>('i', charNode6);
            Node<char> charNode4Alt = new Node<char>('d', charNode5Alt);
            Node<char> charNode3Alt = new Node<char>('f', charNode4Alt);
            Node<char> charNode2Alt = new Node<char>('l', charNode3Alt);

            Console.WriteLine("Another list of characters: " + charNode2Alt.ToPrint());

            isNameInOrderResult = Ls3NoneEx.IsNameInOrder(charNode2Alt, name);
            Console.WriteLine($"Is the name '{name}' in order? : {isNameInOrderResult}");

            // יצירת שרשרת C1
            Node<int> c1Node4 = new Node<int>(15);
            Node<int> c1Node3 = new Node<int>(14, c1Node4);
            Node<int> c1Node2 = new Node<int>(12, c1Node3);
            Node<int> c1Node1 = new Node<int>(10, c1Node2);

            Console.WriteLine("C1: " + c1Node1.ToPrint());

            // יצירת שרשרת C2
            Node<int> c2Node2 = new Node<int>(1);
            Node<int> c2Node1 = new Node<int>(0, c2Node2);

            Console.WriteLine("C2 (Before): " + c2Node1.ToPrint());

            // הוספת האיברים הזוגיים של C1 ל-C2
            Ls3NoneEx.AddEvenNumbers(c1Node1, c2Node1);

            Console.WriteLine("C2 (After adding evens from C1): " + c2Node1.ToPrint());

            // יצירת שרשרת לסדרת קטעים
            Node<int> node8 = new Node<int>(7);
            Node<int> node7 = new Node<int>(5, node8);
            Node<int> node6 = new Node<int>(6, node7);
            Node<int> node9 = new Node<int>(3, node6);

            Console.WriteLine("Original List of Segments: " + node9.ToPrint());

            // הפעלת הפונקציה ListMulti
            Node<int> result = Ls3NoneEx.ListMulti(node9);
            Console.WriteLine("Result List: " + result.ToPrint());

            // הפעלת הפונקציה ListBuild
            Node<int> result2 = Ls3NoneEx.ListBuild(node9);
            Console.WriteLine("Result List: " + result2.ToPrint());
            Console.WriteLine("\noriginnal list :" + node9.ToPrint());
            Node<int> result3 = Ls3NoneEx.ReverseLinkedList(node9);
            Console.WriteLine("Reversed List: " + result3.ToPrint());

           bool result4 = Ls3NoneEx.IsCircularLinkedList(node9);
            Console.WriteLine($"\nIs The List : => {node9.ToPrint()} reciceled ? : {result4}");
        }
    }

}
