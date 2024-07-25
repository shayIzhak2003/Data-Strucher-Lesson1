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
            while(pos!=null)
            {
                BinNode<int> posL = pos.GetLeft();
                BinNode<int> posR = pos.GetRight();

                if (pos.GetValue() > x)
                {
                    if(posL == null && posR == null)
                        return null;

                    if(posL == null)
                    {
                        pos.SetRight(null);
                        posR.SetLeft(null);
                        if(pos == lst) lst = posR;
                    }
                    else if(posR == null)
                    {
                        pos.SetLeft(null);
                        posL.SetRight(null);
                        if(pos == lst) lst = posL;
                    }
                    else
                    {
                        pos.SetLeft(null);
                        pos.SetRight(null);
                        posL.SetRight(posR);
                        posR.SetLeft(posL);
                    }
                }
                pos = pos.GetRight();
            }
            return lst;
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
            TwoWayListEx2.AddThreeRandomNumbers(Rndlst, 1, 50);
            TwoWayListEx2.PrintPosToRight(Rndlst);
            TwoWayListEx2.DeletePosFromList(Rndlst,80);
            TwoWayListEx2.PrintPosToRight(Rndlst);


        }
    }

}
