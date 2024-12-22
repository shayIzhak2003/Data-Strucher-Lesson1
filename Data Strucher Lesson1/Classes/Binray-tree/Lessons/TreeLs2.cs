using Data_Strucher_Lesson1.Classes;
using Data_Strucher_Lesson1.Classes.Binray_tree.Lessons;
using System;

public class TreeLs2
{
    //EX1 pt.1
    // Decode the given Morse code starting from the root of the tree.
    public static char DecodeMorse(BinNode<char> root, string morseCode)
    {
        BinNode<char> currentNode = root;

        foreach (char symbol in morseCode)
        {
            // If the symbol is a dot (.), move to the left child node
            if (symbol == '.')
            {
                if (currentNode.HasLeft())
                {
                    currentNode = currentNode.GetLeft();
                }
                else
                {
                    throw new ArgumentException("Invalid Morse Code: Missing Left Node.");
                }
            }
            // If the symbol is a dash (-), move to the right child node
            else if (symbol == '-')
            {
                if (currentNode.HasRight())
                {
                    currentNode = currentNode.GetRight();
                }
                else
                {
                    throw new ArgumentException("Invalid Morse Code: Missing Right Node.");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid Symbol '{symbol}' in Morse Code.");
            }
        }

        // Return the value stored at the leaf node
        return currentNode.GetValue();
    }

    //EX2
    public static bool IsFlatTree<T>(BinNode<T> root)
    {
        // אם השורש ריק, זה לא עץ שטוח
        if (root == null)
        {
            return false;
        }

        // סופרים את מספר הצמתים והעלים
        int treeCount = BasicFunctioms.CountBinTree(root);
        int leafCount = BasicFunctioms.GetLeafCount(root);

        // עץ שטוח אם מספר העלים הוא לפחות חצי ממספר הצמתים
        return leafCount >= (treeCount / 2);
    }

}

public class RunTreeLs2
{
    // Build the Morse Tree with the correct structure.
    public static BinNode<char> BuildMorseTree()
    {
        // Root node represents the start of the Morse code tree.
        var root = new BinNode<char>(' ');

        // Level 1: Root and first level of Morse characters
        root.SetLeft(new BinNode<char>('E'));  // Dot for 'E'
        root.SetRight(new BinNode<char>('T')); // Dash for 'T'

        // Level 2: Second level of Morse characters
        root.GetLeft().SetLeft(new BinNode<char>('I'));  // Dot for 'I'
        root.GetLeft().SetRight(new BinNode<char>('A')); // Dot for 'A'
        root.GetRight().SetLeft(new BinNode<char>('N')); // Dash for 'N'
        root.GetRight().SetRight(new BinNode<char>('M')); // Dash for 'M'

        // Level 3: Third level of Morse characters
        root.GetLeft().GetLeft().SetLeft(new BinNode<char>('S'));  // Dot for 'S'
        root.GetLeft().GetLeft().SetRight(new BinNode<char>('U')); // Dot for 'U'
        root.GetLeft().GetRight().SetLeft(new BinNode<char>('R')); // Dot for 'R'
        root.GetLeft().GetRight().SetRight(new BinNode<char>('W')); // Dot for 'W'
        root.GetRight().GetLeft().SetLeft(new BinNode<char>('K')); // Dash for 'K'
        root.GetRight().GetLeft().SetRight(new BinNode<char>('D')); // Dash for 'D'
        root.GetRight().GetRight().SetLeft(new BinNode<char>('O')); // Dash for 'O'
        root.GetRight().GetRight().SetRight(new BinNode<char>('G')); // Dash for 'G'

        // Level 4: Fourth level of Morse characters
        root.GetLeft().GetLeft().GetLeft().SetLeft(new BinNode<char>('H'));  // Dot for 'H'
        root.GetLeft().GetLeft().GetLeft().SetRight(new BinNode<char>('V')); // Dot for 'V'
        root.GetLeft().GetLeft().GetRight().SetLeft(new BinNode<char>('F')); // Dot for 'F'
        root.GetLeft().GetLeft().GetRight().SetRight(new BinNode<char>('L')); // Dot for 'L'
        root.GetLeft().GetRight().GetLeft().SetLeft(new BinNode<char>('P')); // Dot for 'P'
        root.GetLeft().GetRight().GetLeft().SetRight(new BinNode<char>('J')); // Dot for 'J'
        root.GetRight().GetLeft().GetLeft().SetLeft(new BinNode<char>('B')); // Dash for 'B'
        root.GetRight().GetLeft().GetLeft().SetRight(new BinNode<char>('X')); // Dash for 'X'
        root.GetRight().GetRight().GetLeft().SetLeft(new BinNode<char>('C')); // Dash for 'C'
        root.GetRight().GetRight().GetLeft().SetRight(new BinNode<char>('Y')); // Dash for 'Y'

        return root;
    }

    // Demo main function to run and test the decoding.
    public static void DemoMain()
    {
        var morseTree = BuildMorseTree();

        try
        {
            // Test the decoding for different Morse code strings
            Console.WriteLine(TreeLs2.DecodeMorse(morseTree, ".-"));    // Expected: 'A'
            Console.WriteLine(TreeLs2.DecodeMorse(morseTree, "-..."));  // Expected: 'B'
            Console.WriteLine(TreeLs2.DecodeMorse(morseTree, ".."));    // Expected: 'I'
            Console.WriteLine(TreeLs2.DecodeMorse(morseTree, "---"));   // Expected: 'O'
            Console.WriteLine(TreeLs2.DecodeMorse(morseTree, ".--"));   // Expected: 'W'
            Console.WriteLine(TreeLs2.DecodeMorse(morseTree, "-.-."));  // Expected: 'C'
        }
        catch (ArgumentException ex)
        {
            // Handle exceptions during decoding.
            Console.WriteLine($"Error: {ex.Message}");
        }

        var root = new BinNode<int>(10);
        var leftChild = new BinNode<int>(5);
        var rightChild = new BinNode<int>(15);
        root.SetLeft(leftChild);
        root.SetRight(rightChild);
        leftChild.SetLeft(new BinNode<int>(3));
        leftChild.SetRight(new BinNode<int>(7));
        rightChild.SetLeft(new BinNode<int>(12));
        rightChild.SetRight(new BinNode<int>(18));


        TreeLs1.PrintTree(root);

        Console.WriteLine($"is the tree flat? :=> {TreeLs2.IsFlatTree(root)}");
    }
}
