using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson7
{
    //EX1
    public class BuildRandomList
    {
        // EX1
        public static BinNode<int> GetBiList(int size, int from, int to)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive number.", nameof(size));
            if (from >= to)
                throw new ArgumentException("From must be less than to.", nameof(from));

            Random rnd = new Random();
            int rootValue = rnd.Next(from, to);
            BinNode<int> root = new BinNode<int>(rootValue);
            BinNode<int> pos = root;

            for (int i = 1; i < size; i++)
            {
                int newValue = rnd.Next(from, to);
                pos.SetRight(new BinNode<int>(pos, newValue, null));
                pos = pos.GetRight();
            }

            return root;
        }

        #region EX2 and EX3
        public static void PrintLeftToRight(BinNode<int> lst)
        {
            Console.Write("[");
            BinNode<int> pos = lst;

            while (pos != null)
            {
                Console.Write(pos.GetValue());
                if (pos.HasRight())
                    Console.Write(", ");

                pos = pos.GetRight();
            }
            Console.Write("]");
        }

        public static void PrintRightToLeft(BinNode<int> lst)
        {
            if (lst == null)
                return;

            // Traverse to the rightmost node
            BinNode<int> pos = lst;
            while (pos.HasRight())
            {
                pos = pos.GetRight();
            }

            // Print from right to left
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos.GetValue());
                if (pos.GetLeft() != null)
                    Console.Write(", ");
                pos = pos.GetLeft();
            }
            Console.WriteLine("]");
        }
        #endregion

        // EX4
        public static void AddRandomNumbersToList(BinNode<int> list, int from, int to)
        {
            Random random = new Random();

            // Generate three random numbers
            int firstNum = random.Next(from, to);
            int secondNum = random.Next(from, to);
            int thirdNum = random.Next(from, to);

            // Add firstNum to the start of the list
            BinNode<int> newStart = new BinNode<int>(firstNum);
            newStart.SetRight(list);
            list.SetLeft(newStart);

            // Find the end of the list and add secondNum
            BinNode<int> pos = list;
            while (pos.HasRight())
            {
                pos = pos.GetRight();
            }
            pos.SetRight(new BinNode<int>(pos, secondNum, null));

            // Find the middle of the list and add thirdNum
            BinNode<int> middle = list;
            int count = 0;
            while (middle.HasRight())
            {
                middle = middle.GetRight();
                count++;
            }

            BinNode<int> midNode = list;
            for (int i = 0; i < count / 2; i++)
            {
                midNode = midNode.GetRight();
            }
            BinNode<int> newMiddle = new BinNode<int>(midNode, thirdNum, midNode.GetRight());
            if (midNode.HasRight())
            {
                midNode.GetRight().SetLeft(newMiddle);
            }
            midNode.SetRight(newMiddle);
        }
        //EX5
        public static BinNode<int> DeleteFromList(BinNode<int> lst, int num)
        {
            BinNode<int> pos = lst;

            while (pos != null)
            {
                if (pos.GetValue() > num)
                {
                    BinNode<int> posL = pos.GetLeft();
                    BinNode<int> posR = pos.GetRight();

                    if (posL == null && posR == null)
                    {
                        // Node is a single node and matches the condition, list becomes empty
                        return null;
                    }
                    else if (posL == null)
                    {
                        // Node is the head of the list
                        posR.SetLeft(null);
                        if (pos == lst) lst = posR;
                    }
                    else if (posR == null)
                    {
                        // Node is the tail of the list
                        posL.SetRight(null);
                        if (pos == lst) lst = posL;
                    }
                    else
                    {
                        // Node is in the middle of the list
                        posL.SetRight(posR);
                        posR.SetLeft(posL);
                        if (pos == lst) lst = posR;
                    }
                }
                pos = pos.GetRight();
            }

            return lst;
        }
        //EX6
        public static BinNode<int> BuildBiList()
        {
            Console.Write("Enter the size for the list: ");
            int size = int.Parse(Console.ReadLine());

            if (size <= 0)
            {
                throw new ArgumentException("Size must be a positive number.");
            }

            Console.WriteLine("Enter the values for the list:");

            // Create the head node with the first value
            Console.Write("Value 1: ");
            int firstValue = int.Parse(Console.ReadLine());
            BinNode<int> head = new BinNode<int>(firstValue);
            BinNode<int> current = head;

            // Create the rest of the list
            for (int i = 1; i < size; i++)
            {
                Console.Write($"Value {i + 1}: ");
                int newValue = int.Parse(Console.ReadLine());
                BinNode<int> newNode = new BinNode<int>(newValue);
                current.SetRight(newNode);
                newNode.SetLeft(current);
                current = newNode;
            }


            return head;
        }
        public static bool IsPalindrom(BinNode<int> head)
        {
            if (head == null) return true;

            // Find the end of the list
            BinNode<int> tail = head;
            while (tail.HasRight())
            {
                tail = tail.GetRight();
            }

            // Check for palindrome
            BinNode<int> start = head;
            while (start != null && tail != null && start != tail && start.GetLeft() != tail)
            {
                if (start.GetValue() != tail.GetValue())
                    return false;

                start = start.GetRight();
                tail = tail.GetLeft();
            }

            return true;
        }
        //EX7
        public static BinNode<int> BuildStored(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive number.", nameof(size));

            Random rnd = new Random();
            int rootValue = rnd.Next(1, 30);
            BinNode<int> root = new BinNode<int>(rootValue);

            for (int i = 1; i < size; i++)
            {
                int newValue = rnd.Next(1, 30);
                BinNode<int> currentNode = root;
                BinNode<int> previousNode = null;

                // Traverse the list to find the correct position to insert the new value
                while (currentNode != null && currentNode.GetValue() < newValue)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.GetRight();
                }

                BinNode<int> newNode = new BinNode<int>(newValue);

                if (previousNode == null)
                {
                    // Insert at the beginning
                    newNode.SetRight(root);
                    root.SetLeft(newNode);
                    root = newNode;
                }
                else
                {
                    // Insert between previousNode and currentNode
                    newNode.SetRight(currentNode);
                    newNode.SetLeft(previousNode);
                    previousNode.SetRight(newNode);
                    if (currentNode != null)
                    {
                        currentNode.SetLeft(newNode);
                    }
                }
            }

            return root;
        }


    }

    public class RunBuildRandomList
    {
        public static void DemoMain()
        {
            int size = 10; // Specify the size of the list
            int from = 1;  // Specify the lower bound of the random range
            int to = 100;  // Specify the upper bound of the random range

            Console.WriteLine("Random List:");
            // Create a binary list with random positive numbers
            BinNode<int> list = BuildRandomList.GetBiList(size, from, to);
            PrintList(list);

            // Print the list from left to right
            Console.WriteLine("List from left to right:");
            BuildRandomList.PrintLeftToRight(list);

            // Print the list from right to left
            Console.WriteLine("\nList from right to left:");
            BuildRandomList.PrintRightToLeft(list);

            // Add three random numbers to the list
            BuildRandomList.AddRandomNumbersToList(list, from, to);

            // Print the updated list from left to right
            Console.WriteLine("\nUpdated list from left to right:");
            BuildRandomList.PrintLeftToRight(list);

            Console.WriteLine("\nthe original list:");
            PrintList(list);
            int num = 60;
            Console.WriteLine($"the list after deleting all the values above {num}");
            BuildRandomList.DeleteFromList(list, num);
            PrintList(list);

            Console.WriteLine();
            BinNode<int> lst = BuildRandomList.BuildBiList();
            PrintList(lst);
            Console.WriteLine();
            Console.WriteLine(BuildRandomList.IsPalindrom(lst) ? "the list is philandrom!" : "the list in not a philandrom");
            BinNode<int> newList = BuildRandomList.BuildStored(5);
            Console.WriteLine();
            PrintList(newList);
        }

        public static void PrintList(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            while (pos != null)
            {
                Console.WriteLine(pos);
                pos = pos.GetRight();
            }

        }
    }
}
