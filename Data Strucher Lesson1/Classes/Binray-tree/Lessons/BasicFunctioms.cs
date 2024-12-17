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
            if (root.HasLeft())
            {
                // Set the left child's value to the previous character in the ASCII sequence
                root.GetLeft().SetValue((char)(root.GetLeft().GetValue() - 1));
            }

            // Update the right child if it exists
            if (root.HasRight())
            {
                // Set the right child's value to the next character in the ASCII sequence
                root.GetRight().SetValue((char)(root.GetRight().GetValue() + 1));
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
            if ((root.HasLeft() && root.HasRight() && root.GetValue() > root.GetLeft().GetValue() && root.GetValue() >
                root.GetRight().GetValue()) || (root.HasLeft() && root.GetValue() > root.GetLeft().GetValue()) ||
                (root.HasRight() && root.GetValue() > root.GetRight().GetValue()))
            {
                return 1 + GetBiggerThenChildrenNode(root.GetLeft()) + GetBiggerThenChildrenNode(root.GetRight());
            }
            else
            {
                return GetBiggerThenChildrenNode(root.GetLeft()) + GetBiggerThenChildrenNode(root.GetRight());
            }

        }
        //EX6
        public static int GetSingleBrothersCount<T>(BinNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.HasLeft() && !root.HasRight() || root.HasRight() && !root.HasLeft())
            {
                return 1 + GetSingleBrothersCount(root.GetLeft()) + GetSingleBrothersCount(root.GetRight());
            }
            else
            {
                return GetSingleBrothersCount(root.GetLeft()) + GetSingleBrothersCount(root.GetRight());
            }
        }
        //EX7
        public static bool IsLeaf<T>(BinNode<T> root)
        {
            // צומת נחשב עלה אם אין לו ילדים משמאל או מימין
            return root != null && !root.HasLeft() && !root.HasRight();
        }
        //EX8
        public static int GetLeafCount<T>(BinNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            if (IsLeaf(root))
            {
                return 1 + GetLeafCount(root.GetLeft()) + GetLeafCount(root.GetRight());
            }
            else
            {
                return GetLeafCount(root.GetLeft()) + GetLeafCount(root.GetRight());
            }
        }
        //EX9
        public static int GetNumCountInTheTree<T>(BinNode<T> root, T value)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.GetValue().Equals(value))
            {
                return 1 + GetNumCountInTheTree(root.GetLeft(), value) + GetNumCountInTheTree(root.GetRight(), value);
            }
            else
            {
                return GetNumCountInTheTree(root.GetLeft(), value) + GetNumCountInTheTree(root.GetRight(), value);
            }
        }
        //EX10
        public static int CountNodesAtLevel<T>(BinNode<T> root, int level)
        {
            // Base case: if the tree is empty, return 0
            if (root == null)
            {
                return 0;
            }

            // If the current level is 0, we are at the desired level
            if (level == 0)
            {
                return 1;
            }
            else
            {
                // Recursively count nodes at the level in the left and right subtrees
                return CountNodesAtLevel(root.GetLeft(), level - 1) + CountNodesAtLevel(root.GetRight(), level - 1);
            }
        }
        //EX11
        public static int SumNodesAtLevel(BinNode<int> root, int level)
        {
            // Base case: if the tree is empty, return 0
            if (root == null)
            {
                return 0;
            }

            // If the current level is 0, we are at the desired level, return the value of the node
            if (level == 0)
            {
                return root.GetValue();
            }
            else
            {
                // Recursively calculate the sum of nodes at the desired level in the left and right subtrees
                return SumNodesAtLevel(root.GetLeft(), level - 1) + SumNodesAtLevel(root.GetRight(), level - 1);
            }
        }

        // boolean functions on tree
        //EX1
        public static bool checkForPositiveTree(BinNode<int> root)
        {
            if (root == null)
            {
                return true;
            }

            if (root.GetValue() < 0)
            {
                return false;
            }
            else
            {
                return checkForPositiveTree(root.GetLeft()) && checkForPositiveTree(root.GetRight());
            }
        }

        //EX2
        public static bool NoSingleChildren<T>(BinNode<T> root)
        {
            if (root == null)
            {
                return true;
            }
            if (root.HasLeft() && !root.HasRight() || !root.HasLeft() && root.HasRight())
            {
                return false;
            }

            else
            {
                return NoSingleChildren(root.GetLeft()) && NoSingleChildren(root.GetRight());
            }
        }

        //EX3
        public static bool IsValueInsideTheTree<T>(BinNode<T> root, T value)
        {
            if (root == null)
            {
                return false; // Base case: tree is empty
            }
            else if (root.GetValue().Equals(value))
            {
                return true; // Value found at the current node
            }
            else
            {
                // Check if the value exists in either the left or right subtree
                return IsValueInsideTheTree(root.GetLeft(), value) || IsValueInsideTheTree(root.GetRight(), value);
            }
        }

        //EX4
        public static bool IsDescendant(BinNode<int> root, int x, int y)
        {
            if (root == null)
            {
                return false; // Base case: tree is empty
            }

            // If the current node's value is Y, check if X exists in the subtree rooted at this node
            if (root.GetValue() == y)
            {
                return IsValueInsideTheTree(root, x);
            }

            // Otherwise, search in the left and right subtrees
            return IsDescendant(root.GetLeft(), x, y) || IsDescendant(root.GetRight(), x, y);
        }

        //more exercise
        //EX1
        public static int GetTreeHeight<T>(BinNode<T> root)
        {
            if (root == null)
            {
                return -1; // Returning -1 for an empty tree to indicate height correctly for non-empty trees.
            }

            int leftHeight = GetTreeHeight(root.GetLeft());
            int rightHeight = GetTreeHeight(root.GetRight());

            return Math.Max(leftHeight, rightHeight) + 1;
        }
        //EX2
        public static int GetMaxValue(BinNode<int> root)
        {
            if (root == null)
            {
                return 0; 
            }

            else
            {
                return Math.Max(GetMaxValue(root.GetRight()), Math.Max(GetMaxValue(root.GetLeft()), root.GetValue()));
            }
        }
        //EX3
        public static bool IsBalanced(BinNode<int> root)
        {
            if (root == null)
            {
                return true; 
            }

            // Get the height of the left subtree.
            int leftHeight = GetTreeHeight(root.GetLeft());

            // Get the height of the right subtree.
            int rightHeight = GetTreeHeight(root.GetRight());

            // If the height difference between left and right subtrees is greater than 1, return false (unbalanced).
            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return false;
            }

            // Recursively check the balance of the left and right subtrees.
            return IsBalanced(root.GetLeft()) && IsBalanced(root.GetRight());
        }

        //EX4
        public static void AddSiblingToSingleNodes<T>(BinNode<T> root)
        {
            if(root == null)
            {
                return;
            }
            
            if(root.HasLeft() && !root.HasRight())
            {
                root.SetRight(new BinNode<T>(root.GetLeft().GetValue()));
            }

            else if (root.HasRight() && !root.HasLeft())
            {
                root.SetLeft(new BinNode<T>(root.GetRight().GetValue()));
            }

            // Recursively process the left and right subtrees.
            AddSiblingToSingleNodes(root.GetLeft());
            AddSiblingToSingleNodes(root.GetRight());
        }
        //EX5
        public static BinNode<T> FindParent<T>(BinNode<T> root, T value)
        {
            // Base case: if the tree is empty or if the root is the node containing the value, return null.
            if (root == null ||
                (root.HasLeft() && root.GetLeft().GetValue().Equals(value)) ||
                (root.HasRight() && root.GetRight().GetValue().Equals(value)))
            {
                return root;
            }

            // Search in the left subtree.
            BinNode<T> leftResult = FindParent(root.GetLeft(), value);
            if (leftResult != null)
            {
                return leftResult;
            }

            // Search in the right subtree.
            return FindParent(root.GetRight(), value);
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("the single brother count of the integer binary tree is:");
            Console.WriteLine(BasicFunctioms.GetSingleBrothersCount(root));
            Console.WriteLine($"is 3 a leaf ? {BasicFunctioms.IsLeaf(leftChild.GetLeft())}");
            Console.WriteLine(leftChild.GetLeft().GetValue());
            Console.WriteLine($"the leaf count in the integer binary tree is: =>  {BasicFunctioms.GetLeafCount(root)}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"the amount of times that 3 is on the tree is : => {BasicFunctioms.GetNumCountInTheTree(root, 3)}");
            Console.WriteLine($"the amount of the same level node is : => {BasicFunctioms.CountNodesAtLevel(root, 2)}");
            Console.WriteLine($"and the sum od the level is : => {BasicFunctioms.SumNodesAtLevel(root, 2)}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"is all the tree fill with positive values? {BasicFunctioms.checkForPositiveTree(root)}");
            Console.WriteLine($"is the tree not single children tree ? {BasicFunctioms.NoSingleChildren(root)}");
            Console.WriteLine($"is the value (M) is in the tree? {BasicFunctioms.IsValueInsideTheTree(root2, 'M')}");
            Console.WriteLine($"is the value 3 a long child of 10? {BasicFunctioms.IsDescendant(root, 3, 10)}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"the intager tree height is : => {BasicFunctioms.GetTreeHeight(root)}");
            Console.WriteLine($"the max value in the integer bonary tree is : => {BasicFunctioms.GetMaxValue(root)}");
            Console.WriteLine($"is the integer tree balanced? {BasicFunctioms.IsBalanced(root)}");
            Console.ResetColor();
        }
    }

}
