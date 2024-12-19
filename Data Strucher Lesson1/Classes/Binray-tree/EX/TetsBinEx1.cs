using Data_Strucher_Lesson1.Classes.Binray_tree.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if(root.GetLeft() != null)
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
            if(root == null)
            {
                return;
            }

            if (root.HasRight())
            {
                root.GetRight().SetValue((char)(root.GetRight().GetValue() + 1));
            }

            if(root.HasLeft())
            {
                root.GetLeft().SetValue((char)(root.GetLeft().GetValue() + 1));
            }

            UpdateTreeWithPreviousAndNextChars(root.GetLeft());
            UpdateTreeWithPreviousAndNextChars(root.GetRight());
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
        }
    }

}
