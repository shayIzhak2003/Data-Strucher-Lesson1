using System;

namespace Data_Strucher_Lesson1.Classes.Binray_tree.Lessons
{
    public class TreeLs1
    {
        // Recursive function to build a binary tree (string values)
        public static BinNode<string> BuildStringBinaryTree(int depth, string value, int currentLevel = 1)
        {
            if (depth < currentLevel)
                return null;

            // Create the current node
            var node = new BinNode<string>($"{value}-{currentLevel}");

            // Recursively build the left and right subtrees
            node.SetLeft(BuildStringBinaryTree(depth, value, currentLevel + 1));
            node.SetRight(BuildStringBinaryTree(depth, value, currentLevel + 1));

            return node;
        }

        // Recursive function to build a binary tree (integer values)
        public static BinNode<int> BuildIntBinaryTree(int depth, int value, int currentLevel = 1)
        {
            if (depth < currentLevel)
                return null;

            // Create the current node
            var node = new BinNode<int>(value * currentLevel);

            // Recursively build the left and right subtrees
            node.SetLeft(BuildIntBinaryTree(depth, value, currentLevel + 1));
            node.SetRight(BuildIntBinaryTree(depth, value, currentLevel + 1));

            return node;
        }

        // Function to print the binary tree
        public static void PrintTree<T>(BinNode<T> node, int indentLevel = 0)
        {
            if (node == null)
                return;

            // Print the right subtree
            PrintTree(node.GetRight(), indentLevel + 1);

            // Print the current node with indentation
            Console.WriteLine(new string(' ', indentLevel * 4) + node.GetValue());

            // Print the left subtree
            PrintTree(node.GetLeft(), indentLevel + 1);
        }

        // Function to print even values in a binary tree of integers
        public static void PrintEvenValues(BinNode<int> root)
        {
            if (root == null)
                return;

            // Check if the current value is even
            if (root.GetValue() % 2 == 0)
                Console.WriteLine(root.GetValue());

            // Traverse left subtree
            PrintEvenValues(root.GetLeft());

            // Traverse right subtree
            PrintEvenValues(root.GetRight());
        }
    }

    public class RunTreeLs1
    {
        public static void DemoMain()
        {
            Console.WriteLine("Building a string binary tree...");
            var stringRoot = TreeLs1.BuildStringBinaryTree(3, "Node");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The generated string tree is:");
            TreeLs1.PrintTree(stringRoot);
            Console.ResetColor();

            Console.WriteLine("\nBuilding an integer binary tree...");
            var intRoot = TreeLs1.BuildIntBinaryTree(3, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The generated integer tree is:");
            TreeLs1.PrintTree(intRoot);
            Console.ResetColor();

            Console.WriteLine("\nEven values in the integer binary tree:");
            TreeLs1.PrintEvenValues(intRoot);
        }
    }
}
