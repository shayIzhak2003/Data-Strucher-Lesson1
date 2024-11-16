using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Binray_tree.campusIL
{
    public class BinEx1
    {
        public static BinNode<string> BuildIdent(BinNode<string> bt)
        {
            if(bt == null) 
                return null;

            return new BinNode<string>(BuildIdent(bt.GetLeft()), bt.GetValue(), BuildIdent(bt.GetRight()));
        }
    }
    public class RunBinEx1
    {
        public static void DemoMain()
        {
            BinNode<string> leftChild = new BinNode<string>("Left Child");
            BinNode<string> rightChild = new BinNode<string>("Right Child");

            // Create root node and set its children
            BinNode<string> root = new BinNode<string>(leftChild, "Root", rightChild);

            // Additional nodes can be added by using SetLeft and SetRight on child nodes if desired
            leftChild.SetLeft(new BinNode<string>("Left-Left Grandchild"));
            leftChild.SetRight(new BinNode<string>("Left-Right Grandchild"));
            rightChild.SetLeft(new BinNode<string>("Right-Left Grandchild"));
            rightChild.SetRight(new BinNode<string>("Right-Right Grandchild"));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("the tree is :");
            PrintTree(root, 0);
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("the clone of the tree :");
            Console.WriteLine("=================");
            PrintTree(BinEx1.BuildIdent(root), 0);
            Console.ResetColor();
        }

        // a method to print a binary tree properly
        public static void PrintTree(BinNode<string> node, int indentLevel)
        {
            if (node == null) return;

            // Increase indent for right child
            PrintTree(node.GetRight(), indentLevel + 1);

            // Print current node with indentation
            Console.WriteLine(new string(' ', indentLevel * 4) + node.GetValue());

            // Increase indent for left child
            PrintTree(node.GetLeft(), indentLevel + 1);
        }
    }
}
