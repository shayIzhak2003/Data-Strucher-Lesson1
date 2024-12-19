using Data_Strucher_Lesson1.Classes.Binray_tree.Lessons;
using System;
using System.Collections.Generic;

namespace Data_Strucher_Lesson1.Classes.Binray_tree.EX
{
    public class TetsBinEx1
    {
        // tree void functions
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
        public static void UpdateFatherWithSumOfChildern(BinNode<int> root)
        {
            if (root == null || (!root.HasLeft() && !root.HasRight()))
                return;

            UpdateFatherWithSumOfChildern(root.GetLeft());
            UpdateFatherWithSumOfChildern(root.GetRight());

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

        // trees counter functions
        //EX1
        public static int TreeNodeCount<T>(BinNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            else
            {
                return 1 + TreeNodeCount(root.GetLeft()) + TreeNodeCount(root.GetRight());
            }
        }

        //EX2
        public static int SumEvenNodeValues(BinNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.GetValue() % 2 == 0)
            {
                return root.GetValue() + SumEvenNodeValues(root.GetRight()) + SumEvenNodeValues(root.GetLeft());
            }
            return SumEvenNodeValues(root.GetRight()) + SumEvenNodeValues(root.GetLeft());
        }
        //EX3
        public static int TreeLeafSum(BinNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            if (!root.HasRight() && !root.HasLeft())
            {
                return root.GetValue() + TreeLeafSum(root.GetRight()) + TreeLeafSum(root.GetLeft());
            }
            return TreeLeafSum(root.GetRight()) + TreeLeafSum(root.GetLeft());
        }
        //EX4
        public static int TreeFatherCount<T>(BinNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.HasLeft() && root.HasRight())
            {
                return 1 + TreeFatherCount(root.GetLeft()) + TreeFatherCount(root.GetRight());
            }
            else
            {
                return TreeFatherCount(root.GetLeft()) + TreeFatherCount(root.GetRight());
            }
        }
        //EX5
        public static int NumOfFatherThatBiggerThenChildren(BinNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.HasLeft() && root.HasRight() && root.GetValue() > root.GetLeft().GetValue() &&
                root.GetValue() > root.GetRight().GetValue())
            {
                return 1 + NumOfFatherThatBiggerThenChildren(root.GetLeft())
                      + NumOfFatherThatBiggerThenChildren(root.GetRight());
            }
            return NumOfFatherThatBiggerThenChildren(root.GetLeft()) + NumOfFatherThatBiggerThenChildren(root.GetRight());
        }
       
        // EX6
        public static int SumOfSingleChildren(BinNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            // Case: Node has only a left child
            if (root.HasLeft() && !root.HasRight())
            {
                return root.GetLeft().GetValue()
                       + SumOfSingleChildren(root.GetLeft())
                       + SumOfSingleChildren(root.GetRight());
            }
            // Case: Node has only a right child
            else if (!root.HasLeft() && root.HasRight())
            {
                return root.GetRight().GetValue()
                       + SumOfSingleChildren(root.GetLeft())
                       + SumOfSingleChildren(root.GetRight());
            }

            // Case: Node has no single children
            return SumOfSingleChildren(root.GetLeft()) + SumOfSingleChildren(root.GetRight());
        }
        //EX7
        public static bool IsLeaf<T>(BinNode<T> root)
        {
            // צומת נחשב עלה אם אין לו ילדים משמאל או מימין
            return root != null && !root.HasLeft() && !root.HasRight();
        }


    }
    public class RunTetsBinEx1
    {
        public static void DemoMain()
        {
            Console.WriteLine("Hello,World!");

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


            // char tree
            var root2 = new BinNode<char>('M');
            var leftChild2 = new BinNode<char>('L');
            var rightChild2 = new BinNode<char>('N');
            root2.SetLeft(leftChild2);
            root2.SetRight(rightChild2);

            leftChild2.SetLeft(new BinNode<char>('K'));
            leftChild2.SetRight(new BinNode<char>('O'));
            rightChild2.SetLeft(new BinNode<char>('Q'));
            rightChild2.SetRight(new BinNode<char>('R'));

            Console.WriteLine("the main Tree:");
            TreeLs1.PrintTree(root);
            Console.WriteLine("the left side values");
            TetsBinEx1.PrintLeftChildrenByInnerPrint(root);

            Console.WriteLine("the tree after the update:");
            TetsBinEx1.UpdateFatherWithSumOfChildern(root);
            TreeLs1.PrintTree(root);
            Console.WriteLine($"the tree count is: => {TetsBinEx1.TreeNodeCount(root)}");
            Console.WriteLine($"the sum of the even nodes in the tree is : => {TetsBinEx1.SumEvenNodeValues(root)}");
            Console.WriteLine($"the tree leaf sum is : => {TetsBinEx1.TreeLeafSum(root)}");
            Console.WriteLine($"the father count is : => {TetsBinEx1.TreeFatherCount(root)}");
            Console.WriteLine($"the num of fathers the bigger then children: {TetsBinEx1.NumOfFatherThatBiggerThenChildren(root)}");
            Console.WriteLine($"the the sum of the of the single children is: => {TetsBinEx1.SumOfSingleChildren(root)}");


        }
    }

}
