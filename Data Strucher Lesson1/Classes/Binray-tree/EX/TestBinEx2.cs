using Data_Strucher_Lesson1.Classes.Binray_tree.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Binray_tree.EX
{
    public class TestBinEx2
    {
        // Void Functions 
        //EX1
        public static void PrintLeftChildrenByInnerPrint<T>(BinNode<T> root)
        {

            if (root == null)
                return;
            PrintLeftChildrenByInnerPrint(root.GetLeft());

            if (root.GetLeft() != null)
            {
                Console.WriteLine(root.GetLeft().GetValue());
            }
            PrintLeftChildrenByInnerPrint(root.GetRight());
        }
        //EX2
        public static void UpdateFatherToSumOfChilldren(BinNode<int> root)
        {
            if (root == null || (!root.HasLeft() && !root.HasRight()))
                return;

            UpdateFatherToSumOfChilldren(root.GetLeft());
            UpdateFatherToSumOfChilldren(root.GetRight());

            root.SetValue(root.GetLeft().GetValue() + root.GetRight().GetValue());
        }
        //EX3
        public static void UpdateTreeWithPreviousAndNextChars(BinNode<char> root)
        {
            if (root == null)
            {
                return;
            }

            if (root.HasRight())
            {
                root.GetRight().SetValue((char)(root.GetRight().GetValue() + 1));
            }

            if (root.HasLeft())
            {
                root.GetLeft().SetValue((char)(root.GetLeft().GetValue() + 1));
            }

            UpdateTreeWithPreviousAndNextChars(root.GetLeft());
            UpdateTreeWithPreviousAndNextChars(root.GetRight());
        }

        // counting function on trees
        public static int GetTreeCount<T>(BinNode<T> root)
        {
            if(root == null)
            { return 0; }

            return 1 + GetTreeCount(root.GetLeft()) + GetTreeCount(root.GetRight());
        }


    }
    public class RunTestBinEx2
    {
        public static void DemoMain()
        {

            // int tree
            var root = new BinNode<int>(10);
            var leftChild = new BinNode<int>(5);
            var rightChild = new BinNode<int>(15);
            root.SetLeft(leftChild);
            root.SetRight(rightChild);
            leftChild.SetLeft(new BinNode<int>(3));
            leftChild.SetRight(new BinNode<int>(7));
            rightChild.SetLeft(new BinNode<int>(12));
            rightChild.SetRight(new BinNode<int>(18));
            Console.WriteLine("the main Tree:");
            TreeLs1.PrintTree(root);
            Console.WriteLine("the left side values");
            TestBinEx2.PrintLeftChildrenByInnerPrint(root);
            TestBinEx2.UpdateFatherToSumOfChilldren(root);
            Console.WriteLine("the tree after the change:");
            Console.ForegroundColor = ConsoleColor.Green;
            TreeLs1.PrintTree(root);
            Console.ResetColor();
            Console.WriteLine("=======");
            Console.WriteLine($"the tree count is => {TestBinEx2.GetTreeCount(root)}");
            Console.WriteLine("=======");
        }
    }
}
