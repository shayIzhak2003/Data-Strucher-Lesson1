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
                if (currentNode.HasRight())
                {
                    currentNode = currentNode.GetRight();
                }
                else
                {
                    throw new ArgumentException("Invalid Morse Code: Missing Left Node.");
                }
            }
            // If the symbol is a dash (-), move to the right child node
            else if (symbol == '-')
            {
                if (currentNode.HasLeft())
                {
                    currentNode = currentNode.GetLeft();
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
    //EX3
    public static bool IsYoungTree(BinNode<int> root)
    {
        if (root == null)
        {
            return true;
        }
        if (BasicFunctioms.IsLeaf(root))
        {
            return true;
        }
        // בדיקה האם השורש קטן משני תתי-העצים
        if (root.GetValue() >= root.GetLeft().GetValue() || root.GetValue() >= root.GetRight().GetValue())
        {
            return false;
        }

        // בדיקה האם תת-העץ הימני גדול מתת-העץ השמאלי
        if (root.GetRight().GetValue() <= root.GetLeft().GetValue())
        {
            return false;
        }
        return IsYoungTree(root.GetLeft()) && IsYoungTree(root.GetRight());
    }
    //EX4
    //public static bool IsSigmaTree(BinNode<int> root)
    //{
    //    if (root == null)
    //    {
    //        return true;
    //    }

    //    if (BasicFunctioms.IsLeaf(root))
    //    {
    //        return true; // עלה נחשב כעץ סיגמה
    //    }

    //    if (!root.HasLeft() || !root.HasRight())
    //    {
    //        return false; // אם חסר בן אחד, זה לא עץ סיגמה
    //    }
    //}
}

public class RunTreeLs2
{
    // Build the Morse Tree with the correct structure.
    public static BinNode<char> BuildMorseTree()
    {
        // Root node
        var Root = new BinNode<char>(' ');

        // Level 1
        Root.SetLeft(new BinNode<char>('T'));
        Root.SetRight(new BinNode<char>('E'));

        // Left subtree of T
        Root.GetLeft().SetLeft(new BinNode<char>('M'));
        Root.GetLeft().SetRight(new BinNode<char>('N'));
        Root.GetLeft().GetLeft().SetLeft(new BinNode<char>('O'));
        Root.GetLeft().GetLeft().SetRight(new BinNode<char>('G'));
        Root.GetLeft().GetLeft().GetRight().SetLeft(new BinNode<char>('Q'));
        Root.GetLeft().GetLeft().GetRight().SetRight(new BinNode<char>('Z'));
        Root.GetLeft().GetRight().SetLeft(new BinNode<char>('K'));
        Root.GetLeft().GetRight().SetRight(new BinNode<char>('D'));
        Root.GetLeft().GetRight().GetLeft().SetLeft(new BinNode<char>('Y'));
        Root.GetLeft().GetRight().GetLeft().SetRight(new BinNode<char>('C'));
        Root.GetLeft().GetRight().GetRight().SetLeft(new BinNode<char>('X'));
        Root.GetLeft().GetRight().GetRight().SetRight(new BinNode<char>('B'));

        // Right subtree of E
        Root.GetRight().SetLeft(new BinNode<char>('A'));
        Root.GetRight().SetRight(new BinNode<char>('I'));
        Root.GetRight().GetLeft().SetLeft(new BinNode<char>('W'));
        Root.GetRight().GetLeft().SetRight(new BinNode<char>('R'));
        Root.GetRight().GetLeft().GetLeft().SetLeft(new BinNode<char>('J'));
        Root.GetRight().GetLeft().GetLeft().SetRight(new BinNode<char>('P'));
        Root.GetRight().GetLeft().GetRight().SetLeft(new BinNode<char>('L'));
        Root.GetRight().GetLeft().GetRight().SetRight(new BinNode<char>('8'));
        Root.GetRight().GetRight().SetLeft(new BinNode<char>('U'));
        Root.GetRight().GetRight().SetRight(new BinNode<char>('S'));
        Root.GetRight().GetRight().GetLeft().SetLeft(new BinNode<char>('V'));
        Root.GetRight().GetRight().GetLeft().SetRight(new BinNode<char>('F'));
        Root.GetRight().GetRight().GetRight().SetLeft(new BinNode<char>('0'));
        Root.GetRight().GetRight().GetRight().SetRight(new BinNode<char>('H'));

        return Root;
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

        BinNode<int> root = new BinNode<int>(1);
        root.SetLeft(new BinNode<int>(2));
        root.SetRight(new BinNode<int>(3));
        root.GetLeft().SetLeft(new BinNode<int>(4));
        root.GetLeft().SetRight(new BinNode<int>(5));
        root.GetRight().SetLeft(new BinNode<int>(6));
        root.GetRight().SetRight(new BinNode<int>(7));



        TreeLs1.PrintTree(root);

        Console.WriteLine($"is the tree flat? :=> {TreeLs2.IsFlatTree(root)}");
        Console.WriteLine($"is the tree young? :=> {TreeLs2.IsYoungTree(root)}");
    }
}
