using Data_Strucher_Lesson1.Classes.Lesson7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class TwoWayListEx
    {
        //EX1
        public static BinNode<int> BuildRandomList(int size, int from, int to)
        {

            Random rnd = new Random();
            int rootValue = rnd.Next(from, to);
            BinNode<int> root = new BinNode<int>(rootValue);
            BinNode<int> pos = root;

            for (int i = 1; i < size; i++)
            {
                int randomValue = rnd.Next(from, to);
                pos.SetRight(new BinNode<int>(pos, randomValue, null));
                pos = pos.GetRight();
            }
            return root;
        }
        public static void PrintPos(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos + ",");
                pos = pos.GetRight();
            }
            Console.WriteLine("]");
        }

        //EX2
        public static void PrintToLeft(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            Console.Write("[");
            while (pos.HasRight())
            {
                pos = pos.GetRight();
            }
            while (pos != null)
            {
                Console.Write(pos + ",");
                pos = pos.GetLeft();
            }
            Console.WriteLine("]");
        }

        //EX3
        public static void PrintToRight(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos + ",");
                pos = pos.GetRight();
            }
            Console.WriteLine("]");
        }
        //EX4
        public static void AddThreeNumbers(BinNode<int> list, int from, int to)
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
        public static BinNode<int> DeletePos(BinNode<int> lst, int x)
        {
            BinNode<int> pos = lst;
            while (pos != null)
            {
                if (pos.GetValue() > x)
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
            return pos;
        }
       

        //EX6
        public static BinNode<int> BuildPos()
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
        public static bool IsTheListPhilandrom(BinNode<int> lst)
        {
            if (lst == null) return true;
            BinNode<int> tail = lst;
            while (tail.HasRight())
            {
                tail = tail.GetRight();
            }
            BinNode<int> start = lst;
            while (start != null && tail != null )
            {
                if (start.GetValue() != tail.GetValue())
                {
                    return false;
                }
                start = start.GetLeft();
                tail = tail.GetRight();
            }
            return true;
        }
        //EX7
        public static BinNode<int> BuildUp(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("The size of the list should be greater than 0!");
            }

            Random rnd = new Random();
            int randomValue = rnd.Next(1, 31);
            BinNode<int> firstValue = new BinNode<int>(randomValue);
            BinNode<int> pos = firstValue;

            for (int i = 1; i < size; i++)
            {
                int newValue;
                do
                {
                    newValue = rnd.Next(1, 31);
                } while (newValue <= pos.GetValue());

                BinNode<int> newNode = new BinNode<int>(newValue);
                pos.SetRight(newNode);
                newNode.SetLeft(pos);
                pos = newNode;
            }

            return firstValue;
        }

    }
    public class RunTwoWayListEx
    {
        public static void DemoMain()
        {
            int size = 10;
            int from = 10;
            int to = 100;
            BinNode<int> root = TwoWayListEx.BuildRandomList(size, from, to);
            TwoWayListEx.PrintPos(root);
            Console.WriteLine();
            TwoWayListEx.PrintToLeft(root);
            Console.WriteLine();
            TwoWayListEx.PrintToRight(root);
            TwoWayListEx.DeletePos(root, 50);
            Console.WriteLine("deleteing all the values above 70");
            TwoWayListEx.PrintToRight(root);
            Console.WriteLine();
            //TwoWayListEx.PrintPos(TwoWayListEx.BuildUp(7));
            BinNode<int> list = TwoWayListEx.BuildPos();
            TwoWayListEx.PrintPos(list);
            Console.WriteLine(TwoWayListEx.IsTheListPhilandrom(list) ? "the list is philandrom!" : "the list is not a philandrom!");
            // Add three random numbers to the list
            TwoWayListEx.AddThreeNumbers(root, from, to);

            // Print the updated list from left to right
            Console.WriteLine("\nUpdated list from left to right:");
            TwoWayListEx.PrintPos(root);




        }
    }
}
