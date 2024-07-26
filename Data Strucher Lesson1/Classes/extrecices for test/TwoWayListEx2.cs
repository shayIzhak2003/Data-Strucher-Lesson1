using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class TwoWayListEx2
    {
        //EX1
        public static BinNode<int> GenarateRandomList(int size, int from, int to)
        {
            if (from >= to)
                throw new ArgumentException($"error the gap of {from}-{to} is not valid!");

            Random random = new Random();
            int root = random.Next(from, to);
            BinNode<int> firstValue = new BinNode<int>(root);
            BinNode<int> pos = firstValue;

            for (int i = 0; i < size; i++)
            {
                int newValue = random.Next(from, to);
                pos.SetRight(new BinNode<int>(pos, newValue, null));
                pos = pos.GetRight();
            }
            return firstValue;

        }
        //EX2
        public static void PrintPosToRight(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos.GetValue() + ",");
                pos = pos.GetRight();
            }
            Console.WriteLine("]");
        }
        //EX3
        public static void PrintPosToLeft(BinNode<int> lst)
        {
            BinNode<int> pos = lst;
            while (pos.HasRight())
            {
                pos = pos.GetRight();
            }
            Console.Write("[");
            while (pos != null)
            {
                Console.Write(pos.GetValue() + ",");
                pos = pos.GetLeft();
            }
            Console.WriteLine("]");
        }
        //EX4
        public static void AddThreeRandomNumbers(BinNode<int> list, int from, int to)
        {
            Random random = new Random();
            // Generate three random numbers
            int firstNum = random.Next(from, to);
            int secondNum = random.Next(from, to);
            int thirdNum = random.Next(from, to);

            BinNode<int> newStart = new BinNode<int>(firstNum);
            newStart.SetRight(list);
            list.SetLeft(newStart);

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
        public static BinNode<int> DeletePosFromList(BinNode<int> lst, int x)
        {
            BinNode<int> pos = lst;
            while (pos != null)
            {
                BinNode<int> posL = pos.GetLeft();
                BinNode<int> posR = pos.GetRight();

                if (pos.GetValue() > x)
                {
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
        public static bool IsPosPhilandron(BinNode<int> lst)
        {
            if (lst == null) return true;
            BinNode<int> tail = lst;
            while (tail.HasRight())
            {
                tail = tail.GetRight();
            }
            BinNode<int> start = lst;
            while (start != null && tail != null)
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
        public static BinNode<int> GenarateRandomSortedList(int size)
        {
            Random random = new Random();
            int rootValue = random.Next(1, 31);
            BinNode<int> root = new BinNode<int>(rootValue);
            BinNode<int> pos = root;

            for (int i = 0; i <= size; i++)
            {
                int newValue;
                do
                {
                    newValue = random.Next(1, 31);
                } while (newValue <= pos.GetValue());

                BinNode<int> newNode = new BinNode<int>(newValue);
                pos.SetRight(newNode);
                newNode.SetLeft(pos);
                pos = newNode;
            }
            return root;
        }

    }
    public class RunTwoWayListEx2
    {
        public static void DemoMain()
        {
            int size = 10;
            int from = 10;
            int to = 100;
            BinNode<int> Rndlst = TwoWayListEx2.GenarateRandomList(10, 1, 100);
            TwoWayListEx2.PrintPosToRight(Rndlst);
            TwoWayListEx2.PrintPosToLeft(Rndlst);
            //TwoWayListEx2.AddThreeRandomNumbers(Rndlst, 1, 50);
            //TwoWayListEx2.PrintPosToRight(Rndlst);
            TwoWayListEx2.DeletePosFromList(Rndlst, 80);
            TwoWayListEx2.PrintPosToRight(Rndlst);
            //BinNode<int> sortedList = TwoWayListEx2.GenarateRandomSortedList(4);
            //TwoWayListEx2.PrintPosToRight(sortedList);
            BinNode<int> list =  TwoWayListEx2.BuildPos();
            Console.WriteLine($"is the list philandrom? {TwoWayListEx2.IsPosPhilandron(list)}");

        }
    }

}
