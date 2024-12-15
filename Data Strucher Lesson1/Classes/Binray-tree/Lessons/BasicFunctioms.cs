using Data_Structure_Lesson1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Binray_tree.Lessons
{
    public class BasicFunctioms
    {
        // void Functions

        //EX1
        // פעולה המדפיסה את ערכי הבנים השמאליים לפי סריקה תוכית
        public static void PrintLeftChildren<T>(BinNode<T> root)
        {
            if (root == null)
                return;


            // סרוק את תת-העץ השמאלי
            PrintLeftChildren(root.GetLeft());
            // אם לצומת הנוכחי יש בן שמאלי, הדפס את ערך הבן השמאלי
            if (root.GetLeft() != null)
            {
                Console.WriteLine(root.GetLeft().GetValue());
            }

            // סרוק את תת-העץ הימני
            PrintLeftChildren(root.GetRight());
        }

        //EX2
        public static void UpdateNodeValuesToSumOfChildren(BinNode<int> root)
        {
            if (root == null || (!root.HasLeft() && !root.HasRight()))
                return;


            UpdateNodeValuesToSumOfChildren(root.GetLeft());
            UpdateNodeValuesToSumOfChildren(root.GetRight());

            // חישוב סכום תת-העצים
            int leftSum = root.GetLeft().GetValue();
            int rightSum = root.GetRight().GetValue();

            // עדכון הערך של האב לסכום תת-העצים
            root.SetValue(leftSum + rightSum);

        }

        //EX3
        public static void UpdateTreeWithPreviousAndNextChars(BinNode<char> root)
        {
            if (root == null)
                return;

            // Update the left child if it exists
            if (root.GetLeft() != null)
            {
                // Set the left child's value to the previous character in the ASCII sequence
                root.GetLeft().SetValue((char)(root.GetValue() - 1));
            }

            // Update the right child if it exists
            if (root.GetRight() != null)
            {
                // Set the right child's value to the next character in the ASCII sequence
                root.GetRight().SetValue((char)(root.GetValue() + 1));
            }

            // Recursively update the left and right children
            UpdateTreeWithPreviousAndNextChars(root.GetLeft());
            UpdateTreeWithPreviousAndNextChars(root.GetRight());
        }

        // count function on the tree
        //EX1
        public static int CountBinTree<T>(BinNode<T> root)
        {
            int count = 0;

            if (root == null)
            {
                return count;
            }

            // Recursive case: count the current node + count of left and right subtrees
            int leftCount = CountBinTree(root.GetLeft());
            int rightCount = CountBinTree(root.GetRight());

            // Return the total count
            return 1 + leftCount + rightCount;

        }
        //EX2
        public static int SumOfEvenValuesOfTheTree(BinNode<int> root)
        {
            // Base case: if the node is null, return 0
            if (root == null)
            {
                return 0;
            }

            if (root.GetValue() % 2 == 0)
            {
                return SumOfEvenValuesOfTheTree(root.GetLeft()) + SumOfEvenValuesOfTheTree(root.GetRight()) + root.GetValue();
            }
            else
            {
                return SumOfEvenValuesOfTheTree(root.GetLeft()) + SumOfEvenValuesOfTheTree(root.GetRight());
            }
        }
        //EX3
        public static int SumOfValuesOfTheTree(BinNode<int> root)
        {
            // Base case: if the node is null, return 0
            if (root == null)
            {
                return 0;
            }

            return SumOfValuesOfTheTree(root.GetLeft()) + SumOfValuesOfTheTree(root.GetRight()) + root.GetValue();
        }
        //EX4
        public static int CountNodesWithTwoChildren<T>(BinNode<T> root)
        {

            // בסיס - אם הצומת ריק, מחזירים 0
            if (root == null)
            {
                return 0;
            }

            // אם לצומת יש שני בנים, הגדל את המונה
            if (root.HasLeft() && root.HasRight())
            {
                return 1 + CountNodesWithTwoChildren(root.GetRight()) + CountNodesWithTwoChildren(root.GetLeft());
            }
            else
            {
                return CountNodesWithTwoChildren(root.GetRight()) + CountNodesWithTwoChildren(root.GetLeft());
            }

        }
        //EX5
        public static int GetBiggerThenChildrenNode(BinNode<int> root)
        {
            // Base case: if the node is null, return 0
            if (root == null)
            {
                return 0;
            }

            // Variable to track if the current node satisfies the condition
            int count = 0;

            // Check both children if they exist
            if (root.HasLeft() && root.HasRight())
            {
                if (root.GetValue() > root.GetLeft().GetValue() && root.GetValue() > root.GetRight().GetValue())
                {
                    count = 1; // This node satisfies the condition
                }
            }
            else if (root.HasLeft())
            {
                if (root.GetValue() > root.GetLeft().GetValue())
                {
                    count = 1; // This node satisfies the condition
                }
            }
            else if (root.HasRight())
            {
                if (root.GetValue() > root.GetRight().GetValue())
                {
                    count = 1; // This node satisfies the condition
                }
            }

            // Recursive call to left and right children
            return count + GetBiggerThenChildrenNode(root.GetLeft()) + GetBiggerThenChildrenNode(root.GetRight());
        }




    }
    public class RunBasicFunctioms
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
            Console.ForegroundColor = ConsoleColor.Red;
            // int functions
            Console.WriteLine("The left children are:");
            BasicFunctioms.PrintLeftChildren(root);
            Console.WriteLine();

            Console.WriteLine("The tree before the update:");
            TreeLs1.PrintTree(root);
            Console.WriteLine();

            // עדכון ערכי הצמתים
            //BasicFunctioms.UpdateNodeValuesToSumOfChildren(root);

            Console.WriteLine("The tree after the update:");
            TreeLs1.PrintTree(root);
            Console.WriteLine();
            Console.ResetColor();
            // char functions
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The tree before the update:");
            TreeLs1.PrintTree(root2);
            Console.WriteLine();

            // עדכון ערכי הצמתים
            BasicFunctioms.UpdateTreeWithPreviousAndNextChars(root2);

            Console.WriteLine("The tree after the update:");
            TreeLs1.PrintTree(root2);
            Console.ResetColor();

            //Console.WriteLine("the tree count is :");
            //Console.WriteLine(BasicFunctioms.CountBinTree(root));
            //Console.WriteLine("the tree even sum is :");
            //Console.WriteLine(BasicFunctioms.SumOfEvenValuesOfTheTree(root));
            //Console.WriteLine("the sum of the tree is :");
            //Console.WriteLine(BasicFunctioms.SumOfValuesOfTheTree(root));
            //Console.WriteLine("nodes with 2 children:");
            //Console.WriteLine(BasicFunctioms.CountNodesWithTwoChildren(root));
            Console.WriteLine("nodes count that are bigger then the children is :");
            Console.WriteLine(BasicFunctioms.GetBiggerThenChildrenNode(root));
        }
    }

}
