using Data_Strucher_Lesson1.Classes.Binray_tree.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.EX
{
    public class StackEx1
    {
        //EX1
        public static bool CheckForValidStack(Stack<char> stack)
        {
            char prev = 'O';
            while (!stack.IsEmpty())
            {
                char current = stack.Pop();
                if ((prev == 'O' || prev == 'A') && (current != 'F' && current != 'T'))
                    return false;
                if ((prev == 'T' || prev == 'F') && (current != 'A' && current != 'O'))
                    return false;
                if ((current == 'O' || current == 'A') && stack.IsEmpty())
                    return false;
                prev = current;
            }
            return true;
        }
        public static void UpdatS1ToBeThedifference<T>(Stack<T> stack1, Stack<T> stack2)
        {
            Stack<T> tempStack1 = new Stack<T>(); // Temporary stack for filtered s1 elements
            Stack<T> tempStack2 = new Stack<T>(); // Temporary stack for s2 elements

            // Copy s2 into tempStack2 (to preserve s2)
            while (!stack2.IsEmpty())
            {
                T currentStack2Value = stack2.Pop();
                tempStack2.Push(currentStack2Value);
            }

            // Process s1
            while (!stack1.IsEmpty())
            {
                T currentStack1Value = stack1.Pop();
                bool found = false;

                // Check if currentStack1Value exists in tempStack2
                Stack<T> tempCheckStack = new Stack<T>();
                while (!tempStack2.IsEmpty())
                {
                    T currentStack2Value = tempStack2.Pop();
                    tempCheckStack.Push(currentStack2Value);

                    if (currentStack1Value.Equals(currentStack2Value))
                    {
                        found = true;
                    }
                }

                // Restore tempStack2
                while (!tempCheckStack.IsEmpty())
                {
                    tempStack2.Push(tempCheckStack.Pop());
                }

                // Add to tempStack1 if not found in stack2
                if (!found)
                {
                    tempStack1.Push(currentStack1Value);
                }
            }

            // Restore filtered elements back to stack1
            while (!tempStack1.IsEmpty())
            {
                stack1.Push(tempStack1.Pop());
            }

            // Restore stack2 to its original state
            while (!tempStack2.IsEmpty())
            {
                stack2.Push(tempStack2.Pop());
            }

        }

        //EX2
        public static void UpdateTreeStacks<T>(BinNode<Stack<T>> root)
        {
            if (root == null)
            {
                return;
            }

            // בדיקה אם לצומת יש שני בנים
            if (root.HasLeft() && root.HasRight())
            {
                UpdatS1ToBeThedifference(root.GetLeft().GetValue(), root.GetRight().GetValue());
            }

            // קריאה רקורסיבית לשני תתי-העצים
            UpdateTreeStacks(root.GetLeft());
            UpdateTreeStacks(root.GetRight());
        }



        public class RunStackEx1
        {
            public static void DemoMain()
            {
                Stack<char> stack = new Stack<char>();
                stack.Push('F');
                stack.Push('O');
                stack.Push('T');
                stack.Push('A');
                stack.Push('T');
                Console.WriteLine($"is the stack valid? {StackEx1.CheckForValidStack(stack)}");

                Stack<int> s1 = new Stack<int>();
                s1.Push(165);
                s1.Push(6);
                s1.Push(77);
                s1.Push(52);
                s1.Push(40);
                s1.Push(12);
                s1.Push(8); // Top of s1

                Stack<int> s2 = new Stack<int>();
                s2.Push(500);
                s2.Push(52);
                s2.Push(165);
                s2.Push(12);
                s2.Push(77);
                s2.Push(10);
                s2.Push(1); // Top of s2

                StackEx1.UpdatS1ToBeThedifference(s1, s2);

                //EX2
                // בניית עץ של מחסניות
                BinNode<Stack<int>> root = new BinNode<Stack<int>>(new Stack<int>());
                root.GetValue().Push(1);
                root.GetValue().Push(2);

                root.SetLeft(new BinNode<Stack<int>>(new Stack<int>()));
                root.GetLeft().GetValue().Push(3);
                root.GetLeft().GetValue().Push(4);

                root.SetRight(new BinNode<Stack<int>>(new Stack<int>()));
                root.GetRight().GetValue().Push(2);
                root.GetRight().GetValue().Push(4);
                Console.WriteLine("the tree before the update:");
                TreeLs1.PrintTree(root);
                // קריאה לפונקציה
                UpdateTreeStacks(root);

                Console.WriteLine("the tree after the update:");
                // הדפסת המחסניות לאחר העדכון
                TreeLs1.PrintTree(root);
            }
        }
    }
}
