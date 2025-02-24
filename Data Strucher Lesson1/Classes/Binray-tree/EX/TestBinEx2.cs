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

        //EX1
        public static int GetTreeCount<T>(BinNode<T> root)
        {
            if (root == null)
            { return 0; }

            return 1 + GetTreeCount(root.GetLeft()) + GetTreeCount(root.GetRight());
        }
        //EX2
        public static int SumOfEvenValuesInTree(BinNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.GetValue() % 2 == 0)
            {
                return root.GetValue() + SumOfEvenValuesInTree(root.GetLeft())
                           + SumOfEvenValuesInTree(root.GetRight());
            }
            return SumOfEvenValuesInTree(root.GetLeft())
                           + SumOfEvenValuesInTree(root.GetRight());
        }
        //EX3
        public static int SumOfLeavesInTree(BinNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.GetLeft() == null && root.GetRight() == null)
            {
                return root.GetValue() + SumOfLeavesInTree(root.GetLeft())
                          + SumOfLeavesInTree(root.GetRight());
            }
            return SumOfLeavesInTree(root.GetLeft())
                          + SumOfLeavesInTree(root.GetRight());
        }
        //EX4
        public static int CountTwoSonsNodesInTree<T>(BinNode<T> root)
        {
            if (root == null)
            { return 0; }
            if (root.GetLeft() != null && root.GetRight() != null)
            {
                return 1 + CountTwoSonsNodesInTree(root.GetLeft())
                         + CountTwoSonsNodesInTree(root.GetRight());
            }
            return CountTwoSonsNodesInTree(root.GetLeft())
                         + CountTwoSonsNodesInTree(root.GetRight());
        }
        //EX5
        public static int CountNodesThatAreBiggerThenBothSons(BinNode<int> root)
        {
            if (root == null)
            { return 0; }
            if (root.GetLeft() != null && root.GetRight() != null &&
                root.GetValue() > root.GetLeft().GetValue() &&
                root.GetValue() > root.GetRight().GetValue())
            {
                return 1 + CountNodesThatAreBiggerThenBothSons(root.GetLeft()) +
                      CountNodesThatAreBiggerThenBothSons(root.GetRight());
            }
            return CountNodesThatAreBiggerThenBothSons(root.GetLeft()) +
                    CountNodesThatAreBiggerThenBothSons(root.GetRight());
        }
        //EX6
        public static bool EvaluateBooleanTree(BinNode<string> root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));


            if (root.GetValue() == "T")
                return true;
            if (root.GetValue() == "F")
                return false;


            if (root.GetValue() == "AND")
            {
                return EvaluateBooleanTree(root.GetLeft()) && EvaluateBooleanTree(root.GetRight());
            }
            else if (root.GetValue() == "OR")
            {
                return EvaluateBooleanTree(root.GetLeft()) || EvaluateBooleanTree(root.GetRight());
            }
            else
            {
                throw new InvalidOperationException("Invalid operator: " + root.GetValue());
            }
        }

        public static bool CheckTree(BinNode<int> tr)
        {
            tr.SetRight(new BinNode<int>(tr.GetValue() / 2));
            tr.SetLeft(new BinNode<int>(2));
            return true;
        }

    }
    public class RunTestBinEx2
    {
        public static void DemoMain()
        {

            // int tree
            var root = new BinNode<int>(10);


            //BinNode<string> tree = new BinNode<string>(
            //    new BinNode<string>("T"),
            //    "AND",
            //    new BinNode<string>(
            //        new BinNode<string>("F"),
            //        "OR",
            //        new BinNode<string>("T")
            //    )
            //);

            //Console.WriteLine("the main Tree:");
            //TreeLs1.PrintTree(root);
            //Console.WriteLine("the left side values");
            //TestBinEx2.PrintLeftChildrenByInnerPrint(root);
            //TestBinEx2.UpdateFatherToSumOfChilldren(root);
            //Console.WriteLine("the tree after the change:");
            //Console.ForegroundColor = ConsoleColor.Green;
            //TreeLs1.PrintTree(root);
            //Console.ResetColor();
            //Console.WriteLine("=======");
            //Console.WriteLine($"the tree count is => {TestBinEx2.GetTreeCount(root)}");
            //Console.WriteLine("=======");
            //Console.WriteLine();
            //Console.WriteLine($"the even values sum in the binary tree is :=> {TestBinEx2.SumOfEvenValuesInTree(root)}");
            //Console.WriteLine($"the sum of the leaves in the tree is :=> {TestBinEx2.SumOfLeavesInTree(root)}");
            //Console.WriteLine($"the amount od nodes that has to sons on tree is {TestBinEx2.CountTwoSonsNodesInTree(root)}");
            //Console.WriteLine($"the number of nodes that are bigger then thire both sons:=> {TestBinEx2.CountNodesThatAreBiggerThenBothSons(root)}");
            //Console.WriteLine($"the result of the tree is :=> {TestBinEx2.EvaluateBooleanTree(tree)}");

            Console.WriteLine(TestBinEx2.CheckTree(root));
            TreeLs1.PrintTree(root);
        }
    }
}
